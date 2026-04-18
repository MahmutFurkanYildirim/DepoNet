namespace DepoNet.Data.Entities
{
    public class Depo
    {
        public int DepoId { get; set; }
        public string Ad { get; set; } = string.Empty;
        public string? Aciklama { get; set; }
        public bool AktifMi { get; set; } = true;

        public ICollection<Stok> Stoklar { get; set; } = new List<Stok>();
    }
}