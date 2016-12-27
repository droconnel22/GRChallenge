using System;
using System.Collections.Generic;
using GuaranteedRate.Domain.Models.Person;

namespace GuaranteedRate.Domain.Models.Persons
{
    public sealed class EmptyPersons : IPersons
    {
        [ThreadStatic]
        private static IPersons instance;

        private EmptyPersons() { }

        public static IPersons GetInstance
        {
            get
            {
                if(instance == null)
                    instance = new EmptyPersons();
                return instance;
            }
        }

        public IEnumerable<IPerson> GetPersons() => new List<IPerson>();

        public IEnumerable<IPerson> GetByGender() => new List<IPerson>();

        public IEnumerable<IPerson> GetByBirthDate() => new List<IPerson>();

        public IEnumerable<IPerson> GetByLastName() => new List<IPerson>();
        public bool AddPerson(IPerson person) => false;
    }
}