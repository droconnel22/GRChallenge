using System.Collections.Generic;
using GuaranteedRate.Domain.Builders.Extenstions;
using GuaranteedRate.Domain.Builders.Interfaces;
using GuaranteedRate.Domain.Builders.Strategies;


namespace GuaranteedRate.Domain.Builders
{
    //Rest may require db access to some intializer, int his case we load mock data
    public class PersonsRestBuilder : 
        BasePersonsBuilder,
        IParseFromMockDataHolder
    {
        private readonly IProcessRestStrategy processRestStrategy;
        
        private PersonsRestBuilder()
            :base()
        {
           this.processRestStrategy = new ProcessMockDataForRestStrategy();
        }

        public static IParseFromMockDataHolder Initalize() => new PersonsRestBuilder();

        public ISetPersonsStrategyHolder LoadMockData()
        {
            this.loadedPersonCollection = 
                this.processRestStrategy
                .MockRepository();
            return this;
        }
    }
}