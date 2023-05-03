using Microsoft.AspNetCore.Mvc;

namespace DejiClinic.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
