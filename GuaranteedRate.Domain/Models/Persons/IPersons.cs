using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuaranteedRate.Domain.Models.Person;

namespace GuaranteedRate.Domain.Models.Persons
{
    public interface IPersons
    {
        IEnumerable<IPerson> GetPersons();

        IEnumerable<IPerson> GetByGender();

        IEnumerable<IPerson> GetByBirthDate();

        IEnumerable<IPerson> GetByLastName();
    }
}
