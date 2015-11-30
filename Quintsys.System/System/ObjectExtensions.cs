using System;

namespace Quintsys.System
{
    public static class ObjectExtensions
    {
        public static T ChangeType<T>(this object value)
        {
            Type type = typeof (T);
            if (!type.IsGenericType || type.GetGenericTypeDefinition() != typeof (Nullable<>))
            {
                // non-generic or non-nullable => just convert
                return (T) Convert.ChangeType(value, type);
            }

            if (value == null || value == DBNull.Value)
                return default(T);

            type = Nullable.GetUnderlyingType(type);
            return (T) Convert.ChangeType(value, type);
        }
    }
}