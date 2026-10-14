namespace UnitConversionAPI.Service
{
    public interface IUnitStore
    {
        UnitDefinition? Get(string id);
        IEnumerable<UnitDefinition> GetByType(string type);
        void Add(UnitDefinition def);
    }
}
