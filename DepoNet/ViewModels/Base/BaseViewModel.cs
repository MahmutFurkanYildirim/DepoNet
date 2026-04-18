using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DepoNet.ViewModels.Base
{
    // Tüm ViewModel'ların türeyeceği temel sınıf
    // INotifyPropertyChanged → property değişince UI otomatik güncellenir
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        // [CallerMemberName] → metodu çağıran property'nin adını otomatik alır
        // Yani SetProperty(() => Ad = value) dediğinde "Ad" string'ini otomatik geçirir
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false; // Değer aynıysa UI'ı gereksiz güncelleme

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}