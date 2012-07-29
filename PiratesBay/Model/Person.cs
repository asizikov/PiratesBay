using PiratesBay.Domain;
using ReactiveUI;

namespace PiratesBay.Model
{
    public class Person : ReactiveObject, IPerson
    {
        public string Name { get; set; }
        public double Spent { get; set; }
        public double Debt { get; set; }
    }
}