using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuaranteedRate.Domain.Models.Person;

namespace GuaranteedRate.Domain.Models.Persons.Strategies
{
    internal interface IPersonsStrategy
    {
        Action<IEnumerable<IPerson>> GetByBirthDateCritera { get; }

        Action<IEnumerable<IPerson>> GetByGenderCriteria { get; }

        Action<IEnumerable<IPerson>> GetByLastNameCriteria { get; }
    }
}
