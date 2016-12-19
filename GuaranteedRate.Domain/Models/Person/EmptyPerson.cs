using System;
using GuaranteedRate.Domain.Models.Utility;

namespace GuaranteedRate.Domain.Models.Person
{
    internal sealed class EmptyPerson : IPerson
    {
        [ThreadStatic]
        private static EmptyPerson instance;

        private EmptyPerson()
        {
            this.LastName = string.Empty;
            this.FirstName = string.Empty;
            //Date Time has internal default
            this.FavoriteColor = Colors.Red;
            this.Gender = Genders.ChoseNotToIdentify;
        }


        public static IPerson GetInstance
        {
            get
            {
                if(instance == null)
                    instance = new EmptyPerson();
                return instance;
            }
        }

        public string LastName { get; }
        public string FirstName { get; }
        public Genders Gender { get; }
        public Colors FavoriteColor { get; }
        public DateTime DateoFBirth { get; }
    }
}