using System;
using System.Collections.Generic;
using System.Linq;
using GuaranteedRate.Domain.Models.Person;

namespace GuaranteedRate.Domain.Models.Persons.Strategies
{
    public class RestApiPersonsStrategy : IPersonsStrategy
    {
        //returns records sorted by gender
        public IEnumerable<IPerson> SetGenderAction(IPersons persons) =>
            persons.GetPersons().OrderBy(p => p.Gender);

        //returns records sorted by birthdate
        public IEnumerable<IPerson> SetBirthDateAction(IPersons persons) =>
            persons.GetPersons().OrderBy(p => p.DateoFBirth);

        //returns records sorted by name (??? -> combined? or First Name)
        public IEnumerable<IPerson> SetNameAction(IPersons persons) =>
            persons.GetPersons()
              .GroupBy(p => p.LastName + ", " + p.FirstName)
              .OrderBy(p => p.Key)
              .SelectMany(p => p);
    }
}