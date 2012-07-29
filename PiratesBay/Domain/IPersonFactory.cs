namespace PiratesBay.Domain
{
    public interface IPersonFactory<T>
    {
        T GetNewPerson(int number);
    }
}
