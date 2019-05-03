using System;

namespace BigRocks.Domain.SharedKernel
{
    /// <summary>
    /// Basisklasse für alle DDD Entities
    /// </summary>
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}