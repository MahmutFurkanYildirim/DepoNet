namespace DepoNet.Business.DTOs
{
    // BOM patlatma sonucunda her parça için bu bilgileri döneceğiz
    public class IhtiyacSonuc
    {
        public int UrunId { get; set; }
        public string UrunAd { get; set; } = string.Empty;
        public string UrunKod { get; set; } = string.Empty;
        public decimal IhtiyacMiktar { get; set; }   // Sipariş için gereken
        public decimal MevcutMiktar { get; set; }    // Depodaki mevcut
        public decimal Fark { get; set; }            // Mevcut - İhtiyaç
        public string Durum { get; set; } = string.Empty; // Tamam, Eksik, Fazla
    }
}