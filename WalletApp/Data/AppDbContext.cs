using WalletAppApi.Models;
using Microsoft.EntityFrameworkCore;

namespace WalletAppApi.Data
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration configuration;
        public AppDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            options.UseNpgsql(configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<TransactionDetail> TransactionDetails { get; set; }
        public DbSet<TransactionList> TransactionLists { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionDetail>()
                .HasOne(e => e.TransactionList)
                .WithMany(c => c.TransactionDetails)
                .HasForeignKey(e => e.TransactionListId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TransactionDetail>()
                .HasOne(e => e.User)
                .WithMany(c => c.TransactionDetails)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TransactionList>()
                .HasOne(e => e.User)
                .WithOne(c => c.TransactionList)
                .HasForeignKey<TransactionList>(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
