using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class Esthqhaqhe
    {
        public Esthqhaqhe()
        {

            Deletestatus = false;
        }
        public int id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int RozAsthqaqe{ get; set; }
        public bool Deletestatus { get; set; }
        public string TarekhAsthqaqe { get; set; }
        public DateTime RegDate { get; set; }
        public Persnol Persnol { get; set; }

    }
}
