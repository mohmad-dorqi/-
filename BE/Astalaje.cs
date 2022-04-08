using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
  public  class Astalaje
    {

        public Astalaje()
        {

            Deletestatus = false;
        }
      
        public int id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int RoztAstlaje { get; set; }
        public bool Deletestatus { get; set; }
        public string TarekhtAstlaje { get; set; }
        public DateTime RegDate { get; set; }
        public Persnol Persnol { get; set; }
    }
}
