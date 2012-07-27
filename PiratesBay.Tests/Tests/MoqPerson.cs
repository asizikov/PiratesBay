using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PiratesBay.Domain;

namespace PiratesBay.Test.Unit
{
    public class MoqPerson: IPerson
    {
        public MoqPerson(double spent)
        {
            Spent = spent;
        }
        public double Spent
        {
            get; set;
        }

        public double Debt
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }
}
