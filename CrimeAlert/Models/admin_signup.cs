using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrimeAlert.Models
{
    [Table("User")]
    public class admin_signup
    {

        [Key]
        public int police_ID { get; set; }
        [Required(ErrorMessage = "Username is required")]
        [StringLength(16, ErrorMessage = "Must be between 3 and 16 characters", MinimumLength = 3)]
        public string UserName { get; set; }
     
        public string FullName { get; set; }
      
        public string EmailId { get; set; } 
    
        public double PhoneNo { get; set; } 
        [Required(ErrorMessage = " Password is required")]
     
        public string Password { get; set; }
        //public bool IsRemember { get; set; }
        [Display(Name = "Admin?")]
        public int IsAdmin { get; set; }

        public string ConfirmPassword { get; set; } 
    }
}
