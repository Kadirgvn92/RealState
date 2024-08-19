using RealState.Repository.IRepository;

namespace RealState.Entity;

public class Portfolio : ISoftDeletable
{
    public int PortfolioID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int? SellerID { get; set; }
    public Seller Seller { get; set; }

    public int RealEstateAddressID { get; set; }
    public RealEstateAddress RealEstateAddress { get; set; }

    public int RealEstateTypeID { get; set; }
    public RealEstateType RealEstateType { get; set; }

    public int RealEstateCategoryID { get; set; }
    public RealEstateCategory RealEstateCategory { get; set; }

    public int RealEstateStatusID { get; set; }
    public RealEstateStatus RealEstateStatus { get; set; }


    public List<CalendarEvent> CalendarEvents { get; set; }
    public List<Notification> Notifications { get; set; }
    public string CoverImageUrl { get; set; }
    public DateTime CreatedDate { get; set; }
    public int AppUserID { get; set; }
    public AppUser AppUser { get; set; }
    public bool IsAvailable { get; set; }
    public bool IsDeleted { get; set; }
}
