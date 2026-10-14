namespace UnitConversionAPI.Service
{
 public class UnitDefinition : IUnitDefinition
 {
 public string Id { get; init; } = string.Empty;
 public string Type { get; init; } = string.Empty;
 public double ToBaseFactor { get; init; }
 public double Offset { get; init; }
 public int Exponent { get; init; } =1;
 public IDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
 }
}
