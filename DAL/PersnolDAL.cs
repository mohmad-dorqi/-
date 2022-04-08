using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using BE;

namespace DAL
{
    public class PersnolDAL
    {
        DB db = new DB();
        public string create(Persnol p)
        {
            try
            {
                db.Persnols.Add(p);
                db.SaveChanges();
                return "اطلاعات ثبت شد";
            }
            catch (Exception e)
            {

                return "مشکل در ثبت اطلاعات" + e.Message;
            }



        }
        public DataTable read()
        {
            string cmd = "SELECT  id, NameFamily AS [نام ونام خانوادگی], Kodmili AS کدملی, roz AS [مرخصی باقی مانده]FROM dbo.Persnols WHERE(Deletestatus = 0)";
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-LVGHM1F;Initial Catalog=TADBER;Integrated Security=true");
            //  con.Open();
            var sqladapter = new SqlDataAdapter(cmd, con);
            var comondbulder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);

            return ds.Tables[0];
        }
        public DataTable read(string s)
        {
            SqlCommand cmd = new SqlCommand("dbo.searchpersonl");
            cmd.Parameters.AddWithValue("@search", s);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-LVGHM1F;Initial Catalog=TADBER;Integrated Security=true");
            cmd.Connection = con;
            con.Open();

            var sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = cmd;
            var comondbulder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);

            return ds.Tables[0];


        }
        public string readp()
        {
          return db.Persnols.Where(i=> i.Deletestatus==false).Count().ToString();
        }
        public bool read(Persnol p)
        {
            var q = db.Persnols.Where(i => p.Kodmili == i.Kodmili);
            if (q.Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Persnol Readp(string s)
        {
            return db.Persnols.Where(i => i.NameFamily == s && i.Deletestatus==false).SingleOrDefault();

        }
        public Persnol Readk(string s)
        {
            return db.Persnols.Where(i => i.Kodmili == s && i.Deletestatus==false).SingleOrDefault();

        }
        public Persnol read(int id)
        {
         
            
                return db.Persnols.Where(i => i.id == id).FirstOrDefault();
            
          
        }
        public string Update(Persnol p, int id)
        {
            try
            {
                var q = db.Persnols.Where(i => i.id == id).FirstOrDefault();
                if (q != null)
                {
                    q.NameFamily = p.NameFamily;
                    q.Kodmili = p.Kodmili;
                    q.roz = p.roz;
                    db.SaveChanges();

                    return "اطلاعات با موفقیت ثبت شد";


                }
                else
                {
                    return "شخصی با این اطلاعات پیدا نشد";
                }

            }
            catch (Exception e)
            {
                return "عملیات با خطا مواجه شد! \n" + e.Message;

            }



        }
        public string Update(Persnol p, string s)
        {
            try
            {
                var q = db.Persnols.Where(i => i.Kodmili == s).FirstOrDefault();
                if (q != null)
                {
                    q.NameFamily = p.NameFamily;
                    q.Kodmili = p.Kodmili;
                    q.roz = p.roz;
                    db.SaveChanges();

                    return "اطلاعات با موفقیت ثبت شد";


                }
                else
                {
                    return "شخصی با این اطلاعات پیدا نشد";
                }

            }
            catch (Exception e)
            {
                return "عملیات با خطا مواجه شد! \n" + e.Message;

            }



        }

        public string Delete(int id)
        {
            try
            {
                var q = db.Persnols.Where(i => i.id == id).FirstOrDefault();
                if (q != null)
                {
                    q.Deletestatus = true;
                    db.SaveChanges();

                    return "عملیات حذف با موفقیت انجام شد";
                }
                else
                {
                    return "پرسنل مورد نظر یافت نشد";
                }
            }
            catch (Exception e)
            {

                return "عملیات با خطا مواجه شد\n" + e.Message;
            }

            
        }
        public List<string> readpersonl()
        {
            return db.Persnols.Where(i => i.Deletestatus == false).Select(i => i.NameFamily).ToList();

        }
        public List<string> readpersonl2()
        {
            return db.Persnols.Where(i => i.Deletestatus == false).Select(i => i.Kodmili).ToList();
        }

    }
}
