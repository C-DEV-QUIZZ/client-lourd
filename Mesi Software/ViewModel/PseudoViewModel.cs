using Mesi_Software.Utils;
using static Mesi_Software.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Mesi_Software.View;
using System.Windows;

namespace Mesi_Software.ViewModel
{
    public class PseudoViewModel :BaseViewModel
    {
        private string _modeJeu { get; set; } = "solo";
        public modeJeu modeJeu { get => (modeJeu) Enum.Parse(typeof(modeJeu),_modeJeu); set { _modeJeu = value.ToString(); OnPropertyChanged(); } }

        public RelayCommand btnHome => new RelayCommand(exeFunction => returnPageAccueil());


        public PseudoViewModel(){}

        public void returnPageAccueil()
        {
            ChangePage(new Accueil());
        }
    }
}
