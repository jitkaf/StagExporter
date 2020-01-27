using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Stag.Rozvrh
{
    /// <summary>
    /// Spravuje rozvrhove akce
    /// </summary>
    class RozvrhovaAkceManager
    {
        /// <summary>
        /// Vrati ci nastavi rozvrhovou akci
        /// </summary>
        internal RozvrhovaAkce RozvrhovaAkce { get; set; }

        public RozvrhovaAkceManager (RozvrhovaAkce rozvrhovaAkce)
        {
            this.RozvrhovaAkce = rozvrhovaAkce;
        }

        /// <summary>
        /// Upravi pocatecni cas rozvrhove akce
        /// </summary>
        /// <param name="start"></param>
        public void UpravStart(DateTime start)
        {
            RozvrhovaAkce.HodinaOd = start.Hour;
            RozvrhovaAkce.MinutaOd = start.Minute;
        }

        /// <summary>
        /// Upravi konecny cas rozvrhove akce
        /// </summary>
        /// <param name="konec"></param>
        public void UpravKonec(DateTime konec)
        {
            RozvrhovaAkce.HodinaDo= konec.Hour;
            RozvrhovaAkce.MinutaDo = konec.Minute;
        }
        
    }
}
