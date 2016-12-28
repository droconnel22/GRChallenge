using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GuaranteedRate.Domain.Builders;
using GuaranteedRate.Domain.Builders.Interfaces;
using GuaranteedRate.Tests.TestUtility;
using GuaranteedRate.Domain.Models.Persons.Strategies;
using GuaranteedRate.Domain.Models.Persons;

namespace GuaranteedRate.Tests.Domain.Builders
{
    [TestClass]
    public class PersonsFileBuilderTests
    {

        [TestInitialize]
        public void SetUp()
        {

        }

        [TestMethod]
        public void PersonsFileBuilder_WhenInitalized_Always_Returns_IParseFromFileHolderInterface()
        {
            var result = PersonsFileBuilder
                .Initalize();
            Assert.IsTrue(result is IParseFromFileHolder);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PersonsFileBuilder_WhenAdding_InvalidFile_With_ValidDeliminator_Always_ThrowsException()
        {
            var result = PersonsFileBuilder
                            .Initalize()
                            .SetRecordsFromFileWithDelimiter(null, ',');
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PersonsFileBuilder_WhenAdding_EmptyString_For_File_With_ValidDeliminator_Always_ThrowsException()
        {
            var result = PersonsFileBuilder
                            .Initalize()
                            .SetRecordsFromFileWithDelimiter(string.Empty, ',');
        }

        [TestMethod]
        public void PersonsFileBuilder_WhenAdding_ValidFile_WithValidDeliminator_Always_Returns_AnotherInstance_IParseFromFileHolder()
        {
            var result = PersonsFileBuilder
                           .Initalize()
                           .SetRecordsFromFileWithDelimiter(PersonTestUtility.GetValidFilePath(),',');
            Assert.IsTrue(result is IParseFromFileHolder);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PersonsFileBuilder_WhenDoneLoadingFiles_WithNoLoadedFiles_Always_ThrowsInvalidOperationExpection()
        {
            var result = PersonsFileBuilder
                          .Initalize()
                          .LoadFromFiles();            
        }

        [TestMethod]
        public void PersonsFileBuilder_WhenDone_AddingRecordsWithDeliminator_Always_Returns_ISetPersonsStrategyHolder()
        {
            var result = PersonsFileBuilder
                          .Initalize()
                          .SetRecordsFromFileWithDelimiter(PersonTestUtility.GetValidFilePath(),',')
                          .LoadFromFiles();

            Assert.IsTrue(result is IParseFromFileHolder);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PersonsFileBuilder_When_SettingInvalidStrategy_Always_Throws_ArgumentNullException()
        {
            var result = PersonsFileBuilder
                            .Initalize()
                             .SetRecordsFromFileWithDelimiter(PersonTestUtility.GetValidFilePath(), ',')
                          .LoadFromFiles()
                          .SetStrategyForPersons(null);
        }

        [TestMethod]
        public void PersonFileBuilder_When_SettingValidStrategy_Always_Returns_IPersonBuilderInterface()
        {
            var result = PersonsFileBuilder
                            .Initalize()
                             .SetRecordsFromFileWithDelimiter(PersonTestUtility.GetValidFilePath(), ',')
                          .LoadFromFiles()
                          .SetStrategyForPersons(new ConsolePersonStrategy());

            Assert.IsTrue(result is IPersonsBuilder);
        }

        [TestMethod]
        //TODO Mock Loading Files Factory
        public void PersonFileBuilder_When_BuildingPerson_Always_Returns_ValidPersons()
        {
            var result = PersonsFileBuilder
                          .Initalize()
                          .SetRecordsFromFileWithDelimiter(PersonTestUtility.GetValidFilePath(), ',')
                          .LoadFromFiles()
                          .SetStrategyForPersons(new ConsolePersonStrategy())
                          .Build();

            Assert.IsTrue(result is Persons);
        }


    }
}
