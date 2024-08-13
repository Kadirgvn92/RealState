using RealState.Entity;

namespace RealState.ViewModels.PortfolioViewModels;

public class CreatePortfolioViewModel
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public int? SellerID { get; set; }
    public int? BuyerID { get; set; }
    public int RealEstateAddressID { get; set; }
    public int RealEstateTypeID { get; set; }
    public int RealEstateCategoryID { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsAvailable { get; set; }
    public bool IsDeleted { get; set; }
}
