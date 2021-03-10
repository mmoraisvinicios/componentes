namespace Patterns.Repositories.Entities.EntityTypes
{
    public class ShortIdentifiableEntity : Entity<short>
    {
        public ShortIdentifiableEntity() =>
            Id = 1;  

        public override int GetHashCode() => Id.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (!(obj is ShortIdentifiableEntity objAsShortIdEntity)) return false;
            if (GetUnproxiedType() != objAsShortIdEntity.GetUnproxiedType()) return false;
            if (Id == objAsShortIdEntity.Id) return true;

            return false;
        }
    }
}