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

        public static IPerson Create(string model,char deliminator) => CreatePerson(model?.Split(deliminator));


        public static IEnumerable<IPerson> Create(IEnumerable<string[]> rawFileArray) => rawFileArray.Select(CreatePerson);

        /*You may assume that the delimiters (commas, pipes and spaces) do not appear anywhere in the data values themselves. */
        private static IPerson CreatePerson(string[] model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            if (model.Length < 5) return EmptyPerson.GetInstance;
            return new Person(model[0], model[1], TranslateToGender(model[2]), TranslateToColor(model[3]), TranslateToDateTime(model[4]));
        }

       

        private static Genders TranslateToGender(string input)
        {
            Genders result;
            if (!Genders.TryParse(input, out result))
            {
                throw new ArgumentException("Failed to parse gender from " + input);
            }
            return result;
        }

        private static Colors TranslateToColor(string input)
        {
            Colors result;
            if (!Colors.TryParse(input, out result))
            {
                throw  new ArgumentException("Failed to parse color from "+ input);
            }
            
            return result;
        }

        private static DateTime TranslateToDateTime(string input)
        {
            DateTime result;
            if (!DateTime.TryParse(input, out result))
            {
                throw new ArgumentException("Failed to parse datetime from" + input);
            }
            return result;
        }
    }
   
}
