using GuaranteedRate.Domain.Builders.Interfaces;
using GuaranteedRate.Domain.Models.Persons;
using GuaranteedRate.Domain.Models.Persons.Strategies;

namespace GuaranteedRate.Domain.Builders
{
    public class PersonsRestBuilder
        :IParseFromPostBodyHolder,
            ISetPersonsStrategyHolder,
            IPersonsBuilder
        {

        private PersonsRestBuilder()
        {
            
        }

        public static IParseFromPostBodyHolder Initalize()
        {
            return new PersonsRestBuilder();
        }

        public IParseFromPostBodyHolder SetDeliminatorForPostBody(char deliminator)
        {
            throw new System.NotImplementedException();
        }

        public IPersons SetRecordFromPostBody(string model)
        {
            throw new System.NotImplementedException();
        }

        public IPersonsBuilder SetStrategyForPersons(IPersonsStrategy personsStrategy)
        {
            throw new System.NotImplementedException();
        }

        public IPersons Build()
        {
            throw new System.NotImplementedException();
        }
    }
}