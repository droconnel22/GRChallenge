using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GuaranteedRate.Web.Controllers;

namespace GuaranteedRate.Tests.Web
{
    [TestClass]
    public class RecordControllerTests
    {
        private RecordsController recordsController = new RecordsController();

        [TestMethod]
        public void WhenGetRequest_ForGender_AlwaysReturnsJsonListOfRecordsSortedByGender()
        {
          //  var result = recordsController.Gender();
        }
    }
}
