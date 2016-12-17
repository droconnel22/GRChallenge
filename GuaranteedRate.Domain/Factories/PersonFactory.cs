using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuaranteedRate.Domain.Models.Person;
using GuaranteedRate.Domain.Models.Utility;
using GuaranteedRate.Domain.ViewModels;

namespace GuaranteedRate.Domain.Factories
{
    internal static class PersonFactory
    {
        public static PersonViewModel Create(IPerson person) => new PersonViewModel()
        {
            DateOfBirth = person.DateoFBirth.ToShortDateString(),
            FavoriteColor = person.FavoriteColor.ToString(),
            FirstName = person.FirstName,
            LastName = person.LastName,
            Gender = person.Gender.ToString()

        };

        internal static IPerson Create(string model)
        {
            throw new NotImplementedException();
        }
    }
}
