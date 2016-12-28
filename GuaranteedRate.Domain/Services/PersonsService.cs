using System.Collections.Generic;
using GuaranteedRate.Domain.Builders;
using GuaranteedRate.Domain.Builders.Interfaces;
using GuaranteedRate.Domain.Factories;
using GuaranteedRate.Domain.Models.Person;
using GuaranteedRate.Domain.Models.Persons;
using GuaranteedRate.Domain.Models.Persons.Extensions;
using GuaranteedRate.Domain.Models.Persons.Strategies;
using GuaranteedRate.Domain.ViewModels;
using System;

namespace GuaranteedRate.Domain.Services
{
    public class PersonsService : IPersonsService
    {
        public IPersons Persons { get; private set; }

        private readonly IPersonsBuilder personsBuilder;
                
        public PersonsService()
        {
            this.Persons = EmptyPersons.GetInstance;                    
        }


        public void Initalize(Func<IPersons> initalizer)
        {
            this.Persons = initalizer();     
               
        }

        public bool AddRecord(string model) => 
            this.Persons.AddPerson(PersonFactory.Create(model,'|'));
            

        public PersonsViewModel GetRecordsByGender() =>
            this.Persons
                .GetByGender()
                .ToViewModel();

        public PersonsViewModel GetRecordsByBirthDate() =>
            this.Persons
                .GetByBirthDate()
                .ToViewModel();

        public PersonsViewModel GetRecordsByName() => 
            this.Persons
            .GetByLastName()
            .ToViewModel();
    }
}