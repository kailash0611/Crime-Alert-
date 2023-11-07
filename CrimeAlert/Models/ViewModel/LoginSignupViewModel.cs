using NuGet.Configuration;
using System.ComponentModel.DataAnnotations;

namespace CrimeAlert.Models.ViewModel
{
    public class LoginSignupViewModel
    {


        public int? police_ID { get; set; }
        public int? user_ID { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(16, ErrorMessage = "Must be between 3 and 16 characters", MinimumLength = 3)]
        [Key]
        public string UserName { get; set; }

        [Required]
        public string? FullName { get; set; } = "Unknown";

        [Required]

        public string? EmailId { get; set; } = "Not@given";

        [Required]
        [DataType(DataType.PhoneNumber)]
        public double PhoneNo { get; set; } = 0000;

        [Required(ErrorMessage = " Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Admin?")]
        public int IsAdmin { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]

        public string? ConfirmPassword { get; set; } = "match";
    }
}
