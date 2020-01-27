using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ConsoleApp1.Stag;

namespace ConsoleApp1.DataAcces.StagWS
{


    /// <summary>
    /// Ziska xml dokument ze Stagu
    /// </summary>
    public abstract class VydolovavacInfaZeStagu
    {
        public XmlDocument dokument;

        public bool NactiXMLZeStagu(String url)
        {

            string xmlStr;
            using (var wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                try
                {
                    xmlStr = wc.DownloadString(url);
                    if (xmlStr.Length == 0)
                    {
                        Uzivatel.ChybovaHlaska = "Nebylo zadáno osobní číslo.";
                        Uzivatel.UdajeSpravne = false;
                        return false;
                    }
                    else if (xmlStr.EndsWith("/>"))
                    {
                        Uzivatel.ChybovaHlaska = "Chybné osobní číslo";
                        Uzivatel.UdajeSpravne = false;
                        return false;
                    }
                }
                catch (Exception e)
                {
                    Uzivatel.ChybovaHlaska = "Nepodařilo se získat údaje z adresy " + url + ". Zkontrolujte, prosím, zdané údaje.";
                    Uzivatel.UdajeSpravne = false;
                    return false;
                }

            }
            dokument = new XmlDocument();
            dokument.LoadXml(xmlStr);
            return true;
        }

        /// <summary>
        /// Ze ziskaneho dokumentu ziska potrebne udaje
        /// </summary>
        public abstract void ZiskejData();
    }
}
