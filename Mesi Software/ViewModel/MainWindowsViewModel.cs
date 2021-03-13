using Mesi_Software.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Mesi_Software.ViewModel
{
    public class MainWindowsViewModel :BaseViewModel
    {
        public UserControl _currentPage = new Accueil();

        public event PropertyChangedEventHandler PropertyChanged;

        public UserControl CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                _currentPage = value;
                OnPropertyChanged();
            }
        }
    }
}
