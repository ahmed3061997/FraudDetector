using Microsoft.AspNetCore.Mvc;

namespace FraudDetector.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
