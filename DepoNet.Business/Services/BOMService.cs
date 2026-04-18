using DepoNet.Business.Interfaces;
using DepoNet.Data.Entities;
using DepoNet.Data.Repositories.Interfaces;

namespace DepoNet.Business.Services
{
    public class BOMService : IBOMService
    {
        private readonly IBOMRepository _bomRepository;

        public BOMService(IBOMRepository bomRepository)
        {
            _bomRepository = bomRepository;
        }

        public async Task<List<BOM>> GetByUstUrunIdAsync(int ustUrunId)
        {
            return await _bomRepository.GetByUstUrunIdAsync(ustUrunId);
        }

        public async Task AddAsync(BOM bom)
        {
            await _bomRepository.AddAsync(bom);
        }

        public async Task DeleteAsync(int bomId)
        {
            await _bomRepository.DeleteAsync(bomId);
        }

        // En kritik metod — projenin kalbi burası
        public async Task<Dictionary<int, decimal>> BOMPatlat(List<SiparisDetay> siparisDetaylar)
        {
            // UrunId → toplam ihtiyaç miktarı
            var ihtiyacMap = new Dictionary<int, decimal>();

            foreach (var detay in siparisDetaylar)
            {
                // Her sipariş kalemi için BOM'u recursive olarak patlat
                await BOMPatlatRecursive(detay.UrunId, detay.Miktar, ihtiyacMap);
            }

            return ihtiyacMap;
        }

        private async Task BOMPatlatRecursive(int urunId, decimal miktar, Dictionary<int, decimal> ihtiyacMap)
        {
            // Bu ürünün BOM'unu getir
            var bomlar = await _bomRepository.GetByUstUrunIdAsync(urunId);

            if (!bomlar.Any())
            {
                // Alt parçası yok — bu bir hammadde/parça, direkt ihtiyaca ekle
                if (ihtiyacMap.ContainsKey(urunId))
                    ihtiyacMap[urunId] += miktar;
                else
                    ihtiyacMap[urunId] = miktar;

                return;
            }

            // Alt parçaları var — her birini recursive olarak patlat
            foreach (var bom in bomlar)
            {
                // Alt parçanın miktarı = üst ürün miktarı × BOM'daki oran
                // Örnek: X silahı x10 sipariş, Namlu x1 BOM → 10 × 1 = 10 Namlu
                var altMiktar = miktar * bom.Miktar;
                await BOMPatlatRecursive(bom.AltUrunId, altMiktar, ihtiyacMap);
            }
        }
    }
}