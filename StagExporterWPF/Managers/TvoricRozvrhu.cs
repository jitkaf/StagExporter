using ConsoleApp1.Stag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Properties.Settings.Default;
namespace TakholtasponWPF.Managers
{
    /// <summary>
    /// Vytvori rozvrh uzivatele
    /// </summary>
    public class TvoricRozvrhu
    {
        public TvoricRozvrhu()
        {
            if (Uzivatel.UdajeSpravne)
            {
                VydolovavacRozvrhu pracuj = new VydolovavacRozvrhu();
                if (pracuj.NactiXMLZeStagu(Uzivatel.UrlSkoly + Stringy.urlRozvrh + Uzivatel.OsobniCislo))
                {
                    pracuj.ZiskejData();
                }
            }
        }
    }
}
