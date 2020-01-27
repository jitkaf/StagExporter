using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Stag
{
    /// <summary>
    /// Trida reprezentujici rozvrhovou akci z pohledu Stagu
    /// </summary>
    public class RozvrhovaAkce
    {
        private string popisek;
        private int hodinaDo;
        private int minutaDo;
        private int hodinaOd;
        private int minutaOd;

        public string Predmet { get; set; }
        public string Nazev { get; set; }
        public string Budova { get; set; }
        public string Mistnost { get; set; }
        public string Ucitel { get; set; }
        public Tyden Tyden { get; set; }
        public Den Den { get; set; }
        public DateTime PocatecniDen { get; set; }
        public DateTime KonecnyDen { get; set; }

        /// <summary>
        /// Kontroluje, zda hodina odpovida rozmezi 0-23
        /// </summary>
        public int HodinaOd
        {
            get { return hodinaOd; }
            set
            {
                if (value > 23)
                {
                    hodinaOd = 23;
                }
                else if (value < 1)
                {
                    hodinaOd = 0;
                }
                else
                {
                    hodinaOd = value;
                }
            }
        }

        /// <summary>
        /// Kontroluje, zda minuta zacina od 0-59
        /// </summary>
        public int MinutaOd
        {
            get { return minutaOd; }
            set
            {
                if (value > 59)
                {
                    minutaOd = 59;
                }
                else if (value < 1)
                {
                    minutaOd = 0;
                }
                else
                {
                    minutaOd = value;
                }
            }
        }



        /// <summary>
        /// Kontroluje, zda hodina zacina od 0-23
        /// </summary>
        public int HodinaDo { get { return hodinaDo; }
            set {
                if (value > 23)
                {
                    hodinaDo = 23;
                }
                else if (value < 1)
                {
                    hodinaDo = 0;
                }
                else
                {
                    hodinaDo = value;
                }
            }
        }

        /// <summary>
        /// Kontroluje, zda minuta zacina od 0-59
        /// </summary>
        public int MinutaDo
        {
            get { return minutaDo; }
            set
            {
                if (value > 59)
                {
                    minutaDo = 59;
                }
                else if (value < 1)
                {
                    minutaDo = 0;
                }
                else
                {
                    minutaDo = value;
                }
            }
        }
        public string Katedra { get; set; } 

        /// <summary>
        /// Prednaska/cviceni/zkouska...
        /// </summary>
        public string TypAkce { get; set; }
        public bool Export { get; set; } = true;

    }
}
