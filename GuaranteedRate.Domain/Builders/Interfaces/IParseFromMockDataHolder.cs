using GuaranteedRate.Domain.Models.Persons;

namespace GuaranteedRate.Domain.Builders.Interfaces
{
    public interface IParseFromMockDataHolder
    {
        ISetPersonsStrategyHolder LoadMockData();
    }
}
