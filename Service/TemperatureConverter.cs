namespace UnitConversionAPI.Service
{
    public class TemperatureConverter : IUnitConverter
    {
        public IReadOnlyCollection<string> SupportedTypes { get; } = new[] { "Temperature" };

        public bool CanConvert(UnitDefinition from, UnitDefinition to)
        {
            return SupportedTypes.Contains(from.Type, StringComparer.OrdinalIgnoreCase)
            && SupportedTypes.Contains(to.Type, StringComparer.OrdinalIgnoreCase);
        }

        public double Convert(UnitDefinition from, UnitDefinition to, double value)
        {
            double celsius = from.Id.ToLowerInvariant() switch
            {
                "celsius" or "c" => value,
                "fahrenheit" or "f" => (value - 32) * 5.0 / 9.0,
                "kelvin" or "k" => value - 273.15,
                _ => throw new InvalidOperationException($"Unknown temperature unit {from.Id}")
            };

            return to.Id.ToLowerInvariant() switch
            {
                "celsius" or "c" => celsius,
                "fahrenheit" or "f" => celsius * 9.0 / 5.0 + 32,
                "kelvin" or "k" => celsius + 273.15,
                _ => throw new InvalidOperationException($"Unknown temperature unit {to.Id}")
            };
        }
    }
}