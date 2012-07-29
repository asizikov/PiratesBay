using ReactiveUI;

namespace PiratesBay.Model
{
    public class Person : ReactiveObject
    {
        private string _name;
        public string Name { 
            get { return _name; }
            set
            {
                this.RaiseAndSetIfChanged(x => x.Name, ref _name, value);
            }
        }

        private double _spent;
        public double Spent
        {
            get { return _spent; }
            set { this.RaiseAndSetIfChanged(x => x.Spent, ref _spent, value); }
        }

        private double _debt;
        public double Debt
        {
            get { return _debt; }
            set { this.RaiseAndSetIfChanged(x => x.Debt, ref _debt, value); }
        }
    }
}