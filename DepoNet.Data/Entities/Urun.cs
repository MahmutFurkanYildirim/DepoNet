namespace DepoNet.Data.Entities
{
    public class Urun
    {
        public int UrunId { get; set; }
        public string Kod { get; set; } = string.Empty;
        public string Ad { get; set; } = string.Empty;
        public string Birim { get; set; } = string.Empty;
        public string Tip { get; set; } = string.Empty; // SonUrun, AltMontaj, Parca
        public string? Aciklama { get; set; }
        public bool AktifMi { get; set; } = true;

        public ICollection<BOM> UstBOMlar { get; set; } = new List<BOM>();
        public ICollection<BOM> AltBOMlar { get; set; } = new List<BOM>();
        public ICollection<Stok> Stoklar { get; set; } = new List<Stok>();
        public ICollection<SiparisDetay> SiparisDetaylar { get; set; } = new List<SiparisDetay>();
    }
}