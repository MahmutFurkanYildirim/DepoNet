using DepoNet.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DepoNet.Data.Context
{
    public class AppDbContext : DbContext
    {
        // Her DbSet = veritabanında bir tablo
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<BOM> BOMs { get; set; }
        public DbSet<Depo> Depolar { get; set; }
        public DbSet<Stok> Stoklar { get; set; }
        public DbSet<StokHareket> StokHareketler { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<SiparisDetay> SiparisDetaylar { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // BOM tablosunda UstUrun ve AltUrun aynı Urun tablosuna bağlı
            // EF Core bunu otomatik çözemez, elle tanımlamamız gerekiyor
            modelBuilder.Entity<BOM>()
                .HasOne(b => b.UstUrun)
                .WithMany(u => u.UstBOMlar)
                .HasForeignKey(b => b.UstUrunId)
                .OnDelete(DeleteBehavior.Restrict); // Silince cascade olmasın

            modelBuilder.Entity<BOM>()
                .HasOne(b => b.AltUrun)
                .WithMany(u => u.AltBOMlar)
                .HasForeignKey(b => b.AltUrunId)
                .OnDelete(DeleteBehavior.Restrict); // Silince cascade olmasın
        }
    }
}