using static Mesi_Software.Utils.Enums;
using System;
using System.Reflection;
using System.Windows;
namespace Mesi_Software.ViewModel
{
    public class AccueilViewModel : BaseViewModel
    {
        private string _appVersion;

        public string appVersion { get => _appVersion; set { _appVersion = value; OnPropertyChanged(); } }


        public RelayCommand commandBtnModeSolo => new RelayCommand(exec_Function => GoToPseudo(modeJeu.solo));
        
        public RelayCommand commandBtnModeMulti => new RelayCommand(exec_Function => GoToPseudo(modeJeu.multi));

        public RelayCommand commandBtnQuit => new RelayCommand(exec_Function => QuitterApplication());



        public AccueilViewModel()
        {
            appVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }


        private void GoToPseudo(modeJeu mode)
        {
            switch(mode)
            {
                case modeJeu.solo:
                    break;   
                    
                //case modeJeu.multi:
                //    break;

                default:
                    throw new Exception("Le mode choisit est inexistant");
                    break;
            }
        }


        private void QuitterApplication()
        {
            MessageBoxResult result = MessageBox.Show("Voulez vous réellement quitter ?", "Fin de partie", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
                Environment.Exit(0);
        }
    }
}
