using GuaranteedRate.Domain.Builders;
using GuaranteedRate.Domain.Builders.Interfaces;
using GuaranteedRate.Domain.Builders.Strategies;
using GuaranteedRate.Domain.Models.Persons;
using GuaranteedRate.Domain.Models.Persons.Strategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuaranteedRate.Tests.Domain.Builders
{
    [TestClass]
    public class PersonRestBuilderTests
    {
                       
        /*
         *The builder pattern implements a fluent API that forces the client to follow a specific set of instructions
         * in a specific order. In the API it is very simplistic, but unit testing best practices are still being set.
         * 
         * In this case we can never build a Persons without the proper required arguments in place.
         * This is enforced by the specific steps returned from each interface.
         * 
         * The unit testing here attempts to examine the building process in depth. It also attempts to
         * enforce a specific builder order that should augmentation occur will be forced to update in
         * regresstion testing.
         */       

             
        [TestMethod]
        public void PersonsRestBuilder_When_OnlyInitalized_Always_Returns_InterfaceForMockData()
        {
            var result = PersonsRestBuilder
                .Initalize();
            Assert.IsTrue(result is IParseFromMockDataHolder);
        }

        [TestMethod]
        public void PersonsRestBuilder_When_LoadMockData_Always_Returns_InterfaceToSetStrategy()
        {
            var result = PersonsRestBuilder
                                .Initalize()
                                .LoadMockData();
            Assert.IsTrue(result is ISetPersonsStrategyHolder);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PersonsRestBuilder_WhenGettingMockedData_WithNullStrategy_Always_ThrowsException()
        {
            var result = PersonsRestBuilder
                .Initalize()
                .LoadMockData()
                .SetStrategyForPersons(null)
                .Build();
        }

        [TestMethod]
        public void PersonsRestBuilder_When_SetStrategy_WithValidStrategy_Always_Returns_IPErsonBuilderInterface()
        {
            var result =
                PersonsRestBuilder
                    .Initalize()
                    .LoadMockData()
                    .SetStrategyForPersons(new RestApiPersonsStrategy())
                    .Build();

            Assert.IsNotNull(result);
            Assert.IsTrue(result is Persons);
            Assert.AreEqual(4, result.GetPersons().ToList().Count);
        }
    }
}
