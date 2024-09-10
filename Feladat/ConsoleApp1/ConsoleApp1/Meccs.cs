using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Meccs
    {
        public int fordulo { get; set; }
        public int hazaiVege { get; set; }
        public int vendegVege { get; set; }
        public int hazaiFel { get; set; }
        public int vendegFel { get; set; }
        public string hazai { get; set; }
        public string vendeg { get; set; }

        public Meccs(int fordulo, int hazaiVege, int vendegVege, int hazaiFel, int vendegFel, string hazai, string vendeg)
        {
            this.fordulo = fordulo;
            this.hazaiVege = hazaiVege;
            this.vendegVege = vendegVege;
            this.hazaiFel = hazaiFel;
            this.vendegFel = vendegFel;
            this.hazai = hazai;
            this.vendeg = vendeg;
        }

        //public bool Fordito() {

        //    if (hazaiFel < vendegFel && hazaiVege > vendegVege) return true;
        //    if (vendegFel < hazaiFel && vendegVege > hazaiVege) return true;
        //    return false;
        
        //}
    }
}
