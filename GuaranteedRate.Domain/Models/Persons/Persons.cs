using System;
using System.Collections.Generic;
using GuaranteedRate.Domain.Models.Person;
using GuaranteedRate.Domain.Models.Persons.Strategies;

namespace GuaranteedRate.Domain.Models.Persons
{
    internal sealed class Persons : IPersons
    {
        private readonly ICollection<IPerson> collection;

        private readonly Func<IPersons, IEnumerable<IPerson>> genderAction;

        private readonly Func<IPersons, IEnumerable<IPerson>> birthDateAction;

        private readonly Func<IPersons, IEnumerable<IPerson>> lastNameAction;

        public Persons(IEnumerable<IPerson> persons, IPersonsStrategy strategy)
        {
            this.collection = new List<IPerson>(persons);
            this.genderAction = strategy.SetGenderAction;
            this.birthDateAction = strategy.SetBirthDateAction;
            this.lastNameAction = strategy.SetNameAction;
        }

        public IEnumerable<IPerson> GetPersons() => this.collection;

        public IEnumerable<IPerson> GetByGender() => this.genderAction(this);

        public IEnumerable<IPerson> GetByBirthDate() => this.birthDateAction(this);

        public IEnumerable<IPerson> GetByLastName() => this.lastNameAction(this);

        public bool AddPerson(IPerson person)
        {
            if (person is EmptyPerson) return false;
            this.collection.Add(person);
            return true;
        }
    }
}