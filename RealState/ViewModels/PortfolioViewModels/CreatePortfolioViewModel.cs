using RealState.Entity;

namespace RealState.ViewModels.PortfolioViewModels;

public class CreatePortfolioViewModel
{
    // Portfolio properties
    public string Title { get; set; }
    public string? Description { get; set; }
    public int? SellerID { get; set; }
    public int RealEstateAddressID { get; set; }
    public int RealEstateTypeID { get; set; }
    public int RealEstateCategoryID { get; set; }
    public int RealEstateStatusID { get; set; }
    public string?  CoverImageUrl { get; set; }
    public IFormFile Image { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsAvailable { get; set; }
    public bool IsDeleted { get; set; }

    // RealEstateAddress properties
    public string? Street { get; set; }
    public string? BuildingNumber { get; set; }
    public string? ApartmentNumber { get; set; }
    public string? City { get; set; }
    public string? District { get; set; }
    public string? Neighborhood { get; set; }
    public string? AddressLine { get; set; }
    public string? AddressDescription { get; set; }
}
