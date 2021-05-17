using Clean.Architecture.Core.Events;
using Clean.Architecture.SharedKernel;
using Clean.Architecture.SharedKernel.Interfaces;
using System.Collections.Generic;

namespace Clean.Architecture.Core.Entities
{
    public class Guestbook:BaseEntity,IAggregateRoot
    {

        public string Name { get; set; }
        public List<GuestBookEntry> Entries { get; } = new List<GuestBookEntry>();

        public void AddEntry(GuestBookEntry guestBookEntry)
        {
            Entries.Add(guestBookEntry);
            Events.Add(new EntryAddedEvent(Id,guestBookEntry));
        }

    }
}
