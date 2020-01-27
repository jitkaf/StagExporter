using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.DataAcces.StagWS;
using ConsoleApp1.Stag;
using Properties.Settings.Default;
using ConsoleApp1.Export;

namespace ConsoleApp1.Export
{
    /// <summary>
    /// Zaznam pro export do google kalendare, v podsate se jedna o konkretni casovou akci rozvrhove akce transformovanou do podoby pro export.
    /// </summary>
    public class Zaznam
    {
        /// <summary>
        /// Novy zaznam rozvrhove akce.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="konec"></param>
        /// <param name="rozvrhovaAkce"></param>
        public Zaznam(DateTime start, DateTime konec, RozvrhovaAkce rozvrhovaAkce)
        {
            this.Start = start;
            this.Konec = konec;
            this.Titulek = rozvrhovaAkce.Katedra + @"/" + rozvrhovaAkce.Predmet + " - " + rozvrhovaAkce.TypAkce;
            this.TypAkce = rozvrhovaAkce.TypAkce;

            if (rozvrhovaAkce.Budova == null || rozvrhovaAkce.Mistnost == null || rozvrhovaAkce.Budova == "" || rozvrhovaAkce.Mistnost == "")
            {
                this.MistoPopis = "Bez přesné lokace. " + rozvrhovaAkce.Budova + " " + rozvrhovaAkce.Mistnost;
                return;
            }
            if (!Uzivatel.Mistnosti.ContainsKey(rozvrhovaAkce.Budova + rozvrhovaAkce.Mistnost))
            {
                 PridejNovouMisnost(rozvrhovaAkce);
            }
            if (Uzivatel.Mistnosti.ContainsKey(rozvrhovaAkce.Budova + rozvrhovaAkce.Mistnost))
            {
                this.MistoPopis = Uzivatel.Mistnosti[rozvrhovaAkce.Budova + rozvrhovaAkce.Mistnost].ToString();
                this.MistoUrl = Uzivatel.Mistnosti[rozvrhovaAkce.Budova + rozvrhovaAkce.Mistnost].UrlBudova;
            }

            this.Popis = "Předmět: " + rozvrhovaAkce.Nazev + "\nMísto: "/* + rozvrhovaAkce.Budova + @"/" + rozvrhovaAkce.Mistnost + ": "*/ + this.MistoPopis + "\nVyučující: " + rozvrhovaAkce.Ucitel;
        }


        public void PridejNovouMisnost(RozvrhovaAkce rozvrhovaAkce)
        {               
                VydolovavacMisnosti mistnosti = new VydolovavacMisnosti();
                if (mistnosti.NactiXMLZeStagu(Uzivatel.UrlSkoly + Stringy.urlMisnosti1 + rozvrhovaAkce.Mistnost + Stringy.urlMistnosti2Cast + rozvrhovaAkce.Budova))
                     mistnosti.ZiskejData();          
        }


        /// <summary>
        /// Novy zaznam informativni udalosti.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="konec"></param>
        /// <param name="titulek"></param>
        public Zaznam(DateTime start, DateTime konec, string titulek)
        {
            this.Start = start;
            this.Konec = konec;
            this.Titulek = titulek;
        }

        public DateTime Start { get; set; }
        public DateTime Konec { get; set; }
        public string Titulek { get; set; }
        public string Popis { get; set; }
        public string MistoPopis { get; set; } // adresa mista 
        public string MistoUrl { get; set; } //url odkaz na polohu vyuky
        public string TypAkce { get; set; } //prednaska/cviceni/zkouska...
    }
}
