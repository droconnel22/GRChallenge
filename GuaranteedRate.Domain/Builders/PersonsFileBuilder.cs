using System;
using System.Collections.Generic;
using System.IO;
using GuaranteedRate.Domain.Builders.Extenstions;
using GuaranteedRate.Domain.Builders.Interfaces;
using GuaranteedRate.Domain.Builders.Strategies;
using GuaranteedRate.Domain.Factories;
using GuaranteedRate.Domain.Models.Person;
using GuaranteedRate.Domain.Models.Persons;
using GuaranteedRate.Domain.Models.Persons.Strategies;

namespace GuaranteedRate.Domain.Builders
{
    public class PersonsFileBuilder : 
        IParseFromFileHolder, 
        ISetPersonsStrategyHolder,
        IPersonsBuilder
    {
        private IPersonsStrategy personsStrategy;

        private IProcessFileStrategy _fileStrategy;

        private IEnumerable<IPerson> loadedPersonCollection;

        //Control Entry Point.
        private PersonsFileBuilder()
        {
            this._fileStrategy = new ProcessMultipleFilesStrategy();
            this.personsStrategy = UnInitalizedPersonsStrategy.SetInstance;
            this.loadedPersonCollection = new List<IPerson>();
          
        }

        public static IParseFromFileHolder Initalize() => new PersonsFileBuilder();

        public IParseFromFileHolder SetRecordsFromFileWithDelimiter(string filePath, char deliminator)
        {
           if(!File.Exists(filePath)) throw new ArgumentException("File does not exist from " + filePath);
           this._fileStrategy.AddFilePlan(filePath,deliminator);
           return this;
        }
       
        public ISetPersonsStrategyHolder LoadFromFiles()
        {
            this.loadedPersonCollection = 
                this._fileStrategy
                .ReadAllFiles()
                .InterpretLineToPerson();
            return this;
        }

        public IPersonsBuilder SetStrategyForPersons(IPersonsStrategy personsStrategy)
        {
            //Here we request a reference type. We will not allow building for a null.
            if(personsStrategy == null) throw new ArgumentNullException(nameof(personsStrategy));
            this.personsStrategy = personsStrategy;
            return this;
        }

        public IPersons Build() => 
            new Persons(this.loadedPersonCollection, this.personsStrategy);
    }
}