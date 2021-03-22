using System;
using System.Collections.Generic;
using System.Text;

namespace Mesi_Software.Entity
{
    public class Questions
    {
        public int id { get; set; }
        public string texte {get;set;}

        public int points {get;set;}

        public List<Reponses> reponses {get;set;}
        
    }

    public class Reponses
    {
        public int id { get; set; }
        public string texte { get; set; }

    }
}
