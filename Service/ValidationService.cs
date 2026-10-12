using UnitConversionAPI.Contracts;

namespace UnitConversionAPI.Service
{
    public class ValidationService
    {
        public List<string> Validate(UnitConversionRequest request)
        {
            var errors = new List<string>();

            if(string.IsNullOrEmpty(request.MeasurementType))
            {
                errors.Add("Measurement Type is required");
            }

            if (string.IsNullOrEmpty(request.From))
            {
                errors.Add("From is required");
            }

            if (string.IsNullOrEmpty(request.To))
            {
                errors.Add("To is required");
            }

            if (errors.Count > 0)
                return errors;

            if (!Constants.UnitTypes.Contains(request.MeasurementType))
            {
                errors.Add("Invalid Unit Type: " + request.MeasurementType);
                return errors;
            }

            if (!Constants.UnitMapping[request.MeasurementType].Contains(request.From) 
                || !Constants.UnitMapping[request.MeasurementType].Contains(request.To))
            {
                errors.Add("Invalid from and to selection. Select from and to from same mmeasurement type");
                return errors;
            }
            return errors;
        }
    }
}
