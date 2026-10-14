using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace UnitConversionAPI.Service
{
    public class InMemoryUnitStore : IUnitStore
    {
        private readonly ConcurrentDictionary<string, UnitDefinition> _store = new(StringComparer.OrdinalIgnoreCase);

        public InMemoryUnitStore()
        {
            Add(new UnitDefinition { Id = "meter", Type = "Length", ToBaseFactor = 1 });
            Add(new UnitDefinition { Id = "km", Type = "Length", ToBaseFactor = 1000 });
            Add(new UnitDefinition { Id = "cm", Type = "Length", ToBaseFactor = 0.01 });
            Add(new UnitDefinition { Id = "mm", Type = "Length", ToBaseFactor = 0.001 });
            Add(new UnitDefinition { Id = "mile", Type = "Length", ToBaseFactor = 1609.344 });
            Add(new UnitDefinition { Id = "foot", Type = "Length", ToBaseFactor = 0.3048 });
            Add(new UnitDefinition { Id = "inch", Type = "Length", ToBaseFactor = 0.0254 });

            Add(new UnitDefinition { Id = "kg", Type = "Mass", ToBaseFactor = 1 });
            Add(new UnitDefinition { Id = "g", Type = "Mass", ToBaseFactor = 0.001 });
            Add(new UnitDefinition { Id = "mg", Type = "Mass", ToBaseFactor = 0.000001 });
            Add(new UnitDefinition { Id = "tonne", Type = "Mass", ToBaseFactor = 1000 });
            Add(new UnitDefinition { Id = "pound", Type = "Mass", ToBaseFactor = 0.45359237 });
            Add(new UnitDefinition { Id = "ounce", Type = "Mass", ToBaseFactor = 0.028349523125 });

            Add(new UnitDefinition { Id = "second", Type = "Time", ToBaseFactor = 1 });
            Add(new UnitDefinition { Id = "minute", Type = "Time", ToBaseFactor = 60 });
            Add(new UnitDefinition { Id = "hour", Type = "Time", ToBaseFactor = 3600 });

            // Temperature uses affine conversion; keep definitions for lookup
            Add(new UnitDefinition { Id = "celsius", Type = "Temperature", ToBaseFactor = 1 });
            Add(new UnitDefinition { Id = "fahrenheit", Type = "Temperature", ToBaseFactor = 1 });
            Add(new UnitDefinition { Id = "kelvin", Type = "Temperature", ToBaseFactor = 1 });

        }

        public UnitDefinition? Get(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return null;

            if (_store.TryGetValue(id, out var def))
                return def;

            // try lowercased lookup
            if (_store.TryGetValue(id.ToLowerInvariant(), out def))
                return def;

            return null;
        }

        public IEnumerable<UnitDefinition> GetByType(string type)
        {
            return _store.Values.Where(u => string.Equals(u.Type, type, StringComparison.OrdinalIgnoreCase));
        }

        public void Add(UnitDefinition def)
        {
            if (def == null || string.IsNullOrWhiteSpace(def.Id))
                return;

            _store[def.Id] = def;
        }

    }
}
