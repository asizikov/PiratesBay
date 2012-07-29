using System;
using PiratesBay.Model;

namespace PiratesBay.Domain
{
    public class ParticipantFactory : IPersonFactory<Person>
    {
        private const string DEFAULT_NAME = "New participant";

        public Person GetNewPerson(int number)
        {
            var person = new Person
                {
                    Name = String.Format("{0}#{1}", DEFAULT_NAME , number + 1)
                };
            return person;
        }
    }
}