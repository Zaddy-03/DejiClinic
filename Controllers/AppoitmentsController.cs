using Microsoft.AspNetCore.Mvc;

namespace DejiClinic.Controllers
{
    public class AppoitmentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
