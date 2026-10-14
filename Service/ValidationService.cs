using System;
using System.Collections.Generic;
using System.Linq;
using UnitConversionAPI.Contracts;

namespace UnitConversionAPI.Service
{
    public class ValidationService
    {
        private readonly IUnitStore _store;

        public ValidationService(IUnitStore store)
        {
            _store = store ?? throw new ArgumentNullException(nameof(store));
        }

        public List<string> Validate(UnitConversionRequest request)
        {
            var errors = new List<string>();

            if (request == null)
            {
                errors.Add("Request is required");
                return errors;
            }

            if (string.IsNullOrWhiteSpace(request.MeasurementType))
            {
                errors.Add("Measurement Type is required");
            }

            if (string.IsNullOrWhiteSpace(request.From))
            {
                errors.Add("From is required");
            }

            if (string.IsNullOrWhiteSpace(request.To))
            {
                errors.Add("To is required");
            }

            if (errors.Count > 0)
                return errors;

            // Check measurement type exists in store
            var unitsOfType = _store.GetByType(request.MeasurementType);
            if (unitsOfType == null || !unitsOfType.Any())
            {
                errors.Add("Invalid Unit Type: " + request.MeasurementType);
                return errors;
            }

            // Check units exist
            var fromDef = _store.Get(request.From);
            var toDef = _store.Get(request.To);

            if (fromDef == null)
                errors.Add("Unknown unit: " + request.From);
            if (toDef == null)
                errors.Add("Unknown unit: " + request.To);

            if (errors.Count > 0)
                return errors;

            // Ensure both units belong to the requested measurement type
            if (!string.Equals(fromDef.Type, request.MeasurementType, StringComparison.OrdinalIgnoreCase)
                || !string.Equals(toDef.Type, request.MeasurementType, StringComparison.OrdinalIgnoreCase))
            {
                errors.Add("Invalid from and to selection. Select from and to from same measurement type");
                return errors;
            }

            return errors;
        }
    }
}
