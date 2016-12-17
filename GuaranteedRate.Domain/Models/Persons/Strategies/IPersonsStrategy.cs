using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuaranteedRate.Domain.Models.Person;

namespace GuaranteedRate.Domain.Models.Persons.Strategies
{
    public interface IPersonsStrategy
    {

        IEnumerable<IPerson> SetGenderAction(IPersons persons);

        IEnumerable<IPerson> SetBirthDateAction(IPersons persons);

        IEnumerable<IPerson> SetNameAction(IPersons persons);
    }
}
