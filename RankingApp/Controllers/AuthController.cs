using Microsoft.AspNetCore.Mvc;
using RankingApp.Services;
using System.Text.Json;
using System.Threading.Tasks;

namespace RankingApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthService _auth;

        public AuthController(AuthService auth)
        {
            _auth = auth;
        }

        // ================= LOGIN =================
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            System.Console.WriteLine("LOGIN HIT");

            var res = await _auth.Login(email, password);

            System.Console.WriteLine("API RESPONSE:");
            System.Console.WriteLine(res);

            //  Check empty response
            if (string.IsNullOrWhiteSpace(res))
            {
                ViewBag.Error = "No response from server (API might be down)";
                return View();
            }

            try
            {
                var json = JsonDocument.Parse(res);
                var root = json.RootElement;

                //   Check success safely
                if (!root.TryGetProperty("success", out var successProp) || !successProp.GetBoolean())
                {
                    ViewBag.Error = root.TryGetProperty("error", out var err)
                        ? err.GetString()
                        : "Invalid login";

                    return View();
                }

                //   Get data safely
                var role = root.TryGetProperty("role", out var roleProp)
                    ? roleProp.GetString()
                    : "USER";

                var name = root.TryGetProperty("name", out var nameProp)
                    ? nameProp.GetString()
                    : "User";

                HttpContext.Session.SetString("user", name);
                HttpContext.Session.SetString("role", role);

                return role == "ADMIN"
                    ? RedirectToAction("AdminWelcome", "Admin")
                    : RedirectToAction("Welcome", "User");
            }
            catch
            {
                //. Handle NON-JSON responses
                if (res.ToLower().Contains("invalid") || res.ToLower().Contains("error"))
                {
                    ViewBag.Error = res;
                    return View();
                }

                ViewBag.Error = "Unexpected server response";
                return View();
            }
        }

        // ================= SIGNUP =================
        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(
            string name,
            string email,
            string password,
            string confirmPassword,
            string ucfid,
            string gender)
        {
            if (password != confirmPassword)
            {
                ViewBag.Error = "Passwords do not match";
                return View();
            }

            var res = await _auth.Signup(name, email, password, ucfid, gender);

            System.Console.WriteLine("SIGNUP RESPONSE:");
            System.Console.WriteLine(res);

            try
            {
                var json = JsonDocument.Parse(res);
                var root = json.RootElement;

                bool success = root.GetProperty("success").GetBoolean();

                if (!success)
                {
                    ViewBag.Error = root.TryGetProperty("error", out var err)
                        ? err.GetString()
                        : "Signup failed";

                    return View();
                }

                return RedirectToAction("ThankYou", "User");
            }
            catch
            {
                // If backend is NOT returning JSON
                if (res.ToLower().Contains("error") || res.ToLower().Contains("fail"))
                {
                    ViewBag.Error = res;
                    return View();
                }

                // Assume success if no error keywords
                return RedirectToAction("ThankYou", "User");
            }
        }
    }
}