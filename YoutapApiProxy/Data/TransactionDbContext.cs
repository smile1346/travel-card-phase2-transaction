using Microsoft.EntityFrameworkCore;
using TransactionService.Models;

namespace TransactionService.Data
{
    public class TransactionDbContext : DbContext
    {
        public TransactionDbContext(DbContextOptions<TransactionDbContext> options) : base(options) { }

        public DbSet<Spending> Spendings { get; set; }
        public DbSet<CashWithdrawal> CashWithdrawals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Spending configuration
            modelBuilder.Entity<Spending>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Amount).HasPrecision(18, 2);
                entity.Property(e => e.Currency).IsRequired().HasMaxLength(3);
                entity.Property(e => e.CustomerId).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Location).HasMaxLength(500);
                entity.Property(e => e.MCC).HasMaxLength(10);
                entity.Property(e => e.MerchantName).HasMaxLength(200);
                entity.Property(e => e.Description).HasMaxLength(1000);
                entity.Property(e => e.PaymentMethod).HasMaxLength(50);
                entity.Property(e => e.ReceiptUrl).HasMaxLength(1000);
                entity.Property(e => e.LocalAmount).HasPrecision(18, 2);
                entity.Property(e => e.LocalCurrency).HasMaxLength(3);
                entity.Property(e => e.ExchangeRate).HasPrecision(18, 6);
                
                entity.HasIndex(e => e.TripId);
                entity.HasIndex(e => e.CustomerId);
                entity.HasIndex(e => e.DateTime);
            });

            // CashWithdrawal configuration
            modelBuilder.Entity<CashWithdrawal>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Amount).HasPrecision(18, 2);
                entity.Property(e => e.Currency).IsRequired().HasMaxLength(3);
                entity.Property(e => e.CustomerId).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Location).HasMaxLength(500);
                entity.Property(e => e.ATMDeviceOwner).HasMaxLength(100);
                entity.Property(e => e.ATMDeviceId).HasMaxLength(100);
                entity.Property(e => e.Fee).HasPrecision(18, 2);
                entity.Property(e => e.LocalAmount).HasPrecision(18, 2);
                entity.Property(e => e.LocalCurrency).HasMaxLength(3);
                entity.Property(e => e.ExchangeRate).HasPrecision(18, 6);
                entity.Property(e => e.TransactionReference).HasMaxLength(100);
                
                entity.HasIndex(e => e.TripId);
                entity.HasIndex(e => e.CustomerId);
                entity.HasIndex(e => e.DateTime);
            });
        }
    }
}