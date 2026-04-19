using Microsoft.AspNetCore.Mvc;

namespace RankingApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Welcome()
        {
            return View();
        }

        public IActionResult ThankYou()
        {
            return View();
        }
    }
}