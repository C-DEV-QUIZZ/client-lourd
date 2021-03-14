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

namespace Mesi_Software.ViewModel
{
    public class MainWindowsViewModel :BaseViewModel
    {

        public UserControl _currentPage = new Accueil();

        public event PropertyChangedEventHandler PropertyChanged;

        MainWindow mainWindow = Application.Current.MainWindow as MainWindow;


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
            mainWindow.SizeChanged += mainWindow_SizeChanged;
        }

        /// <summary>
        /// Mise a jour de la police quand on resize la fenetre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double hauteur = mainWindow.Height;
            double largeur = mainWindow.Width;
            double PlusGrand = hauteur > largeur ? hauteur : largeur;

            double vMaxNormal = PlusGrand / 30;
            double vMaxTitre = PlusGrand / 20;
            double vMaxInfo = PlusGrand / 50;
            double vMaxInput= PlusGrand / 40;

            Application.Current.Resources["FontSizeTitre"] = vMaxTitre;
            Application.Current.Resources["FontSizeNormal"] = vMaxNormal;
            Application.Current.Resources["FontSizeInfo"] = vMaxInfo;
            Application.Current.Resources["FontSizeInput"] = vMaxInfo;
        }
    }
}
