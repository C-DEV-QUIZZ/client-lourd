using Mesi_Software.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Mesi_Software.ViewModel
{
    public class ScoreSoloViewModel : BaseViewModel
    {
        private string _pseudo = "test";

        public string pseudo { get => _pseudo; set { _pseudo = value; OnPropertyChanged(); } }
                
        private int _points = 116;

        public int points { get => _points; set { _points = value; OnPropertyChanged(); } }

        MainWindowsViewModel windowsViewModel;

        private ScoreSolo _view;

        public RelayCommand btnHome => new RelayCommand(exeFunction => returnPageAccueil());



        public RelayCommand LoadedCommand => new RelayCommand(exeFunction => onLoad());



        public void onLoad()
        {
            // recuperation de la page:
            windowsViewModel = Application.Current.MainWindow.DataContext as MainWindowsViewModel;

            _view = windowsViewModel.CurrentPage as ScoreSolo;

            var elem = new { pseudo = pseudo, points = points };

            _view.dataListeScore.Items.Add(elem);

        }

        private void returnPageAccueil()
        {
            ChangePage(new Accueil());
        }
    }
}
