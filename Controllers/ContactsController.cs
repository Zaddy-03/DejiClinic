using Microsoft.AspNetCore.Mvc;

namespace DejiClinic.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
