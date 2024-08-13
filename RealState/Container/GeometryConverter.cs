using NetTopologySuite.Geometries;
using NetTopologySuite.IO;

namespace RealState.Container;

public class GeometryConverter
{
    public static string WktToGeoJson(string wkt)
    {
        // WKT stringini geometri nesnesine dönüştür
        WKTReader reader = new WKTReader();
        Geometry geometry = reader.Read(wkt);

        // Geometriyi GeoJSON formatına dönüştür
        GeoJsonWriter writer = new GeoJsonWriter();
        string geoJson = writer.Write(geometry);

        return geoJson;
    }
}