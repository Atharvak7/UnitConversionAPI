using System;
using System.Collections.Generic;

namespace UnitConversionAPI.Service
{
    public class UnitConversionResult
    {
        public double? Value { get; set; }
        public List<string> Errors { get; set; } = new();
    }

    public class UnitConversionService
    {
        private readonly IUnitStore _store;
        private readonly ConverterRegistry _registry;

        public UnitConversionService(IUnitStore store, ConverterRegistry registry)
        {
            _store = store;
            _registry = registry;
        }

        public UnitConversionResult Convert(string unitType, string from, string to, double value)
        {
            var result = new UnitConversionResult();
            var fromDef = _store.Get(from);
            var toDef = _store.Get(to);

            if (!_registry.TryResolve(fromDef, toDef, out var converter, out var resolveError))
            {
                result.Errors.Add(resolveError ?? "No converter available");
                return result;
            }

            var converted = converter.Convert(fromDef, toDef, value);
            result.Value = converted;
            
            return result;
        }
    }
}


