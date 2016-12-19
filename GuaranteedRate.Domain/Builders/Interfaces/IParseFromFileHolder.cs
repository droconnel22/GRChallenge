using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuaranteedRate.Domain.Models.Persons;

namespace GuaranteedRate.Domain.Builders.Interfaces
{
    public interface IParseFromFileHolder
    {
        IParseFromFileHolder SetRecordsFromFileWithDelimiter(string filePath, char delimiter);

        ISetPersonsStrategyHolder LoadFromFiles();}
}
