using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuaranteedRate.Console.PresentationUtility;
using GuaranteedRate.Domain.Builders;
using GuaranteedRate.Domain.Models.Persons;
using GuaranteedRate.Domain.Models.Persons.Strategies;

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
                .Initalize()
                .SetRecordsFromFile(args[0])
                .WithDeliminatorForFile(',')
                .SetRecordsFromFile(args[1])
                .WithDeliminatorForFile('|')
                .SetRecordsFromFile(args[2])
                .WithDeliminatorForFile('_')
                .FinishLoadingFiles()
                .SetStrategyForPersons(new ConsolePersonStrategy())
                .Build();

            persons.GetByGender().PrintRecords();
            persons.GetByBirthDate().PrintRecords();
            persons.GetByLastName().PrintRecords();
            Presentation.PrintClosingText();
        }
    }
}