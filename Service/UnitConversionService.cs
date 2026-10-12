namespace UnitConversionAPI.Service
{
    public class UnitConversionService
    {
        private static readonly Dictionary<string, double> LengthUnits =
        new(StringComparer.OrdinalIgnoreCase)
        {
            ["meter"] = 1,
            ["km"] = 1000,
            ["cm"] = 0.01,
            ["mm"] = 0.001,
            ["mile"] = 1609.344,
            ["foot"] = 0.3048,
            ["inch"] = 0.0254
        };

        private static readonly Dictionary<string, double> MassUnits =
        new(StringComparer.OrdinalIgnoreCase)
        {
            ["kg"] = 1,
            ["g"] = 0.001,
            ["mg"] = 0.000001,
            ["tonne"] = 1000,
            ["pound"] = 0.45359237,
            ["ounce"] = 0.028349523125
        };

        private static readonly Dictionary<string, double> TimeUnits =
        new(StringComparer.OrdinalIgnoreCase)
        {
            ["second"] = 1,
            ["minute"] = 60,
            ["hour"] = 3600
        };

        public double Convert(string unitType, string from, string to, double value)
        {
            return unitType switch
            {
                "Length" =>
                    ConvertLinear(value, from, to, LengthUnits),

                "Mass" =>
                    ConvertLinear(value, from, to, MassUnits),

                "Time" =>
                    ConvertLinear(value, from, to, TimeUnits),

                "Temperature" =>
                    ConvertTemperature(value, from, to),
            };

        }

        private static double ConvertLinear(double value, string from, string to, Dictionary<string, double> units)
        {
            var fromFactor = units[from];
            var toFactor = units[to];
            double baseValue = value * fromFactor;
            return baseValue / toFactor;
        }

        private static double ConvertTemperature(double value, string from, string to)
        {
            double celsius = from.ToLowerInvariant() switch
            {
                "celsius" or "c" => value,
                "fahrenheit" or "f" => (value - 32) * 5.0 / 9.0,
                "kelvin" or "k" => value - 273.15,
            };

            return to.ToLowerInvariant() switch
            {
                "celsius" or "c" => celsius,
                "fahrenheit" or "f" => celsius * 9.0 / 5.0 + 32,
                "kelvin" or "k" => celsius + 273.15,
            };
        }

    }
}


