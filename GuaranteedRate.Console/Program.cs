using System;
using GuaranteedRate.Console.PresentationUtility;
using GuaranteedRate.Domain.Builders;
using GuaranteedRate.Domain.Models.Persons;
using GuaranteedRate.Domain.Models.Persons.Strategies;
using GuaranteedRate.Domain.Builders.Strategies;

namespace GuaranteedRate.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length != 3) throw new ArgumentException("Presenter requires 3 files.");
            Presentation.PrintHeaderText();
            IPersons persons = 
                PersonsFileBuilder
                .Initalize(new ProcessMultipleFilesStrategy())
                .SetRecordsFromFileWithDelimiter(args[0], ',')
                .SetRecordsFromFileWithDelimiter(args[1], '|')
                .SetRecordsFromFileWithDelimiter(args[2], ' ') 
                .LoadFromFiles()
                .SetStrategyForPersons(new ConsolePersonStrategy())
                .Build();

            persons.GetByGender().PrintRecords("Sorted By Gender");
            persons.GetByBirthDate().PrintRecords("Sorted By Birth Date");
            persons.GetByLastName().PrintRecords("Sorted By Last Name");
            Presentation.PrintClosingText();
        }
    }
}