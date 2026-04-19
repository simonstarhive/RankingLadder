namespace RankingApp.Models.DTOs
{
    public class LoginResponse
    {
        public bool Success { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }
        public string Message { get; set; }
    }
}