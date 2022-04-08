using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BE;
using DAL;

namespace BLL
{
  public  class PersnolBLL
    {
        PersnolDAL dal = new PersnolDAL();
        public string create(Persnol p)
        {
            if (dal.read(p))
            {

                return dal.create(p);

            }
            else
            {

                return "شخصی با این مشخصات ثبت شده است";
            }

        }
        public DataTable read()
        {

            return dal.read();



        }
        public DataTable read(string s)
        {

            return dal.read(s);



        }
        public Persnol read(int id)
        {

            return dal.read(id);
        }

         public string readp()
        {
            return dal.readp();
        }
        
        public Persnol Readp(string s)
        {
            return dal.Readp(s);
        }
        public Persnol Readk(string s)
        {
            return dal.Readk(s);
        }
        public string Update(Persnol p, int id)
        {

            return dal.Update(p, id);



        }
        public string Updatek(Persnol p, string s)
        {

            return dal.Update(p, s);



        }
        public string Delete(int id)
        {
            return dal.Delete(id);

        }
        public List<string> readpersonl()
        {
            return dal.readpersonl();
        }
        public List<string> readpersonl2()
        {
            return dal.readpersonl2();
        }
      
    }

}
