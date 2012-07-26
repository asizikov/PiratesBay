using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PiratesBay.Domain
{
    public interface ICalculation
    {
        double Total { get;}
        IList<IPerson> Persons { get; }
        void Process();

        IList<IDetails> GetDetails(IPerson third);
    }
}
