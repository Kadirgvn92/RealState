using RealState.Repository.IRepository;
using System.Xml;

namespace RealState.Entity;

public class RealEstateAddress : ISoftDeletable
{
    public int RealEstateAddressID { get; set; }
    public string? Street { get; set; }
    public string? BuildingNumber { get; set; }
    public string? ApartmentNumber { get; set; }
    public string? City { get; set; }
    public string? District { get; set; }
    public string? Neighborhood { get; set; }
    public string? AddressLine { get; set; } 
    public string? Description { get; set; } 
    public int PortfolioID { get; set; }
    public Portfolio Portfolio { get; set; }
    public bool IsDeleted { get; set; }
}
