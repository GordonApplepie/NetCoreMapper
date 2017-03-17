using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using GordonApplepie.NetCoreMapper.Annotations;

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
                var nomap = p.GetCustomAttribute<NoMapAttribute>();
                var onlymap = p.GetCustomAttribute<OnlyMapAttribute>();
                var mapon = p.GetCustomAttribute<MapOnAttribute>();

                if ((nomap == null || nomap.DoMap(typeof(T))) && 
                    (onlymap == null || onlymap.DoMap(typeof(T)))) {

                    // map on same property name
                    if (mapon == null || mapon.AllowedProperties.Count == 0)
                    {
                        var property = properties.Find(x => x.Name.ToLower() == p.Name.ToLower());
                        if (property != null)
                            property.SetValue(variable, p.GetValue(obj));
                    }
                    // map all properties with selected name
                    else
                    {
                        var list = properties.FindAll(x => mapon.AllowedProperties.Contains(x.Name.ToLower()));
                        for (var i = 0; i < list.Count; i++)
                            list[i].SetValue(variable, p.GetValue(obj));
                    }
                }
            }

            return (T)variable;
        }

        public static void Map(object objToMap, object obj)
        {
            List<PropertyInfo> properties = objToMap.GetType().GetProperties().ToList();

            foreach (PropertyInfo p in obj.GetType().GetProperties())
            {
                var nomap = p.GetCustomAttribute<NoMapAttribute>();
                var onlymap = p.GetCustomAttribute<OnlyMapAttribute>();
                var mapon = p.GetCustomAttribute<MapOnAttribute>();

                if ((nomap == null || nomap.DoMap(objToMap.GetType())) &&
                    (onlymap == null || onlymap.DoMap(objToMap.GetType()))) {

                    // map on same property name
                    if (mapon == null || mapon.AllowedProperties.Count == 0)
                    {
                        var property = properties.Find(x => x.Name.ToLower() == p.Name.ToLower());
                        if (property != null)
                            property.SetValue(objToMap, p.GetValue(obj));
                    }
                    // map all properties with selected name
                    else
                    {
                        var list = properties.FindAll(x => mapon.AllowedProperties.Contains(x.Name.ToLower()));
                        for (var i = 0; i < list.Count; i++)
                            list[i].SetValue(objToMap, p.GetValue(obj));
                    }
                }
            }
        }
    }
}
