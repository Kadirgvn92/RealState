namespace RealState.Entity;

public class RealEstateCategory
{
    public int RealEstateCategoryID { get; set; }
    public string CategoryName { get; set; }

    public List<Portfolio> Portfolios { get; set; }

}
