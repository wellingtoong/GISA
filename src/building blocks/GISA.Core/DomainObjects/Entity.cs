using System;

namespace GISA.Core.DomainObjects
{
    public abstract class Entity
    {
        protected Entity() => Id = Guid.NewGuid();

        public Guid Id { get; set; }
    }
}
