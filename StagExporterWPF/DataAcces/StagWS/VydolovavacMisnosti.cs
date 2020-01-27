using ConsoleApp1.Model;
using ConsoleApp1.Stag;
using System;
using System.Collections.Generic;

using System.Xml;


namespace ConsoleApp1.DataAcces.StagWS
{
    /// <summary>
    /// Ziska mistnosti ze Stagz
    /// </summary>
    public class VydolovavacMisnosti : VydolovavacInfaZeStagu
    {   
        /// <summary>
        /// Ze ziskaneho xlm dokumentu ziska pozadovana data o mistnostech a jednoltive mistnosti prida do listu mistnosti, ktery je atributem tridu Uzivatel.
        /// </summary>
        public override void ZiskejData()
        {
            XmlNode lRoot = dokument.DocumentElement;
            //pruchod vnorenymi uzly korenoveho elementu
            string budova="", cislo="", adresa="", urlBudovy="";

            if (lRoot.ChildNodes.Count > 1)
            {
                Console.Read();
              
            }
            foreach (XmlNode lNode in lRoot.ChildNodes)
            {
                if (lNode.Name.Equals("mistnostInfo"))
                {
                    
                    XmlNodeList mistnostNode = lNode.ChildNodes;
                    foreach (XmlNode childNode in mistnostNode)
                    {
                        switch (true)
                        {
                            case bool b when childNode.Name.Equals("zkrBudovy"):
                                budova = childNode.FirstChild.Value;
                                break;
                            case bool b when childNode.Name.Equals("cisloMistnosti"):
                                cislo = childNode.FirstChild.Value;
                                break;
                            case bool b when childNode.Name.Equals("adresaBudovy"):
                                adresa = childNode.FirstChild.Value;
                                break;
                            case bool b when childNode.Name.Equals("urlBudova"):
                                urlBudovy = childNode.FirstChild.Value;
                                break;
                        }
                    }
                    Mistnost mistnost = new Mistnost(budova, cislo, adresa, urlBudovy);
                    Uzivatel.Mistnosti.Add(budova + cislo, mistnost);
                }
            }
        }
    }
         


    
}
