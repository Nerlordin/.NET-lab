using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Widoki.Models;

namespace Widoki.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PhoneBookService _phoneBook;

        public HomeController(ILogger<HomeController> logger, PhoneBookService phoneBook)
        {
            _logger = logger;
            _phoneBook = phoneBook;
        }

        public IActionResult Index()
        {
            return View(_phoneBook.GetContacts());
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Delete(int id)
        {
               
            if (id != null)
            {
                _phoneBook.Remove(id);
            }
            else
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _phoneBook.Add(contact);
                return RedirectToAction("Index");
            }
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       

    }
}