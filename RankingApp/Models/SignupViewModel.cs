using System.ComponentModel.DataAnnotations;

namespace RankingApp.Models
{
    public class SignupViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@ucf\.edu$", ErrorMessage = "Email must be a valid @ucf.edu address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "UCF ID is required")]
        [RegularExpression(@"^\d{7}$", ErrorMessage = "UCF ID must be a 7-digit number")]
        public string UCFID { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}