using System;
using System.IO;
using GuaranteedRate.Domain.Builders.Extenstions;
using GuaranteedRate.Domain.Builders.Interfaces;
using GuaranteedRate.Domain.Builders.Strategies;


namespace GuaranteedRate.Domain.Builders
{
    public class PersonsFileBuilder : 
        BasePersonsBuilder,
        IParseFromFileHolder
    {
       
        private readonly IProcessFileStrategy fileStrategy;

        //Control Entry Point.
        //Todo, outside scope, but in production Process Multiple Files Strategy would be Injected via IoC
        private PersonsFileBuilder(IProcessFileStrategy strategy)
            :base() 
        {
            //Default
            if (strategy == null) throw new ArgumentNullException(nameof(strategy));
            this.fileStrategy = strategy;
        }      

        public static IParseFromFileHolder Initalize(IProcessFileStrategy strategy) => new PersonsFileBuilder(strategy);

        public IParseFromFileHolder SetRecordsFromFileWithDelimiter(string filePath, char deliminator)
        {
           if(!File.Exists(filePath)) throw new ArgumentException("File does not exist from " + filePath);
           this.fileStrategy.AddFilePlan(filePath,deliminator);
           return this;
        }
       
        public ISetPersonsStrategyHolder LoadFromFiles()
        {
            base.loadedPersonCollection = 
                this.fileStrategy
                .ReadAllFiles()
                .InterpretLineToPerson();
            return this;
        }
    }
}