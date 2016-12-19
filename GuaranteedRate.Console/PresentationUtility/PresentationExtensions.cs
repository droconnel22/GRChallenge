namespace GuaranteedRate.Console.PresentationUtility
{
    using System.Collections.Generic;
    using GuaranteedRate.Domain.Models.Person;

    internal static class PresentationExtensions
    {
        public static void PrintRecords(this IEnumerable<IPerson> persons, string message = null)
        {
            System.Console.WriteLine("Printing Records......." + message);
            foreach (var person in persons)
            {
                System.Console.WriteLine($"Record: {person.LastName}, {person.FirstName} {person.Gender}, {person.FavoriteColor}, {person.DateoFBirth.ToShortDateString()}");
            }
            System.Console.WriteLine("Finished Printing Records.......");
        }
    }
}
