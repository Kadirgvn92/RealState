using RealState.Entity;

namespace RealState.ViewModels.BuyerViewModels;

public class CreateBuyerViewModel
{
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Budget { get; set; }
    public string? PreferredLocation { get; set; }
    public string? Description { get; set; }
    public string? Rooms { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsDeleted { get; set; }
}
