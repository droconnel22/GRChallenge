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
            if(string.IsNullOrEmpty(lastName)) throw new ArgumentNullException(lastName);
            if(string.IsNullOrEmpty(firstName)) throw new ArgumentNullException(firstName);

            this.LastName = lastName;
            this.FirstName = firstName;
            this.Gender = gender;
            this.FavoriteColor = favoriteColor;
            this.DateoFBirth = dateoFBirth;
        }
    }
}