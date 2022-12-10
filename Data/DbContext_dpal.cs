using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    /// <summary>
    /// This class will handel calls to get context from database 
    /// context to each table in database has been added
    /// </summary>
    public class DbContext_dpal:DbContext
    {
        public DbContext_dpal(DbContextOptions<DbContext_dpal> options)
            : base(options)
        {
        }

        public DbSet<WebApp.Models.RegisterUser> RegisterUsers { get; set; }

        public DbSet<WebApp.Models.UserInfo> UserInfo { get; set; }

        public DbSet<WebApp.Models.ProfileInfo> ProfileInfo { get; set; }

        public DbSet<WebApp.Models.BehaviourTracker> BehaviourTracker { get; set; }

        public DbSet<WebApp.Models.MedicationList> MedicationList { get; set; }

        public DbSet<WebApp.Models.MedicalHistory> MedicalHistory { get; set; }
    }
}
