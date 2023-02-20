using Microsoft.EntityFrameworkCore;

namespace BIerlager2
{
    public class BierContext : DbContext
    {
        public DbSet<Flasche> Flasche { get; set; }
        public DbSet<Kiste> Kiste { get; set; }
        public string DbPath { get; }
        public BierContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "MyBierLager2.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source={DbPath}");
        public void AddBierFromContext(Flasche flasche) => Flasche.Add(flasche);
        public int SaveChanges() => base.SaveChanges();
    }
}
