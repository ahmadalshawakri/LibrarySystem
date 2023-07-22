namespace LibrarySystem.Domain.Models;

public abstract class Entity<TId> : IEquatable<Entity<TId>>
    where TId : notnull
{
    public TId Id { get; protected init; }

    protected Entity() { }

    protected Entity(TId id)
    {
        this.Id = id;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is Entity<TId>))
            return false;

        if (Object.ReferenceEquals(this, obj))
            return true;

        if (this.GetType() != obj.GetType())
            return false;

        if (obj is not Entity<TId> entity)
            return false;

        return this.Id.Equals(entity.Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode() * 41;
    }

    public bool Equals(Entity<TId> other)
    {
        if (other is null)
            return false;

        if (other.GetType() != this.GetType())
            return false;

        return Id.Equals(other.Id);
    }

    public static bool operator ==(Entity<TId> left, Entity<TId> right)
    {
        if (Object.Equals(left, null))
            return (Object.Equals(right, null)) ? true : false;
        else
            return left.Equals(right);
    }

    public static bool operator !=(Entity<TId> left, Entity<TId> right)
    {
        return !(left == right);
    }
}
