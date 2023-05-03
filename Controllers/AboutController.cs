using Microsoft.AspNetCore.Mvc;

namespace DejiClinic.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
