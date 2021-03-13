using Mesi_Software.Utils;
using static Mesi_Software.Utils.Enums;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Mesi_Software.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void ChangePage(UserControl control)
        {
            MainWindowsViewModel nav = Application.Current.MainWindow.DataContext as MainWindowsViewModel;
            nav.CurrentPage = control;
        }
    }
}
