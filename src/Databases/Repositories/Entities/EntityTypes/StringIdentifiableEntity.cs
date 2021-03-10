namespace Patterns.Repositories.Entities.EntityTypes
{
    public class StringIdentifiableEntity : Entity<string>
    {
        public StringIdentifiableEntity() =>
            Id = "1";  

        public override int GetHashCode() => Id.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (!(obj is StringIdentifiableEntity objAsStringIdEntity)) return false;
            if (GetUnproxiedType() != objAsStringIdEntity.GetUnproxiedType()) return false;
            if (Id == objAsStringIdEntity.Id) return true;

            return false;
        }
    }
}