using System;

namespace Patterns.Repositories.Entities.EntityTypes
{
    public abstract class BaseEntity
    {
        public abstract object UntypedId { get; }

        public Type GetUnproxiedType() => GetType();

        public abstract override int GetHashCode();
        public abstract override bool Equals(object obj);
    }
}
