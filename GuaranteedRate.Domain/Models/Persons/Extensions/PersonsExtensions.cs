using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuaranteedRate.Domain.Factories;
using GuaranteedRate.Domain.ViewModels;

namespace GuaranteedRate.Domain.Models.Persons.Extensions
{
    internal static class PersonsExtensions
    {
        public static PersonsViewModel ToViewModel(this IPersons persons) => new PersonsViewModel(persons.GetPersons().Select(PersonFactory.Create));
    }
}
