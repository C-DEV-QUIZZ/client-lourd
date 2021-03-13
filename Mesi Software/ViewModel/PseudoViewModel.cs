using Mesi_Software.Utils;
using static Mesi_Software.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Mesi_Software.View;

namespace Mesi_Software.ViewModel
{
    public class PseudoViewModel :BaseViewModel
    {
        private string _modeJeu;

        public modeJeu modejeu { get => (modeJeu) Enum.Parse(typeof(modeJeu), _modeJeu); set { _modeJeu = value.ToString(); OnPropertyChanged(); } }

        public RelayCommand btnHome => new RelayCommand(exeFunction => returnPageAccueil());


        public PseudoViewModel(modeJeu mode)
        {
            this.modejeu = mode;
        }

        public void returnPageAccueil()
        {
            ChangePage(new Accueil());
        }
    }
}
