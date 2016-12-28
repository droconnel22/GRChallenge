using GuaranteedRate.Domain.Models.Person;
using GuaranteedRate.Domain.Models.Persons;
using GuaranteedRate.Domain.Models.Utility;
using GuaranteedRate.Domain.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuaranteedRate.Tests.TestUtility
{
    internal static class PersonTestUtility
    {
        public static List<IPerson> GetPersonServicePersonsSortedByGenderExpected() =>
            new List<IPerson>()
            {
                  new Person("organa","leia",Genders.Female, Colors.Violet,new DateTime(1977,5,8)),
                  new Person("mothma","mon",Genders.Female, Colors.Purple,new DateTime(1983,5,8)),
                  new Person("oconnell","dennis",Genders.Male, Colors.Blue,new DateTime(1986,12,14)),
                  new Person("solo","han",Genders.Male, Colors.Green,new DateTime(1977,5,7))
            };

        public static List<IPerson> GetPersonServicePersonsSortedByBirthDateExpected() =>
            new List<IPerson>()
            {
                 new Person("solo","han",Genders.Male, Colors.Green,new DateTime(1977,5,7)),
                  new Person("organa","leia",Genders.Female, Colors.Violet,new DateTime(1977,5,8)),
                    new Person("mothma","mon",Genders.Female, Colors.Purple,new DateTime(1983,5,8)),
                     new Person("oconnell","dennis",Genders.Male, Colors.Blue,new DateTime(1986,12,14))
            };

        public static List<IPerson> GetPersonServicePersonsSortedByNameExpected() =>
            new List<IPerson>()
            {
                new Person("mothma","mon",Genders.Female, Colors.Purple,new DateTime(1983,5,8)),
                new Person("oconnell","dennis",Genders.Male, Colors.Blue,new DateTime(1986,12,14)),
              new Person("organa","leia",Genders.Female, Colors.Violet,new DateTime(1977,5,8)),
                 new Person("solo","han",Genders.Male, Colors.Green,new DateTime(1977,5,7))
                  
                    

            };


        public static string GetValidPersonFromString() => "Dennis|O'Connell|Male|Blue|12/14/1986";

        public static string GetEmptyPersonFromString() => "O'Connell|Male|Blue|12/14/1986";

        public static IPersons GetSeededPersons() => new Persons(new IPerson[4]
            {
              new Person("oconnell","dennis",Genders.Male, Colors.Blue,new DateTime(1986,12,14)),
              new Person("solo","han",Genders.Male, Colors.Green,new DateTime(1977,5,7)),
              new Person("organa","leia",Genders.Female, Colors.Violet,new DateTime(1977,5,8)),
              new Person("mothma","mon",Genders.Female, Colors.Purple,new DateTime(1983,5,8))
            }, null);

        public static void RunPersonsCompare(List<IPerson> expectedList, List<PersonViewModel> resultList)
        {
            for (int i = 0; i < resultList.Count; i++)
            {
                Assert.AreEqual(expectedList[i].FirstName, resultList[i].FirstName);
                Assert.AreEqual(expectedList[i].LastName, resultList[i].LastName);
                Assert.AreEqual(expectedList[i].FavoriteColor.ToString(), resultList[i].FavoriteColor);
                Assert.AreEqual(expectedList[i].Gender.ToString(), resultList[i].Gender);
                Assert.AreEqual(expectedList[i].DateoFBirth.ToShortDateString(), resultList[i].DateOfBirth);
            }
        }

        
    }
}
