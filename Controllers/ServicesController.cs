using Microsoft.AspNetCore.Mvc;

namespace DejiClinic.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
