using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuaranteedRate.Domain.ViewModels
{
   public  class PersonsViewModel
   {
       public IEnumerable<PersonViewModel> Persons { get; set; }

        public PersonsViewModel()
       {
           this.Persons = new List<PersonViewModel>();
       }

        public PersonsViewModel(IEnumerable<PersonViewModel> enumerable)
        {
            this.Persons = enumerable;
        }
    }
}
