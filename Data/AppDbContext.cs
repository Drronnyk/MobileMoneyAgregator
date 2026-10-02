using System.Net;
using Microsoft.EntityFrameworkCore;
using MobileMoneyAgregator.Models.Merchant;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext>options):base(options){}
    public DbSet<Merchant> Merchants
    {
        get;
        set;
    }
    public DbSet<Transaction>Transactions 
    {
        get;
        set;
    }
    public DbSet<PaymentProviderLog> PaymentProviderLogs
    {
        get;
        set;
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaction>()
        .HasOne(t =>t.Merchant)
        .WithMany(m =>m.Transactions)
        .HasForeignKey(t=>t.MerchantId );

        modelBuilder.Entity<PaymentProviderLog>()
        .HasOne(p =>p.Transaction)
        .WithMany(t =>t.ProviderLogs)
        .HasForeignKey(t=>t.TransactionId );

    }
}