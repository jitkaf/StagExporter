using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Stag.Harmonogram
{

    /// <summary>
    /// Trida reprezentujici harmnonogram ziskany ze Stagz
    /// </summary>
    public class UdalostHarmonogramu
    {
        private DateTime datum;
        private string udalost;
        private bool zpracovano = false;

        public DateTime Datum { get => datum; set => datum = value; }
        public string Udalost { get => udalost; set => udalost = value; }
        public bool Zpracovano { get => zpracovano; set => zpracovano = value; }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || ! this.GetType().Equals(obj.GetType())) 
            {
                return false;
            }
            else {
                    UdalostHarmonogramu p = (UdalostHarmonogramu) obj; 
                return (Datum == p.Datum) && (Udalost == p.Udalost);
            }   
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Datum, Udalost).GetHashCode();
        }

        public override String ToString()
        {
            return String.Format("Datum udalosti: {0}, udalost: {1}, zpracovano: {2} \n",
                                 Datum, Udalost, zpracovano);
        }


      

    }
}
