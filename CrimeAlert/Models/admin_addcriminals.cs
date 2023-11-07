using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrimeAlert.Models
{
    public class admin_addcriminals
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int case_ID { get; set; }

        [Required(ErrorMessage = "crime is required")]
        public string Crime { get; set; }
        [Required]
        public string? CriminalName { get; set; }

        [Required]
        public string Gender { get; set; }
        [Required]
        public int Age { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Must be between 3 and 100 characters", MinimumLength = 3)]
        public string CrimeDescription { get; set; }
        public string Status { get; set; }

        public string? PictureUrl { get; set; }


    }
}
