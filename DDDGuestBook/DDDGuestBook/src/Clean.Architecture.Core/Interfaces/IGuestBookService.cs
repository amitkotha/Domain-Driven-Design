
using Clean.Architecture.Core.Entities;
using System.Threading.Tasks;

namespace Clean.Architecture.Core.Interfaces
{
    public interface IGuestBookService
    {   
        Task RecordEntry(Guestbook guestbook, GuestBookEntry newEntry);
    }
}
