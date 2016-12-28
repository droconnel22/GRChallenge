using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuaranteedRate.Domain.ViewModels;
using GuaranteedRate.Domain.Models.Persons;

namespace GuaranteedRate.Domain.Services
{
    public interface IPersonsService
    {
        IPersons Persons { get; }
        void Initalize(Func<IPersons> initalizer);
     
        bool AddRecord(string model);

        PersonsViewModel GetRecordsByGender();

        PersonsViewModel GetRecordsByBirthDate();

        PersonsViewModel GetRecordsByName();
    }
}
