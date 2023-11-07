using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace CrimeAlert.Models
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<admin_signup> Admin_Signups { get; set; }

        public DbSet<admin_addcriminals> Admin_AddCriminals { get; set; }
        public DbSet<ImageModel> Images { get; set; }

        public DbSet<user_crimeAlert> User_Crimealerts { get; set; }
    }
}
