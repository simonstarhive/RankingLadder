using Microsoft.AspNetCore.Mvc;

namespace RankingApp.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index() => RedirectToAction("AdminWelcome");

        public IActionResult AdminWelcome() => View();

        public IActionResult AdminMensRanking() => View();
        public IActionResult AdminWomensRanking() => View();

        public IActionResult AdminMensScores() => View();
        public IActionResult AdminWomensScores() => View();

        public IActionResult AdminAddUser() => View();
    }
}