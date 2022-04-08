using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
   public class backupBLL
    {
        backupDAL dal = new backupDAL();
        public void backup(string path)
        {
            dal.backup(path);
        }
        public void restore(string path)
        {
            dal.restore(path);
        }
    }
}
