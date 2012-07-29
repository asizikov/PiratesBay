namespace PiratesBay.Domain
{
    public interface IPerson
    {
        string Name { get; set; }
        double Spent { get; set; }
        double Debt { get; set; }
    }
}
