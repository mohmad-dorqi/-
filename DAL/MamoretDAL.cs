using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
public    class MamoretDAL
    {
        DB db = new DB();
        public string Create(Mamoret m, Persnol p)
        {
            try
            {
                m.Persnol = db.Persnols.Find(p.id);
                db.Mamorets.Add(m);
                db.SaveChanges();
                return "عملیات ثبت با موفقیت انجام شد";
            }
            catch (Exception e)
            {

                return "عملیات ثبت با خطا مواجه شد\n" + e.Message;
            }



        }
        public DataTable Read()
        {
            SqlCommand cmd = new SqlCommand("dbo.ASA");

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
        public DataTable Read(string s)
        {
            SqlCommand cmd = new SqlCommand("dbo.mamoret2");
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

        public DataTable Readt(string s)
        {
            SqlCommand cmd = new SqlCommand("dbo.m1");
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
        public Mamoret read(int id)
        {

            return db.Mamorets.Where(i => i.id == id).FirstOrDefault();
        }
        public string Update(Mamoret es, int id)
        {
            var q = db.Mamorets.Where(i => i.id == id).SingleOrDefault();
            try
            {
                if (q != null)
                {
                    q.Title = es.Title;
                    q.Text = es.Text;                 
                    q.TarekMamoret = es.TarekMamoret;
                    db.SaveChanges();
                    return "ویرایش با موفقیت انجام شد";

                }
                else
                {
                    return "مرخصی تشویقی مورد نظر یافت نشد";
                }
            }
            catch (Exception e)
            {

                return "ویرایش اطلاعات با مشکل مواجه شد \n" + e.Message;
            }


        }
        public string Delete(int id)
        {

            try
            {
                var q = db.Mamorets.Where(i => i.id == id).FirstOrDefault();
                if (q != null)
                {
                    q.Deletestatus = true;
                    db.SaveChanges();

                    return "عملیات حذف با موفقیت انجام شد";
                }
            }
            catch (Exception e)
            {

                return "عملیات با خطا مواجه شد\n" + e.Message;
            }

            return "";

        }
    }
}
