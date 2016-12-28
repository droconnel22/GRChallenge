using GuaranteedRate.Domain.Builders;
using GuaranteedRate.Domain.Builders.Interfaces;
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

        private IParseFromMockDataHolder personRestBuilder;

        [TestInitialize]
        public void SetUp()
        {
            var personRestBuilder = PersonsRestBuilder.Initalize();
        }
    }
}
