using System;

namespace PiratesBay.Extensions
{
    public static class ObjectExtensions
    {
        public static T ThrowIfNull<T>(this T obj, string name) where T: class
        {
            if (obj == null)
            {
                throw new ArgumentNullException(name);
            }
            return obj;
        }
    }
}
