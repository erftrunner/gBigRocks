using System;
using System.Collections.Generic;

namespace BigRocks.Domain.SharedKernel
{
    /// <summary>
    /// http://udidahan.com/2009/06/14/domain-events-salvation/
    /// </summary>
    public static class DomainEvents
    {
        [ThreadStatic] private static List<Delegate> _actions;

        public static void Register<T>(Action<T> callback) where T : BaseDomainEvent
        {
            if (_actions == null)
                _actions = new List<Delegate>();

            _actions.Add(callback);
        }

        public static void Unregister<T>(Action<T> callback) where T : BaseDomainEvent
        {
            _actions.Remove(callback);
        }

        public static void ClearAllCallback()
        {
            _actions = null;
        }

        public static void RaiseEvent<T>(T args) where T : BaseDomainEvent
        {
            if (_actions != null)
                foreach (var action in _actions)
                    if (action is Action<T>)
                        ((Action<T>)action)(args);
        }
    }
}