namespace UnitConversionAPI
{
    public class Constants
    {
        public static List<string> UnitTypes = ["Mass", "Length", "Temperature", "Time"];
        public static Dictionary<string, List<string>> UnitMapping =
            new Dictionary<string, List<string>>()
            {
                { "Mass", ["kg", "g", "mg", "tonne", "pound"] },
                { "Length", ["meter", "km", "cm", "mm", "foot", "inch", "mile"] },
                { "Temperature", ["celsius", "fahrenheit", "kelvin"] },
                { "Time", ["second", "minute", "hour"] }
            };
    }
}
