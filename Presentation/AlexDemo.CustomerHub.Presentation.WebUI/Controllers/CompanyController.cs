using Microsoft.AspNetCore.Mvc;

namespace AlexDemo.CustomerHub.Presentation.WebUI.Controllers
{
    public class CompanyController : Controller
    {
        public CompanyController() { }

        public IActionResult Index()
        {
            return View();
        }
    }
}
