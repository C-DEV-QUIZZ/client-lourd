using Mesi_Software.View;
using static Mesi_Software.Utils.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using Mesi_Software.Utils;

namespace Mesi_Software.ViewModel
{
    public class MainWindowsViewModel :BaseViewModel
    {

        public UserControl _currentPage = new Accueil();

        public event PropertyChangedEventHandler PropertyChanged;

        MainWindow mainWindow = Application.Current.MainWindow as MainWindow;

        private string _pseudo { get; set; }

        public string pseudoSolo
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this._pseudo))
                    return Constantes.PSEUDO_INCONNU;
                return this._pseudo;
            }
            set { _pseudo = value; }
        }
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
    
    
        public MainWindowsViewModel()
        {
            mainWindow.SizeChanged += FunctionEvent.mainWindow_SizeChanged;
        }

    }
}
