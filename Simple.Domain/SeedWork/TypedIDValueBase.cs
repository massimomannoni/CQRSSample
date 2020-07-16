using System;

namespace Simple.Domain.SeedWork
{
    public abstract class TypedIdValueBase : IEquatable<TypedIdValueBase>
    {
        public Guid Value { get; }

        protected TypedIdValueBase(Guid value)
        {
            Value = value;
        }

        public bool Equals(TypedIdValueBase other)
        {
            return Value == other.Value;
        }
    }
}
