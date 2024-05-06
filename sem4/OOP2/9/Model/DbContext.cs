using System.Data.Entity;

namespace _9
{
    public class ClubContext : DbContext
    {
        public ClubContext() : base("DefaultConnection")
        {

        }

        public DbSet<Computer> Computers { get; set; }
        public DbSet<Rate> Rates { get; set; }
    }
}
