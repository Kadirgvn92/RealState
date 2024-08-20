using RealState.Repository.IRepository;

namespace RealState.Entity;

public class Quest : ISoftDeletable
{
    public int QuestID { get; set; }
    public string Title { get; set; }
    public string? Price { get; set; }
    public string? AddressLine { get; set; }
    public string? Latitude { get; set; }
    public string? Longtitude { get; set; }
    public DateTime CreatedDate { get; set; }

    public int RealEstateTypeID { get; set; }
    public RealEstateType RealEstateType { get; set; }

    public int RealEstateCategoryID { get; set; }
    public RealEstateCategory RealEstateCategory { get; set; }

    public int RealEstateStatusID { get; set; }
    public RealEstateStatus RealEstateStatus { get; set; }
    public int AppUserID { get; set; }
    public AppUser AppUser { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsEmergency { get; set; }
    public List<Notification> Notifications { get; set; }
}
