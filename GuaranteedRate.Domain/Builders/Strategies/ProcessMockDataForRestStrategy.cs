using System.Collections.Generic;
using GuaranteedRate.Domain.Models.Person;

namespace GuaranteedRate.Domain.Builders.Strategies
{
   
    internal sealed class ProcessMockDataForRestStrategy : IProcessRestStrategy
    {
       
        public IEnumerable<IPerson> MockRepository()
        {
            //Return list of Intereted
            throw new System.NotImplementedException();
        }
    }
}