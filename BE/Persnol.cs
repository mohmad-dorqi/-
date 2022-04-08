using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class Persnol
    {
        public Persnol()
        {

            Deletestatus = false;
        }
        public int id { get; set; }
        public string NameFamily { get; set; }
      
        public string Kodmili { get; set; }
        public int roz { get; set; }
        public bool Deletestatus { get; set; }
        public List<Astalaje> Astalajes { get; set; }
        public List<Esthqhaqhe> Esthqhaqhes { get; set; }
        public List<Mamoret> Mamorets { get; set; }
        public List<Tashveqhe> Tashveqhes { get; set; }
       

    }
}
