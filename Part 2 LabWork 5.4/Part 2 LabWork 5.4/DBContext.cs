using Part_2_LabWork_5._4.Models;
using System.Data.Entity;

namespace Part_2_LabWork_5._4
{
    public class DBContext : DbContext
    {
        public DBContext(): base("Pictures"){ }

        public DbSet<PictureModel> Pictures { get; set; }
        public DbSet<DescriptionModel> Descriptions { get; set; }
    }
}