using ConsoleApp1.Export;
using ConsoleApp1.Model;
using ConsoleApp1.Stag.Harmonogram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp1.Stag
{
    /// <summary>
    /// Staticka trida uchovavajici vsechny potrebne informace behem chodu aplikace
    /// </summary>
     public class Uzivatel
    {
        static private string nazevSkoly; 
        /// <summary>
        /// Nazev kalendare, ktery bude tvoren
        /// </summary>
        private static string kalendar = "Kalendar_Stag";
        public static string OsobniCislo { get; set; }
        public static string UrlSkoly { get; set; }
        public static string CalendarId { get; set; }
        public static bool? ChceIHarmonogram { get; set; }
        public static bool HarmonogramVygenerovan { get; set; }
        public static List<RozvrhovaAkce> RozvrhoveAkce { get; set; } = new List<RozvrhovaAkce>();
        public static List<UdalostHarmonogramu> Harmonogram { get; set; } = new List<UdalostHarmonogramu>();
        public static Dictionary<Den, List<int>> indexyDnu { get; set; } = new Dictionary<Den, List<int>>();
        public static Dictionary<string, Mistnost> Mistnosti { get; set; } = new Dictionary<string, Model.Mistnost>();
        public static List<Zaznam> ZaznamyProGoogleKalendar { get; private set; } = new List<Zaznam>();
        public static List<Zakaznik> Zakaznici { get; } = new List<Zakaznik>();
        public static string ChybovaHlaska { get; set;}
        public static bool UdajeSpravne { get; set; } = true;
        public static string Kalendar {
            get
            {
                return kalendar;
            }
            set {
                if (value == null || value.Length == 0)
                {
                    kalendar = "Kalendar_Stag";
                }
                else
                {
                    kalendar = value;
                }
            }
        }

        /// <summary>
        /// Pripravi aplikaci pro novy beh
        /// </summary>
        public static void Vycistit()
        {
            RozvrhoveAkce = new List<RozvrhovaAkce>();
            Harmonogram = new List<UdalostHarmonogramu>();
            Mistnosti = new Dictionary<string, Model.Mistnost>();
            ZaznamyProGoogleKalendar = new List<Zaznam>();
            ChybovaHlaska = "";
            UdajeSpravne = true;
        }
    }
}
