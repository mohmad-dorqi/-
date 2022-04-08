using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;


namespace BLL
{
    public class userBLL
    {
        userDAL dal = new userDAL();

        private string Encode(string pass)
        {
            byte[] encdata_byte = new byte[pass.Length];
            encdata_byte = System.Text.Encoding.UTF8.GetBytes(pass);
            string encodeddata = Convert.ToBase64String(encdata_byte);
            return encodeddata;

        }

            public string create(User u)
        {
            u.Password = Encode(u.Password);
            return dal.create(u);
        }
        public bool reg()
        {
            return dal.reg();
        }
        public byte reg1()
        {
            return dal.reg1();
        }
        public byte read(string user, string pass)
        {
            
            return dal.read(user,  Encode (pass));

        }
        public string Update(User u, string s)
        {
            u.Password = Encode(u.Password);
            return dal.Update(u, s);
        }
        public byte reg2(string s)
        {

            return dal.reg2(s);
        }

        public User Readk(string s)
        {
            return dal.Readk(s);
        }
    }
}
