namespace RealState.Entity;

public class RealEstateType
{
    public int RealEstateTypeID { get; set; }
    public string TypeName { get; set; }
    public List<Portfolio> Portfolios { get; set; }
}
