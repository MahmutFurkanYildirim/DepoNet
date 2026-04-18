using DepoNet.Commands;
using DepoNet.ViewModels.Base;
using System.Windows.Controls;
using System.Windows.Input;

namespace DepoNet.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly Frame _mainFrame;

        public ICommand UrunlerCommand { get; }
        public ICommand BOMCommand { get; }
        public ICommand StokCommand { get; }
        public ICommand SiparislerCommand { get; }

        public MainViewModel(Frame mainFrame)
        {
            _mainFrame = mainFrame;

            UrunlerCommand = new RelayCommand(_ => Navigate("Urunler"));
            BOMCommand = new RelayCommand(_ => Navigate("BOM"));
            StokCommand = new RelayCommand(_ => Navigate("Stok"));
            SiparislerCommand = new RelayCommand(_ => Navigate("Siparisler"));
        }

        private void Navigate(string page)
        {
            // Hangi sayfaya gidileceğini belirle
            // Sayfaları ilerleyen adımlarda ekleyeceğiz
            switch (page)
            {
                case "Urunler":
                    // _mainFrame.Navigate(new UrunView());
                    break;
                case "BOM":
                    // _mainFrame.Navigate(new BOMView());
                    break;
                case "Stok":
                    // _mainFrame.Navigate(new StokView());
                    break;
                case "Siparisler":
                    // _mainFrame.Navigate(new SiparisView());
                    break;
            }
        }
    }
}