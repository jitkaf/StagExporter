using ConsoleApp1.DataAcces.StagWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Properties.Settings.Default;
namespace ConsoleApp1.Stag
{
    /// <summary>
    /// Rozparsuje rozvrh uzivatele ziskany ze Stagu a vytvori z nej list rozvrhovych akci
    /// </summary>
    public class VydolovavacRozvrhu : VydolovavacInfaZeStagu
    {
        private string urlRozvrhy = Uzivatel.UrlSkoly + Stringy.urlRozvrh + Uzivatel.OsobniCislo;

        public VydolovavacRozvrhu()
        {
            if (Uzivatel.indexyDnu.Count == 0)
                foreach (var i in Enum.GetValues(typeof(Den)))
                {
                    List<int> pom = new List<int>();
                    //pom = null;
                    Uzivatel.indexyDnu.Add((Den)i, pom);
                }
        }

        /// <summary>
        /// Ziska data z xml dokumentu
        /// </summary>
        public override void ZiskejData()
        {
            RozvrhovaAkce rozvrhovaAkce = new RozvrhovaAkce();
            XmlNode lRoot = dokument.DocumentElement;
            //pruchod vnorenymi uzly korenoveho elementu
            foreach (XmlNode lNode in lRoot.ChildNodes)
            {
                if (lNode.Name.Equals("rozvrhovaAkce"))
                {
                    //ziskani atributu konkretniho elementu
                    XmlNodeList rozvrhovaAkceNode = lNode.ChildNodes;
                    rozvrhovaAkce = new RozvrhovaAkce();
                    foreach (XmlNode childNode in rozvrhovaAkceNode)
                    {
                        switch (true)
                        {
                            case bool b when childNode.Name.Equals("nazev"):
                                rozvrhovaAkce.Nazev = childNode.FirstChild.Value;
                                break;
                            case bool b when childNode.Name.Equals("katedra"):
                                rozvrhovaAkce.Katedra = childNode.FirstChild.Value;
                                break;
                            case bool b when childNode.Name.Equals("budova"):
                                rozvrhovaAkce.Budova = childNode.FirstChild.Value;
                                break;
                            case bool b when childNode.Name.Equals("predmet"):
                                rozvrhovaAkce.Predmet = childNode.FirstChild.Value;
                                break;
                            case bool b when childNode.Name.Equals("mistnost"):
                                rozvrhovaAkce.Mistnost = childNode.FirstChild.Value;
                                break;
                            case bool b when childNode.Name.Equals("tyden"):
                                rozvrhovaAkce.Tyden = (Tyden)Enum.Parse(typeof(Tyden), childNode.FirstChild.Value);
                                break;
                            case bool b when childNode.Name.Equals("denZkr"):
                                rozvrhovaAkce.Den = (Den)Enum.Parse(typeof(Den), childNode.FirstChild.Value); ///TODO vzresit kodovani
                                int indexRozvrhoveAkce = Uzivatel.RozvrhoveAkce.Count;
                                List<int> list;
                                if (Uzivatel.indexyDnu.TryGetValue(rozvrhovaAkce.Den, out list))
                                {
                                    list.Add(indexRozvrhoveAkce);
                                }
                                else
                                {
                                    Console.WriteLine("Den nenalezen " + rozvrhovaAkce.Den);
                                }


                                break;
                            case bool b when childNode.Name.Equals("hodinaSkutOd"):
                                rozvrhovaAkce.HodinaOd = (int)(childNode.FirstChild.Value[0] - '0') * 10 + (int)(childNode.FirstChild.Value[1] - '0');
                                rozvrhovaAkce.MinutaOd = (int)(childNode.FirstChild.Value[3] - '0') * 10 + (int)(childNode.FirstChild.Value[4] - '0');
                                break;
                            case bool b when childNode.Name.Equals("hodinaSkutDo"):
                                rozvrhovaAkce.HodinaDo = (int)(childNode.FirstChild.Value[0] - '0') * 10 + (int)(childNode.FirstChild.Value[1] - '0');
                                rozvrhovaAkce.MinutaDo = (int)(childNode.FirstChild.Value[3] - '0') * 10 + (int)(childNode.FirstChild.Value[4] - '0');
                                break;
                            case bool b when childNode.Name.Equals("datumOd"):
                                rozvrhovaAkce.PocatecniDen = DateTime.ParseExact(childNode.FirstChild.Value, "d.M.yyyy",
                                      System.Globalization.CultureInfo.InvariantCulture);
                                break;
                            case bool b when childNode.Name.Equals("datumDo"):
                                rozvrhovaAkce.KonecnyDen = DateTime.ParseExact(childNode.FirstChild.Value, "d.M.yyyy",
                                      System.Globalization.CultureInfo.InvariantCulture);
                                break;
                            case bool b when childNode.Name.Equals("ucitel"):
                                var jmeno = childNode.ChildNodes[1].FirstChild.Value;
                                var prijmeni = childNode.ChildNodes[2].FirstChild.Value;
                                rozvrhovaAkce.Ucitel = jmeno + " " + prijmeni;
                                break;
                            case bool b when childNode.Name.Equals("typAkce"):
                                rozvrhovaAkce.TypAkce = childNode.FirstChild.Value;
                                break;

                        }
                    }
                    rozvrhovaAkce.Export = true;
                    Uzivatel.RozvrhoveAkce.Add(rozvrhovaAkce);
                }
            }

        }
    }
}
