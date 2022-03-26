using System.Reflection;

namespace DelegeteToPropertyAccess {
    public static class DynamicPropertyAccessPropertyExtension {

        public static IAccessor GetAccessor(this PropertyInfo property) {

            Type getterDelegateType = typeof(Func<,>).MakeGenericType(property.DeclaringType!, property.PropertyType);
            var getMethod = property.GetGetMethod();
            Delegate? getter = getMethod switch {
                null => null,
                _ => Delegate.CreateDelegate(getterDelegateType, getMethod)
            };

            Type setterDelegateType = typeof(Action<,>).MakeGenericType(property.DeclaringType!, property.PropertyType);
            var setMethod = property.GetSetMethod();
            Delegate? setter = setMethod switch {
                null => null,
                _ => Delegate.CreateDelegate(setterDelegateType, setMethod)
            };

            Type accessorType = typeof(Accessor<,>).MakeGenericType(property.DeclaringType!, property.PropertyType);
            return (IAccessor)Activator.CreateInstance(accessorType, getter, setter)!;
        }
    }
}