using System;
using System.Collections.Generic;
using System.Linq;

namespace GordonApplepie.NetCoreMapper.Annotations
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class NoMapAttribute : System.Attribute
    {
        private List<Type> _types;

        public NoMapAttribute()
        {
        }

        public NoMapAttribute(params Type[] types)
        {
            _types = types.ToList();
        }

        public bool DoMap (Type type)
        {
            if (_types == null || _types.Count == 0 || _types.Contains(type))
                return false;
            else
                return true;
        }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class OnlyMapAttribute : System.Attribute
    {
        private List<Type> _types;

        public OnlyMapAttribute(params Type[] types)
        {
            _types = types.ToList();
        }

        public bool DoMap(Type type)
        {
            if (_types != null && _types.Contains(type))
                return true;
            else
                return false;
        }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class MapOnAttribute : System.Attribute
    {
        private List<string> _properties = new List<string>();

        public MapOnAttribute(params string[] properties)
        {
            _properties = properties.Select(x => x.ToLower()).ToList();
        }

        public virtual List<string> AllowedProperties
        {
            get
            {
                return _properties;
            }
        }
    }
}
