using Part_2_LabWork_7._2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Part_2_LabWork_7._2
{
    public class DBContext : DbContext
    {
        public DBContext() : base("BookDB") { }
        public DbSet<BookModel> Books { get; set; }

    }
}