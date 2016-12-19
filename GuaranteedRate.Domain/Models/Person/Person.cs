using System;
using GuaranteedRate.Domain.Models.Utility;

namespace GuaranteedRate.Domain.Models.Person
{
    public sealed class Person : IPerson
    {
        public string LastName { get; }
        public string FirstName { get; }
        public Genders Gender { get; }
        public Colors FavoriteColor { get; }
        public DateTime DateoFBirth { get; }

        public Person(string lastName, string firstName, Genders gender, Colors favoriteColor, DateTime dateoFBirth)
        {
            LastName = lastName;
            FirstName = firstName;
            Gender = gender;
            FavoriteColor = favoriteColor;
            DateoFBirth = dateoFBirth;
        }
    }
}