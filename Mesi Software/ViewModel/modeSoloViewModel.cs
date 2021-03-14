using Mesi_Software.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mesi_Software.ViewModel
{
    public class modeSoloViewModel :BaseViewModel
    {
        private string _questionEnCours { get; set; } = Constantes.FAKE_QUESTION;
        public string questionEnCours { get => _questionEnCours +" ?"; set { _questionEnCours = value; OnPropertyChanged(); } }

        public modeSoloViewModel() 
        {
            // appel ajax vers back-end pour récupérer les questions (gestion des cas si back non disponible)

            // stockage des questions dans une listes 

            // Affiche la 1ere question de la liste dans _questionsEnCours

        }


        // Creer une méthode qui récupère la réponse et l'id de la question et on stocke dans une collection
        // clé / valeur.
        // on supprime le premiere élément de la liste et on actualise _questionsEnCours.
    }
}
