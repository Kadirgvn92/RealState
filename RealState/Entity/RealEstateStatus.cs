using RealState.Repository.IRepository;

namespace RealState.Entity;

public class RealEstateStatus : ISoftDeletable
{
    public int RealEstateStatusID { get; set; }
    public string StatusName { get; set; }
    public List<Portfolio> Portfolios { get; set; }

    public bool IsDeleted { get; set; }
}
