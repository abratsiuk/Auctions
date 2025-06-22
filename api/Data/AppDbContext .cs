using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Auction> Auctions => Set<Auction>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Seller> Sellers => Set<Seller>();
        public DbSet<Buyer> Buyers => Set<Buyer>();
        public DbSet<InitialOffer> InitialOffers => Set<InitialOffer>();
        public DbSet<TradeResult> TradeResults => Set<TradeResult>();
        public DbSet<TradeProcess> TradeProcesses => Set<TradeProcess>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Buyer)
                .WithOne(b => b.User)
                .HasForeignKey<Buyer>(b => b.UserId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Seller)
                .WithOne(s => s.User)
                .HasForeignKey<Seller>(s => s.UserId);
        }
    }

}
