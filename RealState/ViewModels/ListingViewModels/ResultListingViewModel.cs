namespace RealState.ViewModels.ListingViewModels;

public class ResultListingViewModel
{
    public int ListingID { get; set; }
    public string ListingNumber { get; set; } // İlan No
    public string? Title { get; set; } // İlan başlığı
    public string? Price { get; set; } // Fiyat (örn: "22.000 TL")
    public string? City { get; set; } // Şehir (örn: Bursa)
    public string? District { get; set; } // İlçe (örn: Nilüfer)
    public string? Neighborhood { get; set; } // Mahalle (örn: Beşevler Mh.)
    public DateTime? ListingDate { get; set; } // İlan tarihi
    public string? PropertyType { get; set; } // Emlak Tipi (örn: Kiralık Daire)
    public int? GrossArea { get; set; } // Brüt m²
    public int? NetArea { get; set; } // Net m²
    public string? RoomCount { get; set; } // Oda Sayısı (örn: 3+1)
    public string? BuildingAge { get; set; } // Bina Yaşı (örn: 21-25 arası)
    public int? FloorNumber { get; set; } // Bulunduğu Kat
    public int? TotalFloors { get; set; } // Toplam Kat Sayısı
    public string? HeatingType { get; set; } // Isıtma Türü (örn: Kombi)
    public int? BathroomCount { get; set; } // Banyo Sayısı
    public string? Balcony { get; set; } // Balkon var mı?
    public string? Elevator { get; set; } // Asansör var mı?
    public string? Parking { get; set; } // Otopark var mı?
    public string? Furnished { get; set; } // Eşyalı mı?
    public string? UsageStatus { get; set; } // Kullanım Durumu (örn: Boş)
    public bool? IsInHousingComplex { get; set; } // Site İçerisinde mi?
    public string? HousingComplexName { get; set; } // Site Adı (varsa)
    public decimal? MonthlyFee { get; set; } // Aidat (TL)
    public decimal? Deposit { get; set; } // Depozito (TL)
    public string? OwnerType { get; set; } // Kimden (örn: Emlak Ofisinden)

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Kayıt oluşturulma tarihi
    public DateTime? UpdatedAt { get; set; } // Kayıt güncellenme tarihi
}
