using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    /// <summary>
    /// Trida reprezentujici mistnost, ve ktere probiha vyuka.
    /// </summary>
    public class Mistnost
    {
        public Mistnost(string zkratkaBudovy, string cisloMistnosti, string adresaBudovy, string urlBudova)
        {
            ZkratkaBudovy = zkratkaBudovy;
            CisloMistnosti = cisloMistnosti;
            AdresaBudovy = adresaBudovy;
            UrlBudova = urlBudova;
        }

        public string ZkratkaBudovy { get; set; }
        public string CisloMistnosti { get; set; }
        public string AdresaBudovy { get; set; }
        public string UrlBudova { get; set; }

        public override string ToString()
        {
            return ZkratkaBudovy+CisloMistnosti + ": " + AdresaBudovy ;
        }
    }
}
