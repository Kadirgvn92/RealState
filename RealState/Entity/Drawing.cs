using NetTopologySuite.Geometries;
using RealState.Repository.IRepository;

namespace RealState.Entity;

public class Drawing : ISoftDeletable
{
    public int DrawingId { get; set; }
    public string Type { get; set; }
    public Geometry? Geometry { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int? PortfolioID { get; set; }
    public Portfolio Portfolio { get; set; }
    public bool IsDeleted { get; set; }
}
