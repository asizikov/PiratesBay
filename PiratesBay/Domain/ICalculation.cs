using System.Collections.Generic;
using PiratesBay.Model;

namespace PiratesBay.Domain
{
    public interface ICalculation
    {
        double Total { get;}
        IList<Person> Persons { get; }
        void Process();

        IList<Details> GetDetails(Person third);
    }
}
