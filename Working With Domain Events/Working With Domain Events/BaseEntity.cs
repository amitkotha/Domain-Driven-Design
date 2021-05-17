using System;
using System.Collections.Generic;
using System.Text;

namespace Working_With_Domain_Events
{
    public interface IBaseEntity
    {
        void RaiseEvent(IEvent @event);
        IEnumerable<IEvent> GetEvents();

        void ClearEvents();
    }
   public abstract class BaseEntity:IBaseEntity
    {
        public int Id { get; set; }

        private List<IEvent> _events = new List<IEvent>();  
        public void ClearEvents()
        {
            _events.Clear();
        }

        public IEnumerable<IEvent> GetEvents()
        {
            return _events;
        }

        public void RaiseEvent(IEvent @event)
        {
            _events.Add(@event);
        }
    }
}
