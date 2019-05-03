using BigRocks.Domain.SharedKernel;

namespace BigRocks.Domain.Interfaces
{
    public interface IHandleDomainEvent
    {
    }
    
    public interface IHandleDomainEvent<T> : IHandleDomainEvent where T : BaseDomainEvent
    {
        void Handle(T domainEvent);
    }
}