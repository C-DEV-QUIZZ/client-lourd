using Mesi_Software.Utils;
using static Mesi_Software.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Mesi_Software.View;
using System.Windows;
using Mesi_Software.Tools;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Windows.Controls;

namespace Mesi_Software.ViewModel
{
    public class PseudoViewModel :BaseViewModel
    {
        private string _modeJeu { get; set; } = "solo";
        public modeJeu modeJeu { get => (modeJeu) Enum.Parse(typeof(modeJeu),_modeJeu); set { _modeJeu = value.ToString(); OnPropertyChanged(); } }

        public RelayCommand btnHome => new RelayCommand(exeFunction => returnPageAccueil());
        public RelayCommand btnGoToGame => new RelayCommand(exeFunction => GoToGame());

        public PseudoViewModel(){}


        public void GoToGame()
        {
            UserControl page;
            switch (modeJeu)
            {
                case modeJeu.solo:
                    page=sendValue(modeJeu.solo);
                    break;
                default:
                    throw new Exception("Le mode de jeu n'est pas encore intégré !");
            }

            ChangePage(page);

        }

        public void returnPageAccueil()
        {
            ChangePage(new Accueil());
        }

        public UserControl sendValue(modeJeu mode)
        {


            var donnee = new { mode = (int)mode };
            var jsonString = JsonSerializer.Serialize(donnee);
            var data = new StringContent(jsonString, Encoding.UTF8, "application/json");

            string result = InteractorHttp.Post(Constantes.Routes.MODE_RECEPTION_CONTROLLER, data);

            var dictionnaireResultChemin = JsonSerializer.Deserialize<Dictionary<string, string>>(result);

            return dictionnaireResultChemin[Constantes.KEY_CHEMIN_BACK_END] == Constantes.MODE_SOLO_VALUE_BACK_END ? new modeSolo() : throw new Exception("Non implémenter");
        }
    }
}
