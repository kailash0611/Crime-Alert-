using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrimeAlert.Models
{
    public class user_crimeAlert
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Crime-type")]
        public string CrimeType { get; set; }

        [Required]
        public string Location { get; set; }
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:hh\:mm}")]
        public DateTime TimeNew { get; set; }

        [Display(Name = "Describe in short")]
        public string CrimeDescription { get; set; }

        public admin_signup? Signups { get; set; }
}
}
