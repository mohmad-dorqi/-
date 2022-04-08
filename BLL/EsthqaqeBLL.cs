using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
  public  class EsthqaqeBLL
    {
        EsthqaqeDAL dal = new EsthqaqeDAL();
        public string Create(Esthqhaqhe es, Persnol p)
        {
            return dal.Create(es, p);
        }
        public DataTable Read()
        {

            return dal.Read();
        }
        public DataTable Read(string s)
        {

            return dal.Read(s);
        }
        public DataTable Readt(string s)
        {

            return dal.Readt(s);
        }
        public Esthqhaqhe read(int id)
        {

            return dal.read(id);
        }
        public string Update(Esthqhaqhe es, int id)
        {
            return dal.Update(es, id);
        }
        public string Delete(int id)
        {
            return dal.Delete(id);
        }




    }
}
