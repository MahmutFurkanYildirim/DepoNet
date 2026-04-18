namespace DepoNet.Data.Entities
{
    public class StokHareket
    {
        public int StokHareketId { get; set; }
        public int StokId { get; set; }
        public string Tip { get; set; } = string.Empty; // Giris, Cikis
        public decimal Miktar { get; set; }
        public DateTime Tarih { get; set; } = DateTime.Now;
        public string? Aciklama { get; set; }

        public Stok Stok { get; set; } = null!;
    }
}