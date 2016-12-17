using GuaranteedRate.Domain.Builders.Interfaces;
using GuaranteedRate.Domain.Models.Persons;
using GuaranteedRate.Domain.Models.Persons.Strategies;

namespace GuaranteedRate.Domain.Builders
{
    public class PersonsFileBuilder : 
        ISetDeliminatorHolder,
        IParseFromFileHolder, 
        ISetPersonsStrategyHolder,
        IPersonsBuilder
    {
        private IPersonsStrategy personsStrategy;

        //Control Entry Point.
        private PersonsFileBuilder()
        {
            this.personsStrategy = UnInitalizedPersonsStrategy.SetInstance;
        }

        public static IParseFromFileHolder Initalize()
        {
             return new PersonsFileBuilder();
        }

        public IParseFromFileHolder WithDeliminatorForFile(char deliminator)
        {
            throw new System.NotImplementedException();
        }

        public ISetDeliminatorHolder SetRecordsFromFile(string filePath)
        {
            throw new System.NotImplementedException();
        }

        public ISetPersonsStrategyHolder FinishLoadingFiles()
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