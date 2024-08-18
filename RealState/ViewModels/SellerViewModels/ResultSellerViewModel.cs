namespace RealState.ViewModels.SellerViewModels;

public class ResultSellerViewModel
{
    public int SellerID { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? PropertyTitle { get; set; }
    public string? AskingPrice { get; set; }
    public string? Description { get; set; }
    public DateTime ListingDate { get; set; }
    public bool IsDeleted { get; set; }

    public string FullName
    {
        get
        {
            return $"{FirstName} {LastName}";
        }
    }
}
