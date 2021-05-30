using static Mesi_Software.Utils.Enums;
using System;
using System.Reflection;
using System.Windows;
using Mesi_Software.View;
using Mesi_Software.Utils;

namespace Mesi_Software.ViewModel
{
    /// <summary>
    /// 
    /// ======== PASSEZ OU UPDATE UN PARAMETRE D'UN MODEL VIEW A UN AUTRE
    /// info : en instanciant le ClassViewModel (2), associé à l'objet de la view 
    /// (instancié ici aussi en (1) )
    /// on pourra update une propriété (3) du viewModel et passé l'objet de la vue a la méhtode
    ///  changePage() (4)
    /// 
    /// ===== OU =====
    ///  On pourrait peut être aussi instancié une ViewModel et l'associé au datacontext 
    ///  de l'objet view :
    ///  
    ///  Pseudo _pseudoView = new Pseudo()
    ///  _pseudoView.DataContext = new PseudoViewModel(mon_parametre)
    ///  ChangePage(_pseudoView);
    /// </summary>
    public class AccueilViewModel : BaseViewModel
    {
        private string _appVersion;

        public string appVersion { get => _appVersion; set { _appVersion = value; OnPropertyChanged(); } }

        public RelayCommand commandBtnModeSolo => new RelayCommand(exec_Function => GotoPseudoPage(modeJeu.solo));

        public RelayCommand commandBtnModeMulti => new RelayCommand(exec_Function => GotoPseudoPage(modeJeu.multi));

        public RelayCommand commandBtnQuit => new RelayCommand(exec_Function => QuitterApplication());

        private Pseudo _pseudoView = new Pseudo(); // (1)

        private PseudoViewModel _pseudoViewModel; // (2)

        private string _adresseBack;

        public string adresseBack { get => Constantes.Routes.ADRESSE_BACK; set { _adresseBack = value; OnPropertyChanged(); } }

        public AccueilViewModel()
        {
            appVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        public void GotoPseudoPage(modeJeu mode)
        {
            _pseudoViewModel = _pseudoView.DataContext as PseudoViewModel; // recuperation du view model associé a la vu

            switch (mode)
            {
                case modeJeu.solo:
                    _pseudoViewModel.modeJeu = mode; // (3) on peut modifié ces propriétés.
                    break;

                case modeJeu.multi:
                    _pseudoViewModel.modeJeu = mode; 
                    break;

                default:
                    throw new Exception("Le mode choisit est inexistant");
            }

            ChangePage(_pseudoView); // (4) on passe la vue a change page.
        }


        public void QuitterApplication()
        {
            MessageBoxResult result = MessageBox.Show("Voulez vous réellement quitter ?", "Fin de partie", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
                Environment.Exit(0);
        }
    }
}
