using Microsoft.AspNetCore.Mvc;

namespace MeicoContactManager.Controllers
{
    public class HelpController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
