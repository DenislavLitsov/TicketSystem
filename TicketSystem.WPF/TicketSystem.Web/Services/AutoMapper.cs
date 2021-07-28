namespace TicketSystem.Web.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Reflection;

    public class AutoMapper<TSource, TDestination>
    {
        private static IDictionary<Type, IEnumerable<PropertyInfo>> TypeProperties = new Dictionary<Type, IEnumerable<PropertyInfo>>();

        public AutoMapper()
        {
            if (TypeProperties.Keys.Any(x => x == typeof(TSource)) == false)
            {
                var props = typeof(TSource).GetProperties();
                TypeProperties.Add(typeof(TSource), props);
            }

            if (TypeProperties.Keys.Any(x => x == typeof(TDestination)) == false)
            {
                var props = typeof(TDestination).GetProperties();
                TypeProperties.Add(typeof(TDestination), props);
            }
        }

        public void Map(TSource source, TDestination destination)
        {
            var sourceProps = TypeProperties[typeof(TSource)];
            var destProps = TypeProperties[typeof(TDestination)];

            foreach (var sourceProp in sourceProps)
            {
                var name = sourceProp.Name;
                var destProp = destProps.FirstOrDefault(x => x.Name == name);
                if (destProp != null)
                {
                    try
                    {
                        var val = sourceProp.GetValue(source);
                        destProp.SetValue(destination, val);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        public TDestination MapNew(TSource source)
        {
            var dest = (TDestination)Activator.CreateInstance(typeof(TDestination));

            this.Map(source, dest);

            return dest;
        }
    }
}
