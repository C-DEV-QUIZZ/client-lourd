using System;
using System.Collections.Generic;
using System.Text;

namespace Mesi_Software.Utils
{
    public static class Constantes
    {
        public const string FAKE_QUESTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer eleifend arcu eu purus mollis commodo. Phasellus aliquet mi risus, venenatis blandit neque mattis eget. Donec enim orci, vestibulum non ullamcorper vel, tincidunt vitae velit. Etiam aenean.";

        public const string KEY_CHEMIN_BACK_END = "chemin";

        public const string MODE_SOLO_VALUE_BACK_END = "mode-solo";


        public class Routes
        {
            private const string ADRESSE = "http://localhost:80/controller/";

            public const string MODE_RECEPTION_CONTROLLER = ADRESSE+ "receptionModeController.php";

            public const string MODE_SOLO_CONTROLLER = ADRESSE+ "modeSoloController.php";
        }
    }
}
