using System;
using GuaranteedRate.Domain.Models.Utility;

namespace GuaranteedRate.Domain.Models.Person
{
    public interface IPerson
    {
        string LastName { get; }

        string FirstName { get; }

        Genders Gender { get; }

        Colors FavoriteColor { get; }

        DateTime DateoFBirth { get; }

    }
}
