using static Mesi_Software.Utils.Enums;
using System;
using System.Reflection;
using System.Windows;
using Mesi_Software.View;

namespace Mesi_Software.ViewModel
{
    public class AccueilViewModel : BaseViewModel
    {
        private string _appVersion;

        public string appVersion { get => _appVersion; set { _appVersion = value; OnPropertyChanged(); } }

        public RelayCommand commandBtnModeSolo => new RelayCommand(exec_Function => GotoPseudoPage(modeJeu.solo));

        public RelayCommand commandBtnModeMulti => new RelayCommand(exec_Function => GotoPseudoPage(modeJeu.multi));

        public RelayCommand commandBtnQuit => new RelayCommand(exec_Function => QuitterApplication());



        public AccueilViewModel()
        {
            appVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        public void GotoPseudoPage(modeJeu mode)
        {
            switch(mode)
            {
                case modeJeu.solo:
                    PseudoViewModel pvm = new PseudoViewModel(modeJeu.multi);
                    ChangePage(new Pseudo { DataContext = pvm });
                    break;   
                    
                //case modeJeu.multi:
                //    break;

                default:
                    throw new Exception("Le mode choisit est inexistant");
            }
        }


        public void QuitterApplication()
        {
            MessageBoxResult result = MessageBox.Show("Voulez vous réellement quitter ?", "Fin de partie", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
                Environment.Exit(0);
        }
    }
}
