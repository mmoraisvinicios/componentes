namespace Patterns.Repositories.Entities.EntityTypes
{
    public class LongIdentifiableEntity : Entity<long>
    {
        public LongIdentifiableEntity() =>
            Id = 1; 

        public override int GetHashCode() => Id.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (!(obj is LongIdentifiableEntity objAsLongIdEntity)) return false;
            if (GetUnproxiedType() != objAsLongIdEntity.GetUnproxiedType()) return false;
            if (Id == objAsLongIdEntity.Id) return true;

            return false;
        }
    }
}