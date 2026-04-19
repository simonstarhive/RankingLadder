using Microsoft.AspNetCore.Mvc;
using RankingApp.Models;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RankingApp.Controllers
{
    public class RankingController : Controller
    {
        private readonly HttpClient _http = new HttpClient();

        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter() }
        };

        public async Task<IActionResult> Mens()
        {
            var res = await _http.GetStringAsync("http://localhost:8080/rankings");

            var data = JsonSerializer.Deserialize<RankingResponse>(res, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new JsonStringEnumConverter() }
            });

            var mens = data?.Content?
                .Where(r => r.Category == RankingCategory.MEN)
                .OrderBy(r => r.Rank)
                .ToList();

            return View(mens);
        }

        public async Task<IActionResult> Womens()
        {
            var res = await _http.GetStringAsync("http://localhost:8080/rankings");

            var data = JsonSerializer.Deserialize<RankingResponse>(res, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new JsonStringEnumConverter() }
            });

            var womens = data?.Content?
                .Where(r => r.Category == RankingCategory.WOMEN)
                .OrderBy(r => r.Rank)
                .ToList();

            return View(womens);
        }

        public IActionResult Index()
        {
            return RedirectToAction("Mens");
        }
    }
}