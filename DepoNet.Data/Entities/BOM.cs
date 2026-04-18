namespace DepoNet.Data.Entities
{
    public class BOM
    {
        public int BOMId { get; set; }
        public int UstUrunId { get; set; }
        public int AltUrunId { get; set; }
        public decimal Miktar { get; set; }
        public string Birim { get; set; } = string.Empty;

        public Urun UstUrun { get; set; } = null!;
        public Urun AltUrun { get; set; } = null!;
    }
}