using System;
using System.Collections.Generic;
using System.Linq;
using GuaranteedRate.Domain.Models.Person;

namespace GuaranteedRate.Domain.Models.Persons.Strategies
{
    public class ConsolePersonStrategy : IPersonsStrategy
    {
        
        //sorted by gender (females before males) then by last name ascending.
        public IEnumerable<IPerson> SetGenderAction(IPersons persons) =>
            persons.GetPersons().
            OrderBy(p => p.Gender)
            .ThenBy(p => p.LastName);

        //– sorted by birth date, ascending.
        public IEnumerable<IPerson> SetBirthDateAction(IPersons persons)
            => persons.GetPersons().OrderBy(p => p.DateoFBirth);


        //– sorted by last name, descending.
        public IEnumerable<IPerson> SetNameAction(IPersons persons) => 
            persons.GetPersons().OrderByDescending(p => p.LastName);
    }
}