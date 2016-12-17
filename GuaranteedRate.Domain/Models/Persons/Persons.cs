using System;
using System.Collections.Generic;
using GuaranteedRate.Domain.Models.Person;
using GuaranteedRate.Domain.Models.Persons.Strategies;

namespace GuaranteedRate.Domain.Models.Persons
{
    public sealed class Persons : IPersons
    {
        private readonly IEnumerable<IPerson> collection;

        private readonly Func<IPersons, IEnumerable<IPerson>> genderAction;

        private readonly Func<IPersons, IEnumerable<IPerson>> birthDateAction;

        private readonly Func<IPersons, IEnumerable<IPerson>> lastNameAction;

        public Persons(IEnumerable<IPerson> persons, IPersonsStrategy strategy)
        {
            this.collection = persons;
            this.genderAction = strategy.SetGenderAction;
            this.birthDateAction = strategy.SetBirthDateAction;
            this.lastNameAction = strategy.SetLastNameAction;
        }

        public IEnumerable<IPerson> GetPersons() => this.collection;

        public IEnumerable<IPerson> GetByGender() => this.genderAction(this);

        public IEnumerable<IPerson> GetByBirthDate() => this.birthDateAction(this);

        public IEnumerable<IPerson> GetByLastName() => this.lastNameAction(this);
    }
}