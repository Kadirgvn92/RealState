using RealState.Repository.IRepository;

namespace RealState.Entity;

public class RealEstateType : ISoftDeletable
{
    public int RealEstateTypeID { get; set; }
    public string TypeName { get; set; }
    public List<Portfolio> Portfolios { get; set; }

    public bool IsDeleted { get; set; }
}
