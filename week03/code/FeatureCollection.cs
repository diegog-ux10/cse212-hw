public class FeatureCollection
{
    // The top level object contains an array of Features
    public Feature[] Features { get; set; }
}

// Each feature represents a single earthquake
public class Feature
{
    // Each feature has a properties object containing earthquake details
    public Properties Properties { get; set; }
}

// Properties object containing the specific earthquake data we need
public class Properties
{
    // The location of the earthquake
    public string Place { get; set; }

    // The magnitude of the earthquake
    public double Mag { get; set; }
}