using Microsoft.EntityFrameworkCore;
using RSSWPF.Models;

namespace RSSWPF
{
    public class DataContext : DbContext
    {
        private const string ConnectionString =
            "Server=COMPUTER;Database=RSS;Persist Security Info=True;Integrated Security=SSPI;MultipleActiveResultSets=true";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ChangeStatusHistory> ChangeStatusHistories { get; set; }
        public DbSet<ProductStatus> ProductStatuses { get; set; }


    }
}
