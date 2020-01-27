using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    /// <summary>
    /// Reprezentuje zakatnika Stagu - tedy univerzitu / vysokou skolu
    /// </summary>
    public class Zakaznik
    {
        public string NazevSkoly { get; set; }
        public string UrlSkoly { get; set; }

        public override string ToString()
        {
            return NazevSkoly;
        }


        public override bool Equals(object obj)
        {
            
            return this.NazevSkoly.Equals(obj);
        }
    }
}
