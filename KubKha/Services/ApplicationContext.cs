using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using KubKha.Models;

namespace KubKha.Services
{
    class ApplicationContext : DbContext
    {
        public DbSet<Boss> Bosses { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TeamView> TeamViews { get; set; }

        public ApplicationContext() : base("DefaultConnection") 
        {
        
        }
    }
}
