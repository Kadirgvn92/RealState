using RealState.Repository.IRepository;

namespace RealState.Entity;

public class FSBO : ISoftDeletable
{
    public int FSBOId { get; set; }
    public string ListingNumber { get; set; }
    public string PhoneNumber { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsDeleted { get; set; }
}
