using Mesi_Software.Entity;
using Mesi_Software.Tools;
using Mesi_Software.Utils;
using Mesi_Software.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static Mesi_Software.Utils.Enums;

namespace Mesi_Software.ViewModel
{
    public class modeSoloViewModel :BaseViewModel
    {
        private string _questionEnCours { get; set; } = Constantes.QUESTION_DEFAUT;
        public string questionEnCours { get => _questionEnCours +" ?"; set { _questionEnCours = value; OnPropertyChanged(); } }

        public RelayCommand LoadedCommand => new RelayCommand(exeFunction => onLoad());

        public modeJeu mode { get; } =  modeJeu.solo; 

        MainWindowsViewModel windowsViewModel;

        private modeSolo _view;

        private ScoreSolo _scoreView = new ScoreSolo(); // (1)

        private ScoreSoloViewModel _scoreViewModel; // (2)

        public List<Questions> listQuestions;

        public List<ReponseJoueursSolo> listReponseJoueursSolo = new List<ReponseJoueursSolo>();

        public modeSoloViewModel() 
        {
            // appel ajax vers back-end pour récupérer les questions (gestion des cas si back non disponible)



            var donnee = new { mode = (int)mode };

            string result =  InteractorHttp.Post(Constantes.Routes.MODE_SOLO_CONTROLLER, donnee);

            // stockage des questions dans une listes 
            listQuestions = JsonSerializer.Deserialize<List<Questions>>(result);

            // Affiche la 1ere question de la liste dans _questionsEnCours
            questionEnCours = listQuestions.First<Questions>().texte;
            _scoreViewModel = _scoreView.DataContext as ScoreSoloViewModel;

        }

        public void onLoad()
        {
            // recuperation de la page:
            windowsViewModel = Application.Current.MainWindow.DataContext as MainWindowsViewModel;
             _view =  windowsViewModel.CurrentPage as modeSolo;

            CreationDynamicBouton(listQuestions.First());
        }

        private void CreationDynamicBouton(Questions questions)
        {
            (int colonnes, int lignes) gridValues = CalculNombreColumnRow(questions.reponses.Count);
            ConstructionGrid(_view.grid_reponses,gridValues);
            CreateBouton(_view.grid_reponses, questions, gridValues.colonnes);
        }

        private void CreateBouton(Grid grid, Questions question,int NbColonneTotal)
        {
            int compteurColonne = 0;
            int compteurLigne = 0;
            Button bouton;

            foreach( Reponses reponse in question.reponses)
            {
                bouton  = new Button();
                bouton.Content = reponse.texte;
                bouton.DataContext = new ReponseJoueursSolo { questionId = question.id, reponseUtilisateurId = reponse.id }; // lie l'id de la question et de la réponse au bouton
                bouton.Margin = new Thickness(10, 10, 10, 10);
                bouton.Height = Double.NaN;
                bouton.Width = Double.NaN;
                bouton.SetResourceReference(Control.BackgroundProperty, "BtnBG");
                bouton.SetResourceReference(Control.ForegroundProperty, "FontDark");
                bouton.SetResourceReference(Control.FontFamilyProperty, "FontFamilyTitre");
                bouton.SetResourceReference(Control.FontSizeProperty, "FontSizeReponse");
                bouton.HorizontalAlignment = HorizontalAlignment.Stretch;
                bouton.VerticalAlignment = VerticalAlignment.Stretch;
                bouton.Padding = new Thickness(0, 0, 0, 0);
                Grid.SetColumn(bouton, compteurColonne);
                Grid.SetRow(bouton, compteurLigne);
                grid.Children.Add(bouton);
                bouton.Click += Bouton_Click;
                compteurColonne++;

                if(compteurColonne >= NbColonneTotal)
                {
                    compteurColonne = 0;
                    compteurLigne++;
                }
            }
        }

        private void ConstructionGrid(Grid grid, (int colonnes, int lignes) GridValues)
        {
            grid.ColumnDefinitions.Clear();
            grid.RowDefinitions.Clear();
            grid.Children.Clear();
            ColumnDefinition c1;

            // On construit les colonnes :
            for (int i = 0; i < GridValues.colonnes;i++)
            {
                c1 = new ColumnDefinition();
                c1.Width = new GridLength(20, GridUnitType.Star);
                grid.ColumnDefinitions.Add(c1);
            }
            RowDefinition r1;
            // On construis les lignes
            for (int i = 0; i < GridValues.lignes; i++)
            {
                r1 = new RowDefinition();
                r1.Height = new GridLength(20, GridUnitType.Star);
                grid.RowDefinitions.Add(r1);
            }

        }

        public (int colonnes,int lignes) CalculNombreColumnRow(int Nbreponse)
        {
            if (Nbreponse < 2)
                throw new Exceptions.QuestionsException(Constantes.Message.ERROR_MESSAGE_NB_REPONSES_INCORRECT);

            if (Nbreponse == 2 || Nbreponse == 3)
                return (Nbreponse, 2); // 2 lignes car le bouton est énorme sinon            


            if (Nbreponse % 3 == 0)
                return (3, Nbreponse/3);
            else
                return (3, (int)Math.Ceiling(Nbreponse / 3.0)); //idem => (int)Math.Round((Nbréponse / 3) + 0.5))
        }


        /// <summary>
        /// Méthode generique qui es appelé lors d'un click sur n'importe quell bouton réponse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bouton_Click(object sender, RoutedEventArgs e)
        {
            if (listQuestions.Count == 0)
                return;

            // desactive la grille pour bloquer le double clique:
            _view.grid_reponses.IsEnabled = false;

            Button button = sender as Button;

            ReponseJoueursSolo reponseJoueursSolo = button.DataContext as ReponseJoueursSolo;

            // ajoute l'id de la question et de la réponse bouton
            listReponseJoueursSolo.Add(reponseJoueursSolo);

            listQuestions.RemoveAt(0);

            if (listQuestions.Count != 0)
            {
                questionEnCours = listQuestions.First().texte;
                CreationDynamicBouton(listQuestions.First());
                _view.grid_reponses.IsEnabled = true;
            }
            else
            {
                questionEnCours = "tout est fini !!";
                Finish();
            }
        }

        private void Finish()
        {
            _view.grid_reponses.Children.Clear();
            _view.grid_reponses.ColumnDefinitions.Clear();
            _view.grid_reponses.RowDefinitions.Clear();

            string result =  InteractorHttp.Post(Constantes.Routes.CALCUL_RESULTAT_SOLO_CONTROLLER,listReponseJoueursSolo);

            Scores scores=  JsonSerializer.Deserialize<Scores>(result);

            _scoreViewModel.points = scores.points;
            _scoreViewModel.pseudo = string.IsNullOrWhiteSpace(windowsViewModel.pseudoSolo) ? "Inconnu" : windowsViewModel.pseudoSolo;

            ChangePage(_scoreView);
        }
    }
}
