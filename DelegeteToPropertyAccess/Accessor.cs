namespace DelegeteToPropertyAccess {
    internal sealed class Accessor<TTarget, TProperty> : IAccessor {
        private readonly Func<TTarget, TProperty>? Getter;
        private readonly Action<TTarget, TProperty>? Setter;

        public Accessor(Func<TTarget, TProperty>? getter, Action<TTarget, TProperty>? setter) {
            this.Getter = getter;
            this.Setter = setter;
        }

        public object? GetValue(object target) {
            if (this.Getter == null) return null;
            return this.Getter((TTarget)target);
        }

        public void SetValue(object target, object value) {
            if (this.Setter != null) {
                this.Setter((TTarget)target, (TProperty)value);
            }
        }
    }
}
