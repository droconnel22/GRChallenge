using System.Collections.Generic;
using GuaranteedRate.Domain.Models.Person;
using GuaranteedRate.Domain.Models.Utility;
using System;

namespace GuaranteedRate.Domain.Builders.Strategies
{
   
    internal sealed class ProcessMockDataForRestStrategy : IProcessRestStrategy
    {
       
        public IEnumerable<IPerson> MockRepository()
        {
            //Return list of Intereted
            return new IPerson[4]
            {
              new Person("oconnell","dennis",Genders.Male, Colors.Blue,new DateTime(1986,12,14)),
              new Person("solo","han",Genders.Male, Colors.Green,new DateTime(1977,5,7)),
              new Person("organa","leia",Genders.Female, Colors.Violet,new DateTime(1977,5,8)),
              new Person("mothma","mon",Genders.Female, Colors.Purple,new DateTime(1983,5,8))
            };
        }
    }
}