using RealState.Entity;

namespace RealState.ViewModels.QuestViewModels;

public class CreateQuestViewModel
{
    public string Title { get; set; }
    public string? Price { get; set; }
    public string? AddressLine { get; set; }
    public string? Latitude { get; set; }
    public string? Longtitude { get; set; }
    public DateTime CreatedDate { get; set; }
    public int RealEstateTypeID { get; set; }
    public int RealEstateCategoryID { get; set; }
    public int RealEstateStatusID { get; set; }
    public int AppUserID { get; set; }
    public bool IsEmergency { get; set; }
}
