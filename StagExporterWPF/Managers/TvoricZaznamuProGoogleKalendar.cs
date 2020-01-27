using ConsoleApp1.Stag;
using ConsoleApp1.Stag.Harmonogram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Properties.Settings.Default;


namespace ConsoleApp1.Export
{
    /// <summary>
    /// Vytvori zaznamy pro google kalendar, tedy ve formatu, v jakem budou potom importovany
    /// </summary>
    public class TvoricZaznamuProGoogleKalendar
    {     
        /// <summary>
        /// Pripravi pro export rozvrhove akce, ktere si uzivatel preje exportovat.
        /// </summary>
        public void VytvorZaznamyProGoogleKalendar()
        {
            foreach (RozvrhovaAkce rozvrhovaAkce in Uzivatel.RozvrhoveAkce)
            {
                if (rozvrhovaAkce.Export == true)
                     VytvorCasoveAkce(rozvrhovaAkce);
            }
        }

        /// <summary>
        /// Vytvori z rozvrhovych akci konkretni casove akce - vztahujici se vzdy ke konkretnimu dni
        /// </summary>
        /// <param name="rozvrhovaAkce"></param>
        public void VytvorCasoveAkce (RozvrhovaAkce rozvrhovaAkce)
        {
            DateTime indexer = rozvrhovaAkce.PocatecniDen;
            DateTime posledni = rozvrhovaAkce.KonecnyDen;
            posledni = posledni.AddHours(rozvrhovaAkce.HodinaOd);
            posledni = posledni.AddMinutes(rozvrhovaAkce.MinutaOd);
            int perioda = (int)rozvrhovaAkce.Tyden;
        
            do
            {
                DateTime zacatek = indexer;
                zacatek = zacatek.AddHours(rozvrhovaAkce.HodinaOd);
                zacatek = zacatek.AddMinutes(rozvrhovaAkce.MinutaOd);
                DateTime konec = indexer;
                konec = konec.AddHours(rozvrhovaAkce.HodinaDo);
                konec = konec.AddMinutes(rozvrhovaAkce.MinutaDo);
                bool pridejNormalne = true;
                if (Uzivatel.ChceIHarmonogram == true) ZpracujRozvrhovouAkciDlePokynuHarmonogramu(indexer, out pridejNormalne);
                if (pridejNormalne)
                {
                    Uzivatel.ZaznamyProGoogleKalendar.Add(new Zaznam(zacatek, konec, rozvrhovaAkce));
                }

                indexer = indexer.AddDays(perioda);
            } while (indexer < posledni);

        }

        /// <summary>
        /// Zohledni harmonogram skoly - vyhleda, zda v den datumAkce je v harmonogramu nejaka udalost a pripadne na ni zareaguje, dle jejiho typu
        /// </summary>
        /// <param name="datumAkce"></param>
        /// <param name="pridejNormalne"></param>
        public void ZpracujRozvrhovouAkciDlePokynuHarmonogramu(DateTime datumAkce,  out bool pridejNormalne)
        {         
            pridejNormalne = true;
            int indexPrvniho = NajdiPrvniShodneDatum(datumAkce);
            int index = indexPrvniho;

            if (indexPrvniho == -1)
            {
                return;
            }
            do
            {               
                switch (true)
                {
                    //pondeli
                    case bool b when (Uzivatel.Harmonogram[index].Udalost.Equals(Properties.Settings.Default.Stringy.rozvrhPoL) || Uzivatel.Harmonogram[index].Udalost.Equals(Stringy.rozvrhPoL)):
                        pridejNormalne = false;
                        if (Uzivatel.Harmonogram[index].Zpracovano == false)
                        {
                            Uzivatel.Harmonogram[index].Zpracovano = true;
                            PridejJinyRozvrhDleHarmonogramu(datumAkce, index, Den.Po, Stringy.rozvrhPoL, Stringy.rozvrhPoS);
                        }
                        break;
                    //utery
                    case bool b when (Uzivatel.Harmonogram[index].Udalost.Equals(Stringy.rozvrhÚtL) || Uzivatel.Harmonogram[index].Udalost.Equals(Stringy.rozvrhÚtS)):
                        pridejNormalne = false;
                        if (Uzivatel.Harmonogram[index].Zpracovano == false)
                        {
                            Uzivatel.Harmonogram[index].Zpracovano = true;
                            PridejJinyRozvrhDleHarmonogramu(datumAkce, index, Den.Út, Stringy.rozvrhÚtL, Stringy.rozvrhÚtS);
                        }
                        break;
                    //streda
                    case bool b when (Uzivatel.Harmonogram[index].Udalost.Equals(Stringy.rozvrhStL) || Uzivatel.Harmonogram[index].Udalost.Equals(Stringy.rozvrhStS)):
                        pridejNormalne = false;
                        if (Uzivatel.Harmonogram[index].Zpracovano == false)
                        {
                            Uzivatel.Harmonogram[index].Zpracovano = true;
                            PridejJinyRozvrhDleHarmonogramu(datumAkce, index, Den.St, Stringy.rozvrhStL, Stringy.rozvrhStS);
                        }
                        break;
                    //ctvrtek
                    case bool b when (Uzivatel.Harmonogram[index].Udalost.Equals(Stringy.rozvrhČtL) || Uzivatel.Harmonogram[index].Udalost.Equals(Stringy.rozvrhČtS)):
                        pridejNormalne = false;
                        if (Uzivatel.Harmonogram[index].Zpracovano == false)
                        {
                            Uzivatel.Harmonogram[index].Zpracovano = true;
                            PridejJinyRozvrhDleHarmonogramu(datumAkce, index,  Den.Čt, Stringy.rozvrhČtL, Stringy.rozvrhČtS);
                        }
                        break;
                    //patek
                    case bool b when (Uzivatel.Harmonogram[index].Udalost.Equals(Stringy.rozvrhPáL) || Uzivatel.Harmonogram[index].Udalost.Equals(Stringy.rozvrhPáS)):
                        pridejNormalne = false;
                        if (Uzivatel.Harmonogram[index].Zpracovano == false)
                        {
                            Uzivatel.Harmonogram[index].Zpracovano = true;
                            PridejJinyRozvrhDleHarmonogramu(datumAkce, index,  Den.Pá, Stringy.rozvrhPáL, Stringy.rozvrhPáS);
                        }
                        break;
                    //sobota
                    case bool b when (Uzivatel.Harmonogram[index].Udalost.Equals(Stringy.rozvrhSoL) || Uzivatel.Harmonogram[index].Udalost.Equals(Stringy.rozvrhSoS)):
                        pridejNormalne = false;
                        if (Uzivatel.Harmonogram[index].Zpracovano == false)
                        {
                            Uzivatel.Harmonogram[index].Zpracovano = true;
                            PridejJinyRozvrhDleHarmonogramu(datumAkce, index, Den.So, Stringy.rozvrhSoL, Stringy.rozvrhSoS);
                        }
                        break;
                    //nedele
                    case bool b when (Uzivatel.Harmonogram[index].Udalost.Equals(Stringy.rozvrhNeL) || Uzivatel.Harmonogram[index].Udalost.Equals(Stringy.rozvrhNeS)) :
                        pridejNormalne = false;
                        if (Uzivatel.Harmonogram[index].Zpracovano == false)
                        {
                            Uzivatel.Harmonogram[index].Zpracovano = true;
                            PridejJinyRozvrhDleHarmonogramu(datumAkce, index,  Den.Ne, Stringy.rozvrhNeL, Stringy.rozvrhNeS);
                        }
                        break;
                        //odpada vyuka
                    case bool b when (Uzivatel.Harmonogram[index].Udalost.Equals(Stringy.vyukaNeni)):
                        pridejNormalne = false;
                        if (Uzivatel.Harmonogram[index].Zpracovano == false)
                        {
                            Uzivatel.Harmonogram[index].Zpracovano = true;
                        }
                        break;
                        //inforativni udalosti
                    default:
                        // pridejNormalne = false;
                        if (Uzivatel.Harmonogram[index].Zpracovano == false)
                        {
                            Uzivatel.Harmonogram[index].Zpracovano = true;
                             Zaznam zaznam = new Zaznam(datumAkce, datumAkce.AddHours(23).AddMinutes(59), Uzivatel.Harmonogram[index].Udalost);
                             Uzivatel.ZaznamyProGoogleKalendar.Add(zaznam);                      
                        }
                        break;
                }

                index++;
            } while (Uzivatel.Harmonogram[index].Datum == datumAkce);
        }



        /// <summary>
        /// Tato metoda je vyvolana v pripade, ze dany den ma byt vyucovano podle jineho rozvrhoveho dne.
        /// </summary>
        /// <param name="datumAkce"></param>
        /// <param name="index"></param>
        /// <param name="den"></param>
        /// <param name="DenLichy"></param>
        /// <param name="denSudy"></param>
        public void PridejJinyRozvrhDleHarmonogramu(DateTime datumAkce, int index, Den den, string DenLichy, string denSudy)
        {
                Uzivatel.Harmonogram[index].Zpracovano = true;
                //pridat na tenhle datum vse z rozvrhNeL ci neS ci neK
                List<int> indexy;
                bool obsahuje = Uzivatel.indexyDnu.TryGetValue(den, out indexy);

                if (!obsahuje) return;

                foreach (int i in indexy)
                {
                    bool chciLichDny = Uzivatel.Harmonogram[index].Udalost.Equals(Uzivatel.Harmonogram[index].Udalost.Equals(DenLichy));
                    bool chciSudDny = Uzivatel.Harmonogram[index].Udalost.Equals(Uzivatel.Harmonogram[index].Udalost.Equals(denSudy));
                    bool mamSudDny = Uzivatel.RozvrhoveAkce[i].Tyden.Equals(Tyden.Sudý);
                    bool mamLichDny =  Uzivatel.RozvrhoveAkce[i].Tyden.Equals(Tyden.Lichý);
                    bool mamKazdeDny =  Uzivatel.RozvrhoveAkce[i].Tyden.Equals(Tyden.Každý);

                //kontroluju zda plati, ze pokud  mam akci, ktera je vyucavana v liche dny, a dle harmonogramu mam chtit liche dny nebo zda pokud mam sude dny a dle harmonogramu mam chtit zrovna ty nebo pripadne pokud mam kazdy den, tak je to jedno
                    if ((chciLichDny && mamLichDny) || (chciSudDny && mamSudDny) || mamKazdeDny)
                    {
                        DateTime zacatek = datumAkce.AddHours( Uzivatel.RozvrhoveAkce[i].HodinaOd).AddMinutes( Uzivatel.RozvrhoveAkce[i].MinutaOd);
                        DateTime konec = datumAkce.AddHours( Uzivatel.RozvrhoveAkce[i].HodinaDo).AddMinutes( Uzivatel.RozvrhoveAkce[i].MinutaDo);
                        DateTime platnostAkceZacatek =  Uzivatel.RozvrhoveAkce[i].PocatecniDen;
                        DateTime platnostAkceKonec =  Uzivatel.RozvrhoveAkce[i].KonecnyDen;
                        if (zacatek >= platnostAkceZacatek && konec <= platnostAkceKonec)
                        {
                        Zaznam zaznam = new Zaznam(zacatek, konec,  Uzivatel.RozvrhoveAkce[i]);
                        Uzivatel.ZaznamyProGoogleKalendar.Add(zaznam);
                         }                    
                    }
                }
           
        }



        /// <summary>
        /// Binarni vyhledavani
        /// </summary>
        /// <param name="datumAkce"></param>
        /// <returns></returns>
        public int NajdiPrvniShodneDatum (DateTime datumAkce)
        {
            int index = -1;
            int spodni = 0;
            int horni = Uzivatel.Harmonogram.Count;
            int stred;

            while ((spodni <= horni) && (spodni<Uzivatel.Harmonogram.Count))
            {
                stred = spodni + (horni - spodni) / 2;
                if (horni == spodni)
                {
                    stred = spodni;
                }
                if (Uzivatel.Harmonogram[stred].Datum > datumAkce)
                {
                    spodni = stred + 1;
                }
                else if (Uzivatel.Harmonogram[stred].Datum < datumAkce)
                {
                    horni = stred - 1;
                }
                else 
                {
                    index = stred;
                    while ((index>0)&&Uzivatel.Harmonogram[index-1].Datum == datumAkce)
                    {
                        index--;
                    }
                    return index;
                }
            }

            return index;
        }
    }
}
