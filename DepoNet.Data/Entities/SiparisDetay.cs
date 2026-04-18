namespace DepoNet.Data.Entities
{
    public class SiparisDetay
    {
        public int SiparisDetayId { get; set; }
        public int SiparisId { get; set; }
        public int UrunId { get; set; }
        public decimal Miktar { get; set; }

        public Siparis Siparis { get; set; } = null!;
        public Urun Urun { get; set; } = null!;
    }
}