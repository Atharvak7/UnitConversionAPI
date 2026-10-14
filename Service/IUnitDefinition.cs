namespace UnitConversionAPI.Service
{
 public interface IUnitDefinition
 {
 string Id { get; }
 string Type { get; }
 double ToBaseFactor { get; }
 double Offset { get; }
 int Exponent { get; }
 IDictionary<string, string> Metadata { get; }
 }
}
