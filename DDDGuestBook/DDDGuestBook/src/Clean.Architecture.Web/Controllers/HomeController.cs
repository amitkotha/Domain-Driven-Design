using Clean.Architecture.Core.Entities;
using Clean.Architecture.SharedKernel.Interfaces;
using Clean.Architecture.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Clean.Architecture.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository;
     

        public HomeController(IRepository repository)
        {
            _repository = repository;
           
            
        }
        public async Task<IActionResult> Index()
        {
            if (!(await _repository.ListAsync<Guestbook>()).Any())
            {
                var newGuestBook = new Guestbook() { Name = "My Guestbook" };
                newGuestBook.Entries.Add(new GuestBookEntry()
                {
                    EmailAddress = "test1@abc.com",
                    Message = "Hi",
                    DateTimeCreated = DateTime.UtcNow.AddHours(-1)
                });
                newGuestBook.Entries.Add(new GuestBookEntry()
                {
                    EmailAddress = "test2@abc.com",
                    Message = "Hello",
                    DateTimeCreated = DateTime.UtcNow.AddHours(-2)
                });
                newGuestBook.Entries.Add(new GuestBookEntry()
                {
                    EmailAddress = "test3@abc.com",
                    Message = "Hello Hi",
                    DateTimeCreated = DateTime.UtcNow.AddHours(-3)
                });
                newGuestBook.Entries.Add(new GuestBookEntry()
                {
                    EmailAddress = "test4@abc.com",
                    Message = "Hi there",
                    DateTimeCreated = DateTime.UtcNow.AddHours(-4)
                });
                await _repository.AddAsync(newGuestBook);
            }
            var guestBook = await _repository.GetByIdAsync<Guestbook>(1,"Entries");
            var viewModel = new HomePageViewModel() { PreviousEntries = guestBook.Entries, GuestBookName = guestBook.Name };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(HomePageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var guestbook = await _repository.GetByIdAsync<Guestbook>(1, "Entries");
                guestbook.AddEntry(model.NewEntry);
                await _repository.UpdateAsync(guestbook);
                model = new HomePageViewModel();
                model.GuestBookName = guestbook.Name;
                model.PreviousEntries = guestbook.Entries;  
            }
            return View(model);
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
