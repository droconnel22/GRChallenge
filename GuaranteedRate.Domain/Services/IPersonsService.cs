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
        bool AddRecord(PersonViewModel viewModel);
        
        PersonsViewModel GetRecordsByGender();

        PersonsViewModel GetRecordsByBirthDate();

        PersonsViewModel GetRecordsByName();
    }
}
