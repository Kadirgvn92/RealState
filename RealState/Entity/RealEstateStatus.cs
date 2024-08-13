namespace RealState.Entity;

public class RealEstateStatus
{
    public int RealEstateStatusID { get; set; }
    public string StatusName { get; set; }
    public List<Portfolio> Portfolios { get; set; }
}
