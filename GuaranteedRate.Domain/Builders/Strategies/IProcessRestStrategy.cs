using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuaranteedRate.Domain.Models.Person;

namespace GuaranteedRate.Domain.Builders.Strategies
{
    internal interface IProcessRestStrategy
    {
        IEnumerable<IPerson> MockRepository();
    }
}
