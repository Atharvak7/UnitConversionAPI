namespace UnitConversionAPI.Service
{
    public class LinearConverter : IUnitConverter
    {
        public IReadOnlyCollection<string> SupportedTypes { get; } = new[] { "Length", "Mass", "Time" };

        public bool CanConvert(UnitDefinition from, UnitDefinition to)
        {
            if (!SupportedTypes.Contains(from.Type, StringComparer.OrdinalIgnoreCase))
                return false;
            if (!SupportedTypes.Contains(to.Type, StringComparer.OrdinalIgnoreCase))
                return false;
            return from.Exponent == to.Exponent;
        }

        public double Convert(UnitDefinition from, UnitDefinition to, double value)
        {
            double baseValue = value * from.ToBaseFactor;
            return baseValue / to.ToBaseFactor;
        }
    }
}
