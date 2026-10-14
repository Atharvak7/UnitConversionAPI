namespace UnitConversionAPI.Service
{
     public interface IUnitConverter
     {
         IReadOnlyCollection<string> SupportedTypes { get; }
         bool CanConvert(UnitDefinition from, UnitDefinition to);
         double Convert(UnitDefinition from, UnitDefinition to, double value);
     }
}
