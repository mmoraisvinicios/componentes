namespace Patterns.Repositories.Entities.EntityTypes
{
    public abstract class Entity<TID> : BaseEntity
    {
        public TID Id { get; set; }
        public override object UntypedId => Id;
    }
}
