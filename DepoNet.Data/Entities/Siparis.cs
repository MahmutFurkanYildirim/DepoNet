namespace DepoNet.Data.Entities
{
    public class Siparis
    {
        public int SiparisId { get; set; }
        public string BelgeNo { get; set; } = string.Empty;
        public DateTime Tarih { get; set; } = DateTime.Now;
        public string Durum { get; set; } = string.Empty; // Beklemede, Tamamlandi, Iptal
        public string? Aciklama { get; set; }

        public ICollection<SiparisDetay> Detaylar { get; set; } = new List<SiparisDetay>();
    }
}