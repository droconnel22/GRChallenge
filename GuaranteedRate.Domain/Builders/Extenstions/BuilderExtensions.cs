using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuaranteedRate.Domain.Factories;
using GuaranteedRate.Domain.Models.Person;

namespace GuaranteedRate.Domain.Builders.Extenstions
{
    internal static class BuilderExtensions
    {
        public static IEnumerable<IPerson> InterpretLineToPerson(this IEnumerable<string[]> rawFileLines) => PersonFactory.Create(rawFileLines).ToList();
    }
}
