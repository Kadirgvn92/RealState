using RealState.Entity;

namespace RealState.ViewModels.FSBOViewModels;

public class CreateFSBOViewModel
{
    public string ListingNumber { get; set; }
    public string PhoneNumber { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public int AppUserID { get; set; }
}
