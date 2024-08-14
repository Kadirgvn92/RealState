namespace RealState.ViewModels.AuthViewModels;

public class RegisterViewModel
{
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Mail { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public bool IsConfirmed { get; set; }
}
