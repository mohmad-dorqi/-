using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BE;
using System.Data.SqlClient;

namespace DAL
{
   public class tasveqeDAL
    {
        DB db = new DB();

        public string Create(Tashveqhe t,Persnol p)
        {
            try
            {
                t.Persnol = db.Persnols.Find(p.id);
                db.Tashveqhes.Add(t);
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
            SqlCommand cmd = new SqlCommand("dbo.tash2");
        
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
            SqlCommand cmd = new SqlCommand("dbo.searchtash2");
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
            SqlCommand cmd = new SqlCommand("dbo.t2");
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

        public Tashveqhe read(int id)
        {

            return db.Tashveqhes.Where(i => i.id == id).FirstOrDefault();
        }
        public string Update(Tashveqhe T,int id)
        {
            var q = db.Tashveqhes.Where(i => i.id == id).SingleOrDefault();
            try
            {
                if (q !=null)
                {
                    q.Title = T.Title;
                    q.Text = T.Text;
                    q.Roztashveqh = T.Roztashveqh;
                    q.Tarekhtashveqh = T.Tarekhtashveqh;
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
        public string Delete( int id)
        {

            try
            {
                var q = db.Tashveqhes.Where(i => i.id == id).FirstOrDefault();
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
