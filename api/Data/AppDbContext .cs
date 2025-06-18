using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Auction> Auctions => Set<Auction>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Seller> Sellers => Set<Seller>();
        public DbSet<Buyer> Buyers => Set<Buyer>();
        public DbSet<InitialOffer> InitialOffers => Set<InitialOffer>();
        public DbSet<TradeResult> TradeResults => Set<TradeResult>();
        public DbSet<TradeProcess> TradeProcesses => Set<TradeProcess>();
    }

}
