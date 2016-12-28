using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GuaranteedRate.Domain.Builders;
using GuaranteedRate.Domain.Builders.Interfaces;
using GuaranteedRate.Tests.TestUtility;
using GuaranteedRate.Domain.Models.Persons.Strategies;
using GuaranteedRate.Domain.Models.Persons;
using GuaranteedRate.Domain.Builders.Strategies;
using System.Collections.Generic;
using Rhino.Mocks;

namespace GuaranteedRate.Tests.Domain.Builders
{
    [TestClass]
    public class PersonsFileBuilderTests
    {
        private IParseFromFileHolder initalizedPersonFileBuilder;

        private IProcessFileStrategy mockFileStrategy;

         [TestInitialize]
        public void SetUp()
        {
            this.mockFileStrategy = MockRepository.GenerateMock<IProcessFileStrategy>();

            this.mockFileStrategy.Stub(mfb => mfb.AddFilePlan(Arg<string>.Is.Null, Arg<char>.Is.Anything)).Throw(new ArgumentException());
            this.mockFileStrategy.Stub(mfb => mfb.AddFilePlan(Arg<string>.Matches(p => p == string.Empty), Arg<char>.Is.Anything)).Throw(new ArgumentException());
            this.mockFileStrategy.Stub(mfb => mfb.AddFilePlan(Arg<string>.Is.NotNull, Arg<char>.Is.Anything));

            this.mockFileStrategy.Stub(mfs => mfs.ReadAllFiles()).Return(new List<string[]>());
            this.initalizedPersonFileBuilder = PersonsFileBuilder
                                                  .Initalize(this.mockFileStrategy);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PersonsFileBuilder_WhenInitalized_WithInvalidStrategy_Always_Throws_ArgumentNullException()
        {
            var result = PersonsFileBuilder
                .Initalize(null);
           
        }

        [TestMethod]
        public void PersonsFileBuilder_WhenInitalized_WithValidFileStrategy_Always_Returns_IParseFromFileHolderInterface()
        {           
            var result = this.initalizedPersonFileBuilder;
            Assert.IsTrue(result is IParseFromFileHolder);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PersonsFileBuilder_WhenAdding_InvalidFile_With_ValidDeliminator_Always_ThrowsException()
        {
            var result = this.initalizedPersonFileBuilder
                            .SetRecordsFromFileWithDelimiter(null, ',');
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PersonsFileBuilder_WhenAdding_EmptyString_For_File_With_ValidDeliminator_Always_ThrowsException()
        {
            var result = this.initalizedPersonFileBuilder
                            .SetRecordsFromFileWithDelimiter(string.Empty, ',');
        }

        [TestMethod]
        public void PersonsFileBuilder_WhenAdding_ValidFile_WithValidDeliminator_Always_Returns_AnotherInstance_IParseFromFileHolder()
        {
            var result = this.initalizedPersonFileBuilder
                           .SetRecordsFromFileWithDelimiter(PersonTestUtility.GetValidFilePath(),',');
            Assert.IsTrue(result is IParseFromFileHolder);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PersonsFileBuilder_WhenDoneLoadingFiles_WithNoLoadedFiles_Always_ThrowsInvalidOperationExpection()
        {
           var emptyMockFileStrategy = MockRepository.GenerateMock<IProcessFileStrategy>();

            emptyMockFileStrategy.Stub(mfs => mfs.ReadAllFiles()).Throw(new InvalidOperationException());

            var result = PersonsFileBuilder
                .Initalize(emptyMockFileStrategy)
                          .LoadFromFiles();            
        }

        [TestMethod]
        public void PersonsFileBuilder_WhenDone_AddingRecordsWithDeliminator_Always_Returns_ISetPersonsStrategyHolder()
        {
            
            var result = this.initalizedPersonFileBuilder
                          .SetRecordsFromFileWithDelimiter(PersonTestUtility.GetValidFilePath(),',')
                          .LoadFromFiles();

            Assert.IsTrue(result is IParseFromFileHolder);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PersonsFileBuilder_When_SettingInvalidStrategy_Always_Throws_ArgumentNullException()
        {
            var result = this.initalizedPersonFileBuilder
                             .SetRecordsFromFileWithDelimiter(PersonTestUtility.GetValidFilePath(), ',')
                          .LoadFromFiles()
                          .SetStrategyForPersons(null);
        }

        [TestMethod]
        public void PersonFileBuilder_When_SettingValidStrategy_Always_Returns_IPersonBuilderInterface()
        {
            var result = this.initalizedPersonFileBuilder
                             .SetRecordsFromFileWithDelimiter(PersonTestUtility.GetValidFilePath(), ',')
                          .LoadFromFiles()
                          .SetStrategyForPersons(new ConsolePersonStrategy());

            Assert.IsTrue(result is IPersonsBuilder);
        }

        [TestMethod]
        //TODO Mock Loading Files Factory
        public void PersonFileBuilder_When_BuildingPerson_Always_Returns_ValidPersons()
        {
            var result = this.initalizedPersonFileBuilder
                          .SetRecordsFromFileWithDelimiter(PersonTestUtility.GetValidFilePath(), ',')
                          .LoadFromFiles()
                          .SetStrategyForPersons(new ConsolePersonStrategy())
                          .Build();

            Assert.IsTrue(result is Persons);
        }


    }
}
