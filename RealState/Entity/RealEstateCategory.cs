using RealState.Repository.IRepository;

namespace RealState.Entity;

public class RealEstateCategory : ISoftDeletable
{
    public int RealEstateCategoryID { get; set; }
    public string CategoryName { get; set; }

    public List<Portfolio> Portfolios { get; set; }
    public bool IsDeleted { get; set; }
}
