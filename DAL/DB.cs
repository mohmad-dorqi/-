using BE;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;


namespace DAL
{
    class DB : DbContext
    {
        public DB() : base("con3")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Tashveqhe> Tashveqhes { get; set; }
        public DbSet<Persnol> Persnols { get; set; }
        public DbSet<Mamoret> Mamorets { get; set; }
        public DbSet<Esthqhaqhe> Esthqhaqhes { get; set; }
        public DbSet<Astalaje> Astalajes { get; set; }




    }
}
