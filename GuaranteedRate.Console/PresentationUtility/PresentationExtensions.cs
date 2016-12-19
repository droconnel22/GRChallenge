namespace GuaranteedRate.Console.PresentationUtility
{
    using System.Collections.Generic;
    using GuaranteedRate.Domain.Models.Person;
    using Console = System.Console;

    internal static class PresentationExtensions
    {
        public static void PrintRecords(this IEnumerable<IPerson> persons, string message = null)
        {
            Console.WriteLine();
            Console.WriteLine("Printing Records......." + message);
            foreach (var person in persons)
            {
                System.Console.WriteLine($"Record: {person.LastName}, {person.FirstName} {person.Gender}, {person.FavoriteColor}, {person.DateoFBirth.ToShortDateString()}");
            }
            Console.WriteLine("Finished Printing Records.......");
            Console.WriteLine();
        }
    }
}
