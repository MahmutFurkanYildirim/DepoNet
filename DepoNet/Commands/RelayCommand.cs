using System.Windows.Input;

namespace DepoNet.Commands
{
    // ICommand interface'ini implement eden yardımcı sınıf
    // XAML'dan butona tıklandığında ViewModel'deki metodu çağırır
    public class RelayCommand : ICommand
    {
        private readonly Action<object?> _execute;        // Çalıştırılacak metod
        private readonly Func<object?, bool>? _canExecute; // Buton aktif mi?

        public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        // Butonun aktif/pasif durumu değişince WPF'e haber ver
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        // Buton tıklanabilir mi?
        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        // Butona tıklandı, metodu çalıştır
        public void Execute(object? parameter)
        {
            _execute(parameter);
        }
    }
}