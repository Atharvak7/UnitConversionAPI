namespace UnitConversionAPI.Contracts
{
    public class UnitConversionRequest
    {
        public string MeasurementType { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public double Value { get; set; }
    }
}
