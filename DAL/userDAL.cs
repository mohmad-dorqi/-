using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class userDAL
    {
        DB db = new DB();
        public string create(User u)
        {
            try
            {
                db.Users.Add(u);
                db.SaveChanges();
                return "ثبتنام شما با موفقیت انجام شد";
            }
            catch (Exception e)
            {

                return "مشکل در ثبت اطلاعات" + e.Message;
            }



        }
        public bool reg()
        {
            if (db.Users.Count() == 0)
            {
                return true;

            }
            else
            {
                return false;
            }


        }
        public byte reg1()
        {
            if (db.Users.Count() > 0)
            {
                return 1;

            }
            else
            {
                return 0;
            }
        }
        public byte read(string user, string pass)
        {
            if (db.Users.Where(i => i.Username == user && i.Password == pass).Count() > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public string Update(User u, string s)
        {
            try
            {
                var q = db.Users.Where(i => i.kodmli == s).FirstOrDefault();
                if (q != null)
                {
                    q.Name = u.Name;
                    q.kodmli = u.kodmli;
                    q.Username = u.Username;
                    db.SaveChanges();

                    return "رمز عبور با موفقیت تغییر کرد";


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
        public byte reg2(string s)
        {
            if (db.Users.Where(i => i.kodmli == s).Count() > 0)
            {
                return 1;

            }
            else
            {
                return 0;
            }
        }
        public User Readk(string s)
        {
            return db.Users.Where(i => i.kodmli == s).SingleOrDefault();

        }
    }
}
