using Mesi_Software.Utils;
using Mesi_Software.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Mesi_Software.ViewModel
{
    public class modeSoloViewModel :BaseViewModel
    {
        private string _questionEnCours { get; set; } = Constantes.FAKE_QUESTION;
        public string questionEnCours { get => _questionEnCours +" ?"; set { _questionEnCours = value; OnPropertyChanged(); } }

        public RelayCommand LoadedCommand => new RelayCommand(exeFunction => onLoad());


        MainWindowsViewModel windowsViewModel;
        private modeSolo _view;

        public modeSoloViewModel() 
        {
            // appel ajax vers back-end pour récupérer les questions (gestion des cas si back non disponible)

            // stockage des questions dans une listes 

            // Affiche la 1ere question de la liste dans _questionsEnCours

        }

        public void onLoad()
        {
            // recuperation de la page:
            windowsViewModel = Application.Current.MainWindow.DataContext as MainWindowsViewModel;
             _view =  windowsViewModel.CurrentPage as modeSolo;


            // création des boutons associé a la réponse
            Button bouton = new Button();
            bouton.Content = "zizi";
            _view.grid_reponses.Children.Add(bouton);
        }
        // Creer une méthode qui récupère la réponse et l'id de la question et on stocke dans une collection
        // clé / valeur.
        // on supprime le premiere élément de la liste et on actualise _questionsEnCours.
    }
}
