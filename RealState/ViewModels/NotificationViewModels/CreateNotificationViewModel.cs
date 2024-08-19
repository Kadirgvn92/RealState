using RealState.Entity;

namespace RealState.ViewModels.NotificationViewModels;

public class CreateNotificationViewModel
{
    public string Title { get; set; }
    public string Message { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsRead { get; set; }
    public int? BuyerID { get; set; }
    public int? SellerID { get; set; }
    public int? QuestID { get; set; }
    public int? FSBOId { get; set; }
    public int? PortfolioID { get; set; }

    public Buyer Buyer { get; set; }
    public Seller Seller { get; set; }
    public Quest Quest { get; set; }
    public Portfolio Portfolio { get; set; }
    public FSBO FSBO { get; set; }
}
