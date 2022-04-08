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
  public  class TashveqeBLL
    {
        tasveqeDAL dal = new tasveqeDAL();
        public string Create(Tashveqhe t,Persnol p)
        {
            return dal.Create(t,p);
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
        public Tashveqhe read(int id)
        {

            return dal.read(id);
        }
        public string Update(Tashveqhe T, int id)
        {
            return dal.Update(T, id);
        }
        public string Delete(int id)
        {
            return dal.Delete(id);
        }
    }
}
