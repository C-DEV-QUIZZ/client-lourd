using System;
using System.Collections.Generic;
using System.Text;

namespace Mesi_Software.Utils
{
    public static class Constantes
    {
        public const string QUESTION_DEFAUT = "Aucune question n'est actuellement disponible, veuillez contacter les developpeurs";

        public const string KEY_CHEMIN_BACK_END = "chemin";

        public const string MODE_SOLO_VALUE_BACK_END = "mode-solo";

        public const string PSEUDO_INCONNU = "Inconnu";

        public class Routes
        {
            private const string ADRESSE = "http://localhost:3000/";

            private const string CONTROLLER = "controller/";

            private const string MODE_SOLO = "modeSolo/";

            public const string MODE_RECEPTION_CONTROLLER = ADRESSE+ CONTROLLER + "receptionMode";

            public const string MODE_SOLO_CONTROLLER = ADRESSE+ CONTROLLER + MODE_SOLO + "start";

            public const string CALCUL_RESULTAT_SOLO_CONTROLLER = ADRESSE+ CONTROLLER + MODE_SOLO + "calculResult";
        }

        public class Message
        {
            public const string ERROR_MESSAGE_NB_REPONSES_INCORRECT = "Le nombre de réponse de la question est inférieur à 2";

            public const string ERROR_MESSAGE_MODE_NOT_IMPLEMENT= "Le mode de jeu n'est pas encore implémenter";

            public const string ERROR_NB_CARACTER = "3 caractères minimum !";
        }

    }

    public static class ConstantesTexteApplication
    {
        public const string TITRE_SCORE = "VOTRE SCORE";

        public const string SCORE_PSEUDO = "PSEUDO";

        public const string SCORE_POINTS = "POINTS";

        public const string TITRE_PSEUDO = "VOTRE PSEUDO";

        public const string ACCUEIL_SOLO = "JOUER SOLO";

        public const string ACCUEIL_MULTI = "JOUER MULTI";

        public const string ACCUEIL_QUITTER = "QUITTER";

        public const string BTN_VALIDER = "VALIDER";

        public const string BTN_HOME = "🏠";

        public const string TOOL_TIPS_BTN_MODE_SOLO = "Cliquez pour démarrer une partie en mode solo";

        public const string TOOL_TIPS_BTN_MODE_MULTI = "Cliquez pour démarrer une partie en mode multijoueur";

        public const string TOOL_TIPS_BTN_QUITTER = "Cliquez pour fermer l'application";

        public const string TOOL_TIPS_BTN_MODE_NOT_IMPLEMENT = Constantes.Message.ERROR_MESSAGE_MODE_NOT_IMPLEMENT;

        public const string TOOL_TIPS_BTN_HOME = "Cliquez pour revenir sur la page d'accueil";

        public const string TOOL_TIPS_BTN_VALIDE_PSEUDO = "Cliquez pour valider votre pseudo";

        public const int BORDER_RADIUS_BOUTON_MATERIAL = 5;

    }
}
