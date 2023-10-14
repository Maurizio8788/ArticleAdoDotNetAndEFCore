using Microsoft.Data.SqlClient;
using System;
using System.Reflection;

namespace ArticoleAdoDotNetAndEFCore.Extensions;

public static class SqlDataReaderExtensions
{
    public static T ConvertToEntities<T>(this SqlDataReader reader) where T : class, new()
    {
        ArgumentNullException.ThrowIfNull(nameof(reader));
        Type type = typeof(T);
        BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public;
        PropertyInfo[] propertyInfos = type.GetProperties(bindingFlags);
        T entity = new T();

        while(reader.Read())
        {
            foreach(PropertyInfo propertyInfo in propertyInfos)
            {
                if (reader.HasColumn(propertyInfo.Name))
                {
                    object value = reader[propertyInfo.Name];
                    if (value != DBNull.Value)
                    {
                        propertyInfo.SetValue(entity, value);
                    }
                }
            }
        }

        return entity;
    }

    public static bool HasColumn(this SqlDataReader reader, string name)
    {
        for (int index = 0; index < reader.FieldCount; index++)
        {
            if (reader.GetName(index).Equals(name, StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }
}
