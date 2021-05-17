using Clean.Architecture.Core.Entities;
using Clean.Architecture.Core.Events;
using Clean.Architecture.Core.Interfaces;
using Clean.Architecture.SharedKernel.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Clean.Architecture.Core.Handlers
{
    public class GuestBookNotificationHandler : INotificationHandler<EntryAddedEvent>
    {
        private readonly IRepository _repository;
        private readonly IMessageSender _messageSender;

        public GuestBookNotificationHandler(IRepository repository, IMessageSender messageSender)
        {
            _repository = repository;
            _messageSender = messageSender;
        }
        public async Task Handle(EntryAddedEvent domainEvent, CancellationToken cancellationToken)
        {
            var guestbook = await _repository.GetByIdAsync<Guestbook>(1, "Entries");
            foreach (var entry in guestbook.Entries)
            {
                _messageSender.SendGuestbookNotificationEmail(entry.EmailAddress, domainEvent.Entry.Message);
            }
           
        }
    }
}
