using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace GordonApplepie.NetCoreMapper
{
    public class CoreMapper
    {
        public static T Map<T>(object obj)
        {
            var variable = Activator.CreateInstance(typeof(T));
            List<PropertyInfo> properties = variable.GetType().GetProperties().ToList();

            foreach (PropertyInfo p in obj.GetType().GetProperties())
            {
                var property = properties.Find(x => x.Name == p.Name);
                if (property != null)
                    property.SetValue(variable, p.GetValue(obj));

            }

            return (T)variable;
        }

        public static void Map(object objToMap, object obj)
        {
            List<PropertyInfo> properties = objToMap.GetType().GetProperties().ToList();

            foreach (PropertyInfo p in obj.GetType().GetProperties())
            {
                var property = properties.Find(x => x.Name == p.Name);
                if (property != null)
                    property.SetValue(objToMap, p.GetValue(obj));

            }
        }
    }
}
