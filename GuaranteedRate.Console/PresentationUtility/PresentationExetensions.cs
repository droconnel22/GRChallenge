namespace GuaranteedRate.Console.PresentationUtility
{
    using System.Collections.Generic;
    using GuaranteedRate.Domain.Models.Person;

    internal static class PresentationExetensions
    {
        public static void PrintRecords(this IEnumerable<IPerson> persons)
        {
            foreach (var person in persons)
            {
                System.Console.WriteLine($"Record: {person.LastName}, {person.FirstName} {person.Gender}, {person.FavoriteColor}, {person.DateoFBirth.ToShortDateString()}");
            }
        }
    }
}
