using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RankingApp.Services
{
    public class AuthService
    {
        private readonly HttpClient _http;

        public AuthService(HttpClient http)
        {
            _http = http;
        }

        // LOGIN
        public async Task<string> Login(string email, string password)
        {
            var payload = new
            {
                email = email,
                password = password
            };

            var content = new StringContent(
                JsonSerializer.Serialize(payload),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _http.PostAsync("http://localhost:8080/auth/login", content);

            return await response.Content.ReadAsStringAsync();
        }

        // SIGNUP
        public async Task<string> Signup(string name, string email, string password, string ucfid, string gender)
        {
            var payload = new
            {
                name,
                email,
                password,
                ucfid,
                gender
            };

            var content = new StringContent(
                JsonSerializer.Serialize(payload),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _http.PostAsync("http://localhost:8080/auth/signup", content);

            return await response.Content.ReadAsStringAsync();
        }
    }
}