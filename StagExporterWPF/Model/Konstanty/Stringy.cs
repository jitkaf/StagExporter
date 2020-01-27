using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties.Settings.Default
{
    /// <summary>
    /// Retezce vyuzivane v aplikaci.
    /// </summary>
    public class Stringy
    {
        public const string vyukaNeni = "Tento den neprobíhá výuka";
        public const string rozvrhPoS = "Rozvrh je jako v Po sudý týden";
        public const string rozvrhStS = "Rozvrh je jako v St sudý týden";
        public const string rozvrhPoL = "Rozvrh je jako v St lichý týden";
        public const string rozvrhStL = "Rozvrh je jako v St lichý týden";
        public const string rozvrhÚtS = "Rozvrh je jako v Út sudý týden";
        public const string rozvrhÚtL = "Rozvrh je jako v Út lichý týden";
        public const string rozvrhČtS = "Rozvrh je jako v Čt sudý týden";
        public const string rozvrhČtL = "Rozvrh je jako v Čt lichý týden";
        public const string rozvrhPáS = "Rozvrh je jako v Pá sudý týden";
        public const string rozvrhPáL = "Rozvrh je jako v Pá lichý týden";
        public const string rozvrhSoL = "Rozvrh je jako v So lichý týden";
        public const string rozvrhSoS = "Rozvrh je jako v So sudý týden";
        public const string rozvrhNeS = "Rozvrh je jako v Ne sudý týden";
        public const string rozvrhNeL = "Rozvrh je jako v Ne lichý týden";
        public const string urlHarmonogram = @"/services/rest2/kalendar/getHarmonogramRoku";
        public const string urlRozvrh = @"/services/rest2/rozvrhy/getRozvrhByStudent?osCislo=";        public const string urlMistnosti = @" /services/rest2/mistnost/getMistnostiInfo";
        public const string urlMisnosti1 = @"/services/rest2/mistnost/getMistnostiInfo?cisloMistnosti=";
        public const string urlMistnosti2Cast = @"&zkrBudovy=";
        public const string urlZakaznici = @"https://stag-ws.zcu.cz/ws/services/rest2/zakaznici/getSeznamProvozovanychWS";




    }
}
