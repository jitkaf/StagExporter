using ConsoleApp1.DataAcces.StagWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp1.Stag.Harmonogram
{
    /// <summary>
    /// Vydoluje harmonogram konkretni skoly ze Stagu
    /// </summary>
    class VydolovavacHarmonogramu : VydolovavacInfaZeStagu
    {
    
        /// <summary>
        /// Rozparsuje ziskany xml string ze Stagu
        /// </summary>
        public override void ZiskejData()
        {
            UdalostHarmonogramu udalost = new UdalostHarmonogramu();         
            XmlNode lRoot = dokument.DocumentElement;

            //pruchod vnorenymi uzly korenoveho elementu
            foreach (XmlNode lNode in lRoot.ChildNodes)
            {
                if (lNode.Name.Equals("harmonogramItem"))
                {
                    udalost = new UdalostHarmonogramu();
                    //ziskani atributu konkretniho elementu
                    XmlNodeList harmonogramNode = lNode.ChildNodes;
                    foreach (XmlNode childNode in harmonogramNode)
                    {                    
                        switch (true)
                        {
                            case bool b when childNode.Name.Equals("popis"):
                                udalost.Udalost = childNode.FirstChild.Value;
                                break;
                            case bool b when childNode.Name.Equals("datumOd"):
                                udalost.Datum = DateTime.ParseExact(childNode.FirstChild.Value, "d.M.yyyy",
                                System.Globalization.CultureInfo.InvariantCulture);
                                break;                               
                        }
                    }

                    Uzivatel.Harmonogram.Add(udalost);
                }
            }
        }
    }
}
