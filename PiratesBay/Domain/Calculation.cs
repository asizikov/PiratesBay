using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public IList<IPerson> Persons { get; private set; }

        public Calculation(IList<IPerson> personsList)
        {
            if (personsList == null)
                throw new ArgumentNullException("personsList can not be null");

            Persons = personsList;
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


        public IList<IDetails> GetDetails(IPerson person)
        {
            var gives = Persons.Count(p => p.Debt > 0);
            var gets = Persons.Count(p => p.Debt < 0);

            var details = Persons.Where(p => p.Debt != 0.0)
                .Where(p => p != person)
                .OrderBy(p => p.Debt)
                .Select(p => (new Details { Name = p.Name, Get = p.Debt / gives, Give = p.Debt / gets}) as IDetails)
                .ToList();
            return details as IList<IDetails>;
        }
    }
}
