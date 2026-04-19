using System.ComponentModel.DataAnnotations;

namespace RankingApp.Models.DTOs
{
    public class SignupRequest
    {
        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int Ucfid { get; set; }

        [Required]
        public string Gender { get; set; }
    }
}