using System;

namespace Entities
{
    public class Entity : IEquatable<Entity>
    {
        public Guid Id { get; set; }
    
        public bool Equals(Entity? other)
        {
            return Id == other.Id;
        }
    }
}