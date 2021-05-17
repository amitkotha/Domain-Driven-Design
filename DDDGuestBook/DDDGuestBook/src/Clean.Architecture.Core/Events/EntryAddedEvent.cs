using Clean.Architecture.Core.Entities;
using Clean.Architecture.SharedKernel;

namespace Clean.Architecture.Core.Events
{
    public class EntryAddedEvent:BaseDomainEvent
    {
        public EntryAddedEvent(int guestBookId,GuestBookEntry entry)
        {
            GuestBookId = guestBookId;
            Entry = entry;
        }

        public int GuestBookId { get; }
        public GuestBookEntry Entry { get; }
    }
}