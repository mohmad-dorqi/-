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
  public  class AestalajeBLL
    {
        AstalajeDAL dal = new AstalajeDAL();
        public string Create(Astalaje a, Persnol p)
        {
            return dal.Create(a, p);
        }
        public DataTable Read()
        {

            return dal.Read();
        }
        //خواندن براساس نام ونام خانوادگی وکدمی
        public DataTable Read(string s)
        {

            return dal.Read(s);
        }
        //خواندن براساس تاریخ مرخصی
        public DataTable Readt(string s)
        {
            return dal.Readt(s);
        }
        public Astalaje read(int id)
        {

            return dal.Read(id);
        }
        public string Update(Astalaje a, int id)
        {
            return dal.Update(a, id);
        }
        public string Delete(int id)
        {
            return dal.Delete(id);
        }


    }
}
