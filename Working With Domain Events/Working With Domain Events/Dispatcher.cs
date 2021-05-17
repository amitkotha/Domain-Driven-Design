using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Working_With_Domain_Events
{
    public interface IDispatcher
    {
        Task PublishEvent<TEvent>(TEvent @event) where TEvent : IEvent;
    }
    public class Dispatcher : IDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public Dispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task PublishEvent<TEvent>(TEvent @event) where TEvent : IEvent
        {
            if (_serviceProvider.GetServices(typeof(IEventHandler<TEvent>)) is IEnumerable<IEventHandler<TEvent>> handlers)
            {
                var eventHandlers = handlers as IEventHandler<TEvent>[] ?? handlers.ToArray();
                if (eventHandlers.Any())
                {
                    foreach (var handler in eventHandlers)
                    {
                        await handler.Handle(@event);
                    }
                }
            }
        }
    }
}
