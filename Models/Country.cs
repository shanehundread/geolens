namespace GeoLens.Api.Models;

public class Country
{
    public Name Name { get; set; } = new();
    public string Cca3 { get; set; } = string.Empty;
    public string[]? Capital { get; set; }
    public string Region { get; set; } = string.Empty;
    public string? Subregion { get; set; }
    public long Population { get; set; }
    public double? Area { get; set; }
    public Flags Flags { get; set; } = new();
    public Dictionary<string, Currency>? Currencies { get; set; }
    public Dictionary<string, string>? Languages { get; set; }
}

public class Name
{
    public string Common { get; set; } = string.Empty;
    public string Official { get; set; } = string.Empty;
}

public class Flags
{
    public string Svg { get; set; } = string.Empty;
}

public class Currency
{
    public string Name { get; set; } = string.Empty;
    public string? Symbol { get; set; }
}