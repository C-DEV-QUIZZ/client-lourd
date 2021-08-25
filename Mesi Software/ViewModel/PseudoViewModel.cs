using Mesi_Software.Tools;
using Mesi_Software.Utils;
using Mesi_Software.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using WebSocketSharp;
using static Mesi_Software.Utils.Enums;

namespace Mesi_Software.ViewModel
{
    public class PseudoViewModel :BaseViewModel
    {
        private string _modeJeu ="solo";
        public modeJeu modeJeu { get => (modeJeu) Enum.Parse(typeof(modeJeu),_modeJeu); set { _modeJeu = value.ToString(); OnPropertyChanged(); } }

        private string _pseudo = string.Empty;

        public string pseudo
        {
            get => _pseudo;
            set { _pseudo = value; OnPropertyChanged(); }
        }

        public RelayCommand LoadedCommand => new RelayCommand(exeFunction => onLoad());


        MainWindowsViewModel windowsViewModel;

        private Pseudo _view;

        public RelayCommand btnHome => new RelayCommand(exeFunction => returnPageAccueil());

        public RelayCommand btnGoToGame => new RelayCommand(exeFunction => GoToGame());

        public PseudoViewModel(){}

        private void onLoad()
        {
            // recuperation de la page:
            windowsViewModel = Application.Current.MainWindow.DataContext as MainWindowsViewModel;
            _view = windowsViewModel.CurrentPage as Pseudo;
        }

        public void GoToGame()
        {

            Debug.WriteLine(pseudo);
            if (pseudo.Length < 3)
            {
                FunctionEvent.MessageErrorOnBouton(_view.btn_valid, Constantes.Message.ERROR_NB_CARACTER);
                return;
            }

            UserControl page;
            windowsViewModel.pseudoSolo = pseudo;
            switch (modeJeu)
            {
                case modeJeu.solo:
                    page=sendValue(modeJeu.solo);
                    break;
                case modeJeu.multi:
                    testWebSocket();
                    page = sendValue(modeJeu.multi);
                    break;
                default:
                    throw new Exception(Constantes.Message.ERROR_MESSAGE_MODE_NOT_IMPLEMENT);
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

            string result = InteractorHttp.Post(Constantes.Routes.MODE_RECEPTION_CONTROLLER, donnee);

            var dictionnaireResultChemin = JsonSerializer.Deserialize<Dictionary<string, string>>(result);

            return dictionnaireResultChemin[Constantes.KEY_CHEMIN_BACK_END] == Constantes.MODE_SOLO_VALUE_BACK_END ? new modeSolo() : throw new Exception("Non implémenter");
        }

        private void testWebSocket()
        {
            WebSocket ws = new WebSocket("ws://localhost:3000");

            ws.Connect();

            




        }
    }
}
