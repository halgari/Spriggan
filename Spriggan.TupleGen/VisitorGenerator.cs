using System.Collections;
using System.Reflection;
using Loqui;
using Noggog;

namespace Spriggan.TupleGen;

public class VisitorGenerator
{


    public static IEnumerable<PropertyInfo> Members(Type t)
    {
        var seen = new HashSet<string>()
        {
            "ContainedFormLinks",
            "Registration",
            "BinaryWriteTranslator",
            "Item"
        };

        IEnumerable<PropertyInfo> GetInterfaces(Type t)
        {
            foreach (var p in t.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy))
            {
                if (seen.Contains(p.Name)) continue;
                if (p.IsSpecialName) continue;

                seen.Add(p.Name);
                yield return p;
            }

            foreach (var i in t.GetInterfaces().Where(i => i.InheritsFrom(typeof(ILoquiObject))))
            {
                foreach (var p in GetInterfaces(i))
                    yield return p;
            }
            
        }

        return GetInterfaces(t);
    }

    public static IEnumerable<(Type Main, Type Interface, Type Getter)> GetAllTypes(Assembly source)
    {
        var classNames = source.GetTypes().ToLookup(t => t.Name, t=> t);

        var bases = from t in source.GetTypes()
            where t.InheritsFrom(typeof(ILoquiObject))
            where t.IsClass && !t.IsAbstract
            let baseInterfaceName = "I" + t.Name
            let getterInterfaceName = baseInterfaceName + "Getter"
            where classNames.Contains(baseInterfaceName)
            where classNames.Contains(getterInterfaceName)
            let baseInterface = classNames[baseInterfaceName].First()
            let getterInterface = classNames[getterInterfaceName].First()
            where t.InheritsFrom(baseInterface)
            where t.InheritsFrom(getterInterface)
            select (t, baseInterface, getterInterface);
        return bases;
    }
}