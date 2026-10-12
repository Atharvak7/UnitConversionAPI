namespace UnitConversionAPI.Contracts
{
    public class UnitConversionResponse
    {
        public UnitConversionResponse()
        {
            Errors = new List<string>();
        }
        public double Value { get; set; }
        public List<string> Errors { get; set; }
    }
}
