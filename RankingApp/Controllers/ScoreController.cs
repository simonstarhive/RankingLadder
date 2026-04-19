using Microsoft.AspNetCore.Mvc;
using RankingApp.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace RankingApp.Controllers
{
    public class ScoreController : Controller
    {
        private readonly HttpClient _http = new HttpClient();

        public async Task<IActionResult> Mens()
        {
            var res = await _http.GetStringAsync("http://localhost:8080/scores?gender=MALE");

            var scores = JsonSerializer.Deserialize<List<Score>>(res, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return View(scores);
        }

        public async Task<IActionResult> Womens()
        {
            var res = await _http.GetStringAsync("http://localhost:8080/scores?gender=FEMALE");

            var scores = JsonSerializer.Deserialize<List<Score>>(res, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return View(scores);
        }
    }
}