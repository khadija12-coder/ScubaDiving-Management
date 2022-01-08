using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AppScubaDiving.Models;

namespace AppScubaDiving.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AppScubaDiving.Models.Plongeur> Plongeur { get; set; }
        public DbSet<AppScubaDiving.Models.MaterielPlongee> MaterielPlongee { get; set; }
    }
}