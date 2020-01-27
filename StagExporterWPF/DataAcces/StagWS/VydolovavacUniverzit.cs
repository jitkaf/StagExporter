using ConsoleApp1.Model;
using ConsoleApp1.Stag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp1.DataAcces.StagWS
{
    /// <summary>
    /// Ziska prehled univerzit, ktere vyuzivaji IS/Stag
    /// </summary>
    public class VydolovavacUniverzit : VydolovavacInfaZeStagu
    {
       
        /// <summary>
        /// Rozprasuje xml dokument s univerzitama
        /// </summary>
        public override void ZiskejData()
        {
            Zakaznik zakaznik;
            XmlNode lRoot = dokument.DocumentElement;
            //pruchod vnorenymi uzly korenoveho elementu
            foreach (XmlNode lNode in lRoot.ChildNodes)
            {
                if (lNode.Name.Equals("nasazeniAplikace"))
                {
                    zakaznik = new Zakaznik();
                    //ziskani atributu konkretniho elementu
                    XmlNodeList univerzita = lNode.ChildNodes;
                    foreach (XmlNode childNode in univerzita)
                    {
                        switch (true)
                        {
                            
                            case bool b when childNode.Name.Equals("celyNazevSkoly"):
                                zakaznik.NazevSkoly = childNode.FirstChild.Value; ;
                                break;
                            case bool b when childNode.Name.Equals("url"):
                                zakaznik.UrlSkoly = childNode.FirstChild.Value;
                                break;
                            case bool b when childNode.Name.Equals("provozniServer"):
                                zakaznik.UrlSkoly = childNode.FirstChild.Value;
                                if (childNode.FirstChild.Value.Equals("A"))
                                     Uzivatel.Zakaznici.Add(zakaznik);
                                break;
                        }
                    }
                }
            }
        }
    }
}
