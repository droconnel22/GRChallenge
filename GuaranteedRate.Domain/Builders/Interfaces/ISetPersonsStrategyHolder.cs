using GuaranteedRate.Domain.Models.Persons.Strategies;

namespace GuaranteedRate.Domain.Builders.Interfaces
{
    public interface ISetPersonsStrategyHolder
    {
        IPersonsBuilder SetStrategyForPersons(IPersonsStrategy personsStrategy);
    }
}