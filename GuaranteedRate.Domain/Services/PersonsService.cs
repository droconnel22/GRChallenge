using System.Collections.Generic;
using GuaranteedRate.Domain.Models.Person;
using GuaranteedRate.Domain.Models.Persons.Strategies;
using GuaranteedRate.Domain.ViewModels;

namespace GuaranteedRate.Domain.Services
{
    public class PersonsService : IPersonsService
    {
        public IPersonsService BuildPerson(string input)
        {
            throw new System.NotImplementedException();
        }

        public bool AddRecord()
        {
            throw new System.NotImplementedException();
        }

        public PersonsViewModel GetRecordsByGender()
        {
            throw new System.NotImplementedException();
        }

        public PersonsViewModel GetRecordsByBirthDate()
        {
            throw new System.NotImplementedException();
        }

        public PersonsViewModel GetRecordsByName()
        {
            throw new System.NotImplementedException();
        }
    }
}