using PiratesBay.Resourses;

namespace PiratesBay
{
    public class LocalizedStrings
    {

       public LocalizedStrings() { }

        private static readonly Strings strings = new Strings();

        public Strings Strings
        {
            get
            {
                return strings;
            }
        }
    }
}
