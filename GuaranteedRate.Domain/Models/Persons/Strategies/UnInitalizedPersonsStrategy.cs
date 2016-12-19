using System;
using System.Collections.Generic;
using GuaranteedRate.Domain.Models.Person;

namespace GuaranteedRate.Domain.Models.Persons.Strategies
{
    internal sealed class UnInitalizedPersonsStrategy : IPersonsStrategy
    {
        [ThreadStatic]
        private static UnInitalizedPersonsStrategy instance;

        //Control Access
        private  UnInitalizedPersonsStrategy(){}

     
        public static IPersonsStrategy SetInstance
        {
            get
            {
                if(instance ==null)
                    instance = new UnInitalizedPersonsStrategy();
                return instance;
            }
        }

        public IEnumerable<IPerson> SetGenderAction(IPersons persons) => new List<IPerson>();

        public IEnumerable<IPerson> SetBirthDateAction(IPersons persons) => new List<IPerson>();

        public IEnumerable<IPerson> SetNameAction(IPersons persons) => new List<IPerson>();
    }
}