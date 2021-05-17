using Clean.Architecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clean.Architecture.Web.ViewModels
{
    public class HomePageViewModel
    {
        public string GuestBookName { get; set; }

        public List<GuestBookEntry> PreviousEntries { get; set; } = new List<GuestBookEntry>();

        public GuestBookEntry NewEntry { get; set; }
    }
}
