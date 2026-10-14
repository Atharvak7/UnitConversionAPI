using System.Collections.Generic;
using System.Linq;

namespace UnitConversionAPI.Service
{
     public class ConverterRegistry
     {
         private readonly List<IUnitConverter> _converters;

         public ConverterRegistry(IEnumerable<IUnitConverter> converters)
         {
             _converters = converters?.ToList() ?? new List<IUnitConverter>();
         }

         public bool TryResolve(UnitDefinition from, UnitDefinition to, out IUnitConverter? converter, out string? error)
         {
             converter = null;
             error = null;

             var matches = _converters
                 .Where(c => c.SupportedTypes.Contains(from.Type, StringComparer.OrdinalIgnoreCase)
                            && c.SupportedTypes.Contains(to.Type, StringComparer.OrdinalIgnoreCase)
                            && c.CanConvert(from, to))
                 .ToList();

             if (matches.Count == 1)
             {
                 converter = matches[0];
                 return true;
             }

             if (matches.Count > 1)
             {
                 error = $"Multiple converters available for {from.Type} -> {to.Type}";
                 return false;
             }

             error = $"No converter available for {from.Type} -> {to.Type}";
             return false;
         }
     }
}