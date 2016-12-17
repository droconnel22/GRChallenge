using System.Collections.Generic;
using GuaranteedRate.Domain.Builders;
using GuaranteedRate.Domain.Builders.Interfaces;
using GuaranteedRate.Domain.Factories;
using GuaranteedRate.Domain.Models.Person;
using GuaranteedRate.Domain.Models.Persons;
using GuaranteedRate.Domain.Models.Persons.Extensions;
using GuaranteedRate.Domain.Models.Persons.Strategies;
using GuaranteedRate.Domain.ViewModels;

namespace GuaranteedRate.Domain.Services
{
    public class PersonsService : IPersonsService
    {
        private IPersons persons;

        public PersonsService()
        {
            this.persons = EmptyPersons.GetInstance;
        }

        public void Initalize()
        {
            this.persons = 
                PersonsRestBuilder
                .Initalize()
                .SetStrategyForPersons(new RestApiPersonsStrategy())
                .Build();
        }

        public bool AddRecord(string model) => 
            this.persons.AddPerson(PersonFactory.Create(model));
            

        public PersonsViewModel GetRecordsByGender() =>
            this.persons
                .GetByGender()
                .ToViewModel();

        public PersonsViewModel GetRecordsByBirthDate() =>
            this.persons
                .GetByBirthDate()
                .ToViewModel();

        public PersonsViewModel GetRecordsByName() => 
            this.persons
            .GetByLastName()
            .ToViewModel();
    }
}