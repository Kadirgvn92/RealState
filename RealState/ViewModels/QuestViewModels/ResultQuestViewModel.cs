namespace RealState.ViewModels.QuestViewModels;

public class ResultQuestViewModel
{
    public int QuestID { get; set; }
    public string Title { get; set; }
    public string? Price { get; set; }
    public string? AddressLine { get; set; }
    public string? Latitude { get; set; }
    public string? Longtitude { get; set; }
    public DateTime CreatedDate { get; set; }

    public string RealEstateTypeName { get; set; } // Just include the name, not the whole object
    public string RealEstateCategoryName { get; set; } // Same for category
    public string RealEstateStatusName { get; set; } // Same for status
}
