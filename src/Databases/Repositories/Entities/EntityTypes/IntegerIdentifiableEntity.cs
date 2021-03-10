namespace Patterns.Repositories.Entities.EntityTypes
{
    public class IntegerIdentifiableEntity : Entity<int>
    {
        public IntegerIdentifiableEntity() =>
            Id = 1;  

        public override int GetHashCode() => Id.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (!(obj is IntegerIdentifiableEntity objAsIntegerIdEntity)) return false;
            if (GetUnproxiedType() != objAsIntegerIdEntity.GetUnproxiedType()) return false;
            if (Id == objAsIntegerIdEntity.Id) return true;

            return false;
        }
    }
}