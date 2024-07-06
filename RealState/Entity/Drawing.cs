using NetTopologySuite.Geometries;

namespace RealState.Entity;

public class Drawing
{
    public int DrawingId { get; set; }
    public string Type { get; set; }
    public Geometry? Geometry { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}
