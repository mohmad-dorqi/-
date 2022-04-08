using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public  class backupDAL
    {

        public void backup(string path)
        {
            //string cmd = @"backup database TADBER to disk = '" + path + @"\ tadber.bak'";
            //SqlConnection con = new SqlConnection("Data Source=DESKTOP-LVGHM1F;Initial Catalog=TADBER;Integrated Security=true");
            ////  con.Open();
            //var sqladapter = new SqlDataAdapter(cmd, con);
            //var comondbulder = new SqlCommandBuilder(sqladapter);
            //var ds = new DataSet();
            //sqladapter.Fill(ds);
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-LVGHM1F;Initial Catalog=TADBER;Integrated Security=true");
            con.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = con;
            cm.CommandText = @"backup database TADBER to disk = '" + path + @"\ TADBER.bak'";
            cm.ExecuteNonQuery();
            con.Close();


        }
        public void restore(string path)
        {

            //string cmd = @"restore database TADBER from disk = '" + path +"'with replace";
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-LVGHM1F;Initial Catalog=master;Integrated Security=true");
             con.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = con;
            cm.CommandText= @"restore database TADBER from disk = '" + path + "' with replace";
            cm.ExecuteNonQuery();
            con.Close();
        }
    }
}
