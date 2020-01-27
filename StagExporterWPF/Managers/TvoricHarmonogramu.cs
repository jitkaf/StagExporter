using ConsoleApp1.Stag;
using ConsoleApp1.Stag.Harmonogram;
using Properties.Settings.Default;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakholtasponWPF.Managers
{
    /// <summary>
    /// Vytvori harmonogram konkretni skoly
    /// </summary>
    public class TvoricHarmonogramu
    {
        public TvoricHarmonogramu()
        {
            Uzivatel.HarmonogramVygenerovan = true;
            VydolovavacHarmonogramu vydolovavacHarmonogramu = new VydolovavacHarmonogramu();
            if (vydolovavacHarmonogramu.NactiXMLZeStagu(Uzivatel.UrlSkoly + Stringy.urlHarmonogram))
            {
                vydolovavacHarmonogramu.ZiskejData();

                Uzivatel.Harmonogram = Uzivatel.Harmonogram.OrderByDescending(UdalostZHarmonogramu => UdalostZHarmonogramu.Datum)
                  .ThenBy(UdalostZHarmonogramu => UdalostZHarmonogramu.Udalost).ToList();

            }
        }
    }
}
