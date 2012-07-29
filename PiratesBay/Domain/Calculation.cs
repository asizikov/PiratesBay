using System.Collections.Generic;
using System.Linq;
using PiratesBay.Extensions;
using PiratesBay.Model;

namespace PiratesBay.Domain
{
    public class Calculation : ICalculation
    {
        public double Total 
        { 
            get 
            {
                if (Persons == null || Persons.Count == 0)
                    return 0.0d;
                return Persons.Sum(p => p.Spent);
            } 
        }

        public IList<Person> Persons { get; private set; }

        public Calculation(IList<Person> personsList)
        {
            Persons = personsList.ThrowIfNull("personsList");
        }

        public void Process()
        {
            if (Persons != null &&  Persons.Count > 0)
            {
                var average = Persons.Average(p => p.Spent);
                foreach (var person in Persons) 
                { 
                    person.Debt = person.Spent - average;
                }
            }
        }


        public IList<Details> GetDetails(Person person)
        {
            var gives = Persons.Count(p => p.Debt > 0);
            var gets = Persons.Count(p => p.Debt < 0);

            var details = Persons.Where(p => p.Debt != 0.0)
                .Where(p => p != person)
                .OrderBy(p => p.Debt)
                .Select(p => (new Details { Name = p.Name, Get = p.Debt / gives, Give = p.Debt / gets}))
                .ToList();
            return details;
        }
    }
}
