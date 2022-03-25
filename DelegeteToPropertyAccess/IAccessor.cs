namespace DelegeteToPropertyAccess {
    public interface IAccessor {
        object? GetValue(object target);
        void SetValue(object target, object value);
    }
}
