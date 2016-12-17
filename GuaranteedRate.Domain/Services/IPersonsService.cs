using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuaranteedRate.Domain.ViewModels;

namespace GuaranteedRate.Domain.Services
{
    public interface IPersonsService
    {
        IPersonsService BuildPerson(string input);
        //todo think about how to use builder...
        bool AddRecord();

        PersonsViewModel GetRecordsByGender();

        PersonsViewModel GetRecordsByBirthDate();

        PersonsViewModel GetRecordsByName();
    }
}
