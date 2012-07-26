using System;
using PiratesBay.ViewModels;

namespace PiratesBay.Domain
{
    public class PersonFactory: IPersonFactory<PersonViewModel>
    {
        public PersonViewModel GetNewPerson(int number)
        {
            var person = new PersonViewModel
            {
                Name = String.Format("{0}#{1}", PersonViewModel.DefaultName, number + 1)
            };
            return person;
        }
    }
}
