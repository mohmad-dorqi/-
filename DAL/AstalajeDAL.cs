using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BE;


namespace DAL
{
   public class AstalajeDAL
    {
        DB db = new DB();
        public string Create(Astalaje a, Persnol p)
        {
            try
            {
               a.Persnol= db.Persnols.Find(p.id);
                db.Astalajes.Add(a);
                db.SaveChanges();
                return "عملیات ثبت با موفقیت انجام شد";
            }
            catch (Exception e)
            {

                return "عملیات ثبت با خطا مواجه شد\n" + e.Message;
            }



        }
        //برای خواندن بدون شرط
        public DataTable Read()
        {
            SqlCommand cmd = new SqlCommand("dbo.astalaje6");

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
        //برای جستجوی مرخصی ها براساس نام و کدملی
        public DataTable Read(string s)
        {
            SqlCommand cmd = new SqlCommand("dbo.astalaje2");
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
            SqlCommand cmd = new SqlCommand("dbo.ast1");
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
        public Astalaje Read(int id)
        {

            return db.Astalajes.Where(i => i.id == id).FirstOrDefault();
        }
        public string Update(Astalaje a, int id)
        {
            var q = db.Astalajes.Where(i => i.id == id).SingleOrDefault();
            try
            {
                if (q != null)
                {
                    q.Title = a.Title;
                    q.Text = a.Text;
                    q.RoztAstlaje = a.RoztAstlaje;
                    q.TarekhtAstlaje = a.TarekhtAstlaje;
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
                var q = db.Astalajes.Where(i => i.id == id).FirstOrDefault();
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
