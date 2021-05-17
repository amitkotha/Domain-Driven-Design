using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Working_With_Domain_Events.Customer;

namespace Working_With_Domain_Events
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Task Handle(TEvent @event);
    }
    public class EventHandler : IEventHandler<CustomerIsChanged>
    {
        public Task Handle(CustomerIsChanged @event)
        {
            Console.Write("Customer is changed event raised");
            return Task.CompletedTask;
        }
    }
}
