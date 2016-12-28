using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GuaranteedRate.Domain.Services;
using GuaranteedRate.Domain.Models.Persons;
using GuaranteedRate.Domain.Models.Person;
using System.Collections.Generic;
using GuaranteedRate.Domain.ViewModels;
using GuaranteedRate.Tests.TestUtility;
using System.Linq;

namespace GuaranteedRate.Tests.Domain.Services
{
    [TestClass]
    public class PersonServiceTests
    {
        private IPersonsService personService;

        [TestInitialize]
        public void SetUp()
        {
            this.personService = new PersonsService();
            this.personService.Initalize(() => PersonTestUtility.GetSeededPersonsWithRestPersonsStrategy());
        }

        [TestMethod]
        public void PersonService_WhenConstructedButNotInitlized_AlwaysReturns_EmptyInstanceOfPersons()
        {
            var personService = new PersonsService();
            var personList = personService.Persons.GetPersons().ToList();

            Assert.IsTrue(personService.Persons is EmptyPersons);
            Assert.AreEqual(0, personList.Count);
        }

        [TestMethod]
        public void PersonService_WhenInitalized_WithConcreteMockFileBuilder_AlwaysReturns_PersonsWithMockData()
        {
            
            var result = this.personService.Persons;            
            var personList = result.GetPersons() as List<IPerson>;

            Assert.IsTrue(result is Persons);
            Assert.AreNotEqual(0, personList.Count);          
        }

        [TestMethod]
        public void PersonService_WhenGetRecordsByGender_AlwaysReturnsPersonsSortedByGender()
        {
            //Arrange
           //Done in initalizer.         

            //Act
            var personRecordsByGenderResult = this.personService.GetRecordsByGender();
            var resultList = personRecordsByGenderResult.Persons.ToList();

            //Assert
            Assert.IsTrue(personRecordsByGenderResult is PersonsViewModel);         
            PersonTestUtility.RunPersonsCompare(PersonTestUtility.GetPersonServicePersonsSortedByGenderExpected(), resultList);
        }

        [TestMethod]
        public void PersonService_WhenGetRecordsByBirthDate_AlwaysReturns_PersonsSortedByBirthDate()
        {
           
            var personRecordsByBirthDateResult = this.personService.GetRecordsByBirthDate();

            Assert.IsTrue(personRecordsByBirthDateResult is PersonsViewModel);
            PersonTestUtility.RunPersonsCompare(PersonTestUtility.GetPersonServicePersonsSortedByBirthDateExpected(), personRecordsByBirthDateResult.Persons.ToList());
        }

        [TestMethod]
        public void PersonsService_WhenGetRecordsByName_AlwaysReturns_PersonSortedByGroupedName()
        {
            var personRecordsByNameResult = this.personService.GetRecordsByName();

            Assert.IsTrue(personRecordsByNameResult is PersonsViewModel);
            PersonTestUtility.RunPersonsCompare(PersonTestUtility.GetPersonServicePersonsSortedByNameExpected(), personRecordsByNameResult.Persons.ToList());
        }

        [TestMethod]
        public void PersonService_WhenAdding_ValidPerson_AlwaysReturns_True()
        {
            
            bool result = this.personService.AddRecord(PersonTestUtility.GetValidPersonFromString());

            Assert.IsTrue(result);
            Assert.AreEqual(5, this.personService.Persons.GetPersons().ToList().Count());
        }

        [TestMethod]
        public void PersonService_WhenAdding_EmptyPerson_AlwaysReturns_False()
        {
            
            bool result = this.personService.AddRecord(PersonTestUtility.GetEmptyPersonFromString());

            Assert.IsFalse(result);        
            Assert.AreEqual(4, this.personService.Persons.GetPersons().ToList().Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PersonService_WhenAdding_InvalidModel_AlwaysThrows_Exception()
        {                  
            bool result = this.personService.AddRecord(null);
        }
    }
}
