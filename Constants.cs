namespace UnitConversionAPI
{
    public class Constants
    {
        public static List<string> UnitTypes = new List<string> { "Mass", "Length", "Temperature", "Time" };
        public static Dictionary<string, List<string>> UnitMapping =
            new Dictionary<string, List<string>>()
            {
                { "Mass", new List<string> { "kg", "g", "mg", "tonne", "pound" } },
                { "Length", new List<string> { "meter", "km", "cm", "mm", "foot", "inch", "mile" } },
                { "Temperature", new List<string> { "celsius", "fahrenheit", "kelvin" } },
                { "Time", new List<string> { "second", "minute", "hour" } }
            };
    }
}
