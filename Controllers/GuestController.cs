using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class GuestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Welcome(string data, int num=1)
        {

            ViewData["Message"] = data;
            ViewData["Count"] = num;

            return View();
        }
    }
}
