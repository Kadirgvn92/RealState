(function () {
    const calendaroffcanvas = new bootstrap.Offcanvas('#calendar-add_edit_event');
    const calendarmodal = new bootstrap.Modal('#calendar-modal');
    var calendevent = '';

    var date = new Date();
    var d = date.getDate();
    var m = date.getMonth();
    var y = date.getFullYear();

    var calendar = new FullCalendar.Calendar(document.getElementById('calendar'), {
        headerToolbar: {
            left: 'prev,next today',
            center: 'title',
            right: 'dayGridMonth,timeGridWeek,timeGridDay,listMonth'
        },
        buttonText: {
            today: 'Bugun',
            month: 'Ay',
            week: 'Hafta',
            day: 'Gun',
            list: 'Liste'
        },
        timeZone: 'Europe/Istanbul',
        themeSystem: 'bootstrap',
        initialDate: new Date(y, m, 16),
        slotDuration: '00:10:00',
        navLinks: true,
        height: 'auto',
        droppable: true,
        selectable: true,
        selectMirror: true,
        editable: true,
        dayMaxEvents: true,
        handleWindowResize: true,
        locale: 'tr',
        select: function (info) {
            var sdt = new Date(info.start);
            var edt = new Date(info.end);
            //document.getElementById('pc-e-sdate').value = '';
            //document.getElementById('pc-e-edate').value = '';

            document.getElementById('pc-e-title').value = '';
            document.getElementById('pc-e-venue').value = '';
            document.getElementById('pc-e-description').value = '';
            document.getElementById('pc-e-type').value = '';
            document.getElementById('pc-e-btn-text').innerHTML = '<i class="align-text-bottom me-1 ti ti-calendar-plus"></i> Add';
            document.querySelector('#pc_event_add').setAttribute('data-pc-action', 'add');

            calendaroffcanvas.show();
            calendar.unselect();
        },
        eventClick: function (info) {
            console.log(info)
            calendevent = info.event;
            var clickedevent = info.event;
            var e_title = clickedevent.title === undefined ? '' : clickedevent.title;
            var e_desc = clickedevent.extendedProps.description === undefined ? '' : clickedevent.extendedProps.description;
            var e_date_start = clickedevent.start ? toTurkeyTime(clickedevent.start).toLocaleString('tr-TR') : '';
            var e_date_end = clickedevent.end ? " <i class='text-sm'>to</i> " + toTurkeyTime(clickedevent.end).toLocaleString('tr-TR') : '';
            e_date_end = clickedevent.end === null ? '' : e_date_end;
            var e_venue = clickedevent.extendedProps.description === undefined ? '' : clickedevent.extendedProps.venue;

            document.querySelector('.calendar-modal-title').innerHTML = e_title;
            document.querySelector('.pc-event-title').innerHTML = e_title;
            document.querySelector('.pc-event-description').innerHTML = e_desc;
            document.querySelector('.pc-event-date').innerHTML = e_date_start + e_date_end;
            document.querySelector('.pc-event-venue').innerHTML = e_venue;

            calendarmodal.show();
        },
        events: function (fetchInfo, successCallback, failureCallback) {
            fetch('/Calendar/GetEvents')
                .then(response => {
                    return response.json();
                })
                .then(data => {
                   console.log(data)
                   successCallback(data);
                })
                .catch(error => failureCallback(error));
        }
    });

    calendar.render();
    document.addEventListener('DOMContentLoaded', function () {
        var calbtn = document.querySelectorAll('.fc-toolbar-chunk');
        for (var t = 0; t < calbtn.length; t++) {
            var c = calbtn[t];
            c.children[0].classList.remove('btn-group');
            c.children[0].classList.add('d-inline-flex');
        }
    });

    var pc_event_remove = document.querySelector('#pc_event_remove');
    if (pc_event_remove) {
        pc_event_remove.addEventListener('click', function () {
            const swalWithBootstrapButtons = Swal.mixin({
                customClass: {
                    confirmButton: 'btn btn-light-success',
                    cancelButton: 'btn btn-light-danger'
                },
                buttonsStyling: false
            });
            swalWithBootstrapButtons
                .fire({
                    title: 'Emin misin?',
                    text: 'Bu program, silmek istiyor musun?',
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonText: 'Evet, bunu sil!',
                    cancelButtonText: 'Hayir, iptal et!',
                    reverseButtons: true
                })
                .then((result) => {
                    if (result.isConfirmed) {
                        calendevent.remove();
                        calendarmodal.hide();
                        swalWithBootstrapButtons.fire('Silindi!', 'Program baþarýyla silindi.', 'success');
                    } else if (result.dismiss === Swal.DismissReason.cancel) {
                        swalWithBootstrapButtons.fire('Ýptal edildi!', 'Program bilgilerin güvende.', 'error');
                    }
                });
        });
    }
    
    var pc_event_add = document.querySelector('#pc_event_add');
    if (pc_event_add) {
        pc_event_add.addEventListener('click', function () {
            var day = true;
            var e_date_start = document.getElementById('pc-e-sdate').value;
            var e_date_end = document.getElementById('pc-e-edate').value;
            

            var eventData = {
                title: document.getElementById('pc-e-title').value,
                startDate: e_date_start, 
                endDate: e_date_end ? e_date_end : null, 
                allDay: day,
                description: document.getElementById('pc-e-description').value,
                venue: document.getElementById('pc-e-venue').value,
                className: document.getElementById('pc-e-type').value
            };

            console.log(eventData);

            // Determine action based on button state
            var action = pc_event_add.getAttribute('data-pc-action');
            var url = action === 'add' ? '/Calendar/Add' : '/Calendar/Update';
            var method = 'POST';  // Both 'add' and 'update' use POST method

            fetch(url, {
                method: method,
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(eventData)
            })
                .then(response => response.text()) // Yanýtý text olarak al
                .then(text => {
                    console.log(text); // Yanýtý kontrol et
                    try {
                        const data = JSON.parse(text); // Yanýtý JSON olarak ayrýþtýr
                        if (action === 'add') {
                            calendar.addEvent(eventData);
                            Swal.fire({
                                customClass: {
                                    confirmButton: 'btn btn-light-primary'
                                },
                                buttonsStyling: false,
                                icon: 'success',
                                title: 'Basarili',
                                text: 'Program basariyla olusturuldu.'
                            }).then(() => {
                                window.location.reload(); // Sayfayý yenile
                            });
                        } else {
                            calendevent.remove();
                            calendar.addEvent(eventData);
                            Swal.fire({
                                customClass: {
                                    confirmButton: 'btn btn-light-primary'
                                },
                                buttonsStyling: false,
                                icon: 'success',
                                title: 'Basarili',
                                text: 'Program basariyla guncellendi.'
                            });
                        }
                        calendaroffcanvas.hide();
                    } catch (e) {
                        console.error('Parsing error:', e); // JSON parsing hatasý
                        Swal.fire({
                            customClass: {
                                confirmButton: 'btn btn-light-primary'
                            },
                            buttonsStyling: false,
                            icon: 'error',
                            title: 'Hata',
                            text: 'Yanýt iþlenirken hata meydana geldi!'
                        });
                    }
                })
                .catch(error => {
                    console.error('Error:', error);
                    Swal.fire({
                        customClass: {
                            confirmButton: 'btn btn-light-primary'
                        },
                        buttonsStyling: false,
                        icon: 'error',
                        title: 'Hata',
                        text: 'Program oluþtururken hata meydana geldi!'
                    });
                });

        });
    }

    var pc_event_edit = document.querySelector('#pc_event_edit');
    if (pc_event_edit) {
        pc_event_edit.addEventListener('click', function () {
            var e_title = calendevent.title === undefined ? '' : calendevent.title;
            var e_desc = calendevent.extendedProps.description === undefined ? '' : calendevent.extendedProps.description;
            var e_date_start = calendevent.start === null ? '' : dateformat(calendevent.start);
            var e_date_end = calendevent.end === null ? '' : " <i class='text-sm'>to</i> " + dateformat(calendevent.end);
            e_date_end = calendevent.end === null ? '' : e_date_end;
            var e_venue = calendevent.extendedProps.description === undefined ? '' : calendevent.extendedProps.venue;
            var e_type = calendevent.classNames[0] === undefined ? '' : calendevent.classNames[0];

            document.getElementById('pc-e-title').value = e_title;
            document.getElementById('pc-e-venue').value = e_venue;
            document.getElementById('pc-e-description').value = e_desc;
            document.getElementById('pc-e-type').value = e_type;
            var sdt = new Date(e_date_start);
            var edt = new Date(e_date_end);
            document.getElementById('pc-e-sdate').value = sdt.getFullYear() + '-' + getRound(sdt.getMonth() + 1) + '-' + getRound(sdt.getDate());
            document.getElementById('pc-e-edate').value = edt.getFullYear() + '-' + getRound(edt.getMonth() + 1) + '-' + getRound(edt.getDate());
            document.getElementById('pc-e-btn-text').innerHTML = '<i class="align-text-bottom me-1 ti ti-calendar-stats"></i> Update';
            document.querySelector('#pc_event_add').setAttribute('data-pc-action', 'edit');
            calendarmodal.hide();
            calendaroffcanvas.show();
        });
    }

    function toTurkeyTime(utcDate) {
        var date = new Date(utcDate);
        // Türkiye saat diliminde UTC+3
        date.setHours(date.getHours() - 3);
        return date;
    }
    //  get round value
    function getRound(vale) {
        var tmp = '';
        if (vale < 10) {
            tmp = '0' + vale;
        } else {
            tmp = vale;
        }
        return tmp;
    }

    //  get time
    function getTime(timeValue) {
        timeValue = new Date(timeValue);
        if (timeValue.getHours() != null) {
            var hour = timeValue.getHours();
            var minute = timeValue.getMinutes() ? timeValue.getMinutes() : 0;
            return hour + ':' + minute;
        }
    }
    function timeformat(time) {
        var timeFormat = time.split(':');
        var hours = getRound(parseInt(timeFormat[0]));
        var minutes = getRound(timeFormat[1]);
        return hours + ':' + minutes;
    }


    //  get date
    function dateformat(dt) {
        var mn = ['Ocak', 'Subat', 'Mart', 'Nisan', 'Mayýs', 'Haziran', 'Temmuz', 'Agustos', 'Eylul', 'Ekim', 'Kasým', 'Aralýk'];
        var d = new Date(dt),
            month = '' + mn[d.getMonth()],
            day = '' + d.getDate(),
            year = d.getFullYear();
        if (month.length < 2) month = '0' + month;
        if (day.length < 2) day = '0' + day;
        return [day + ' ' + month, year].join(',');
    }

    //  get full date
    function timeformat(time) {
        var timeFormat = time.split(':');
        var hours = parseInt(timeFormat[0]);
        var minutes = timeFormat[1];

        // Eðer saat tek basamaklýysa, baþýna 0 ekleyelim
        hours = hours < 10 ? '0' + hours : hours;

        // Eðer dakika tek basamaklýysa, baþýna 0 ekleyelim
        minutes = minutes < 10 ? '0' + minutes : minutes;

        // 24 saat formatýnda döndürme
        return hours + ':' + minutes;
    }

    calendar.setOption('locale', 'tr');
})();
