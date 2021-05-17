using Clean.Architecture.SharedKernel;
using System;

namespace Clean.Architecture.Core.Entities
{
    public class GuestBookEntry:BaseEntity
    {
        public string EmailAddress { get; set; }
        public string Message { get; set; }

        public DateTimeOffset DateTimeCreated { get; set; } = DateTime.UtcNow;

    }
}
