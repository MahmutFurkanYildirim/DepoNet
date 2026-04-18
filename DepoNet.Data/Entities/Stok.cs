namespace DepoNet.Data.Entities
{
    public class Stok
    {
        public int StokId { get; set; }
        public int UrunId { get; set; }
        public int DepoId { get; set; }
        public decimal Miktar { get; set; }

        public Urun Urun { get; set; } = null!;
        public Depo Depo { get; set; } = null!;
        public ICollection<StokHareket> Hareketler { get; set; } = new List<StokHareket>();
    }
}