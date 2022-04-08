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
  public  class MamoretBLL
    {
        MamoretDAL dal = new MamoretDAL();
        public string Create(Mamoret m, Persnol p)
        {
            return dal.Create(m, p);
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
        public Mamoret read(int id)
        {

            return dal.read(id);
        }
        public string Update(Mamoret m, int id)
        {
            return dal.Update(m, id);
        }
        public string Delete(int id)
        {
            return dal.Delete(id);
        }

    }
}
