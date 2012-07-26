using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PiratesBay.Domain
{
    public interface IDetails
    {
        string Name { get; set; }
        double Give { get; set; }
        double Get { get; set; }
    }
}
