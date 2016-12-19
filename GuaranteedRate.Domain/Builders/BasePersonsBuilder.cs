using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuaranteedRate.Domain.Builders.Interfaces;
using GuaranteedRate.Domain.Models.Person;
using GuaranteedRate.Domain.Models.Persons;
using GuaranteedRate.Domain.Models.Persons.Strategies;

namespace GuaranteedRate.Domain.Builders
{
    public abstract class BasePersonsBuilder :
        ISetPersonsStrategyHolder,
        IPersonsBuilder
    {

        protected IPersonsStrategy personsStrategy;

        protected IEnumerable<IPerson> loadedPersonCollection;

        protected BasePersonsBuilder()
        {
            this.personsStrategy = UnInitalizedPersonsStrategy.SetInstance;
            this.loadedPersonCollection = new List<IPerson>();
        }

        public virtual IPersonsBuilder SetStrategyForPersons(IPersonsStrategy personsStrategy)
        {
            //Here we request a reference type. We will not allow building for a null.
            if (personsStrategy == null) throw new ArgumentNullException(nameof(personsStrategy));
            this.personsStrategy = personsStrategy;
            return this;
        }

        public virtual IPersons Build() =>
              new Persons(this.loadedPersonCollection, this.personsStrategy);
      
    }
}
