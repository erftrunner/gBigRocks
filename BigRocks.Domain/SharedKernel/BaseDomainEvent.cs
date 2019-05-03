using System;

namespace BigRocks.Domain.SharedKernel
{
    /// <summary>
    /// Basis alle DDD Domänen Events
    /// </summary>
    public abstract class BaseDomainEvent
    {
        public DateTime TimeStamp { get; protected set; } = DateTime.Now;
    }
}