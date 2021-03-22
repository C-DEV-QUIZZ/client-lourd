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

            Button bouton1 = new Button();
            bouton1.Content = "test1";
            bouton1.Margin = new Thickness(10, 10, 10, 10);
            bouton1.HorizontalAlignment = HorizontalAlignment.Stretch;
            bouton1.VerticalAlignment = VerticalAlignment.Stretch;



            Button bouton2 = new Button();
            bouton2.Content = "test2";
            bouton2.Margin = new Thickness(10, 10, 10, 10);
            bouton2.HorizontalAlignment = HorizontalAlignment.Stretch;
            bouton2.VerticalAlignment = VerticalAlignment.Stretch;


            Button bouton3 = new Button();
            bouton3.Content = "test3";
            bouton3.Margin = new Thickness(10, 10, 10, 10);
            bouton3.HorizontalAlignment = HorizontalAlignment.Stretch;
            bouton3.VerticalAlignment = VerticalAlignment.Stretch;

            Button bouton4 = new Button();
            bouton4.Content = "test4";
            bouton4.Margin = new Thickness(10, 10, 10, 10);
            bouton4.HorizontalAlignment = HorizontalAlignment.Stretch;
            bouton4.VerticalAlignment = VerticalAlignment.Stretch;


            Button bouton5 = new Button();
            bouton5.Content = "test5";
            bouton5.Margin = new Thickness(10, 10, 10, 10);
            bouton5.HorizontalAlignment = HorizontalAlignment.Stretch;
            bouton5.VerticalAlignment = VerticalAlignment.Stretch;



            Button bouton6 = new Button();
            bouton6.Content = "test6";
            bouton6.Margin = new Thickness(10, 10, 10, 10);
            bouton6.HorizontalAlignment = HorizontalAlignment.Stretch;
            bouton6.VerticalAlignment = VerticalAlignment.Stretch;



            ColumnDefinition c1 = new ColumnDefinition();
            c1.Width = new GridLength(20, GridUnitType.Star);

            ColumnDefinition c2 = new ColumnDefinition();
            c2.Width = new GridLength(20, GridUnitType.Star);
                        
            ColumnDefinition c3 = new ColumnDefinition();
            c3.Width = new GridLength(20, GridUnitType.Star);

            RowDefinition r1 = new RowDefinition();
            r1.Height = new GridLength(20, GridUnitType.Star);            
            
            RowDefinition r2 = new RowDefinition();
            r2.Height = new GridLength(20, GridUnitType.Star);

            Grid.SetColumn(bouton1, 0);
            Grid.SetRow(bouton1, 0);

            Grid.SetColumn(bouton2, 1);
            Grid.SetRow(bouton2, 0);            
            
            Grid.SetColumn(bouton3, 2);
            Grid.SetRow(bouton3, 0);            
            
            Grid.SetColumn(bouton4, 0);
            Grid.SetRow(bouton4, 1);            
            
            Grid.SetColumn(bouton5, 1);
            Grid.SetRow(bouton5, 1);        
            
            Grid.SetColumn(bouton6, 2);
            Grid.SetRow(bouton6, 1);



            _view.grid_reponses.ColumnDefinitions.Add(c1);
            _view.grid_reponses.ColumnDefinitions.Add(c2);            
            _view.grid_reponses.ColumnDefinitions.Add(c3);

            _view.grid_reponses.RowDefinitions.Add(r1);
            _view.grid_reponses.RowDefinitions.Add(r2);
            _view.grid_reponses.Children.Add(bouton1);
            _view.grid_reponses.Children.Add(bouton2);
            _view.grid_reponses.Children.Add(bouton3);
            _view.grid_reponses.Children.Add(bouton4);
            _view.grid_reponses.Children.Add(bouton5);
            _view.grid_reponses.Children.Add(bouton6);

            // création des boutons associé a la réponse
            //Button bouton = new Button();
            //bouton.Content = "zizi";
            //_view.grid_reponses.Children.Add(bouton);
        }
        // Creer une méthode qui récupère la réponse et l'id de la question et on stocke dans une collection
        // clé / valeur.
        // on supprime le premiere élément de la liste et on actualise _questionsEnCours.
    }
}
