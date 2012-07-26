namespace PiratesBay.Domain
{
    public interface IPersonFactory<T> where T : IPerson
    {
        T GetNewPerson(int number);
    }
}
