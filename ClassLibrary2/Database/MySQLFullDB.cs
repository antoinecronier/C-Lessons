using ClassLibrary2.Entities;
using ClassLibrary2.EnumManager;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Database
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class MySQLFullDB : DbContext
    {
        public DbSet<Class1> DbSetClass1 { get; set; }
        public DbSet<Class2> DbSetClass2 { get; set; }

        public MySQLFullDB(DataConnectionResource dataConnectionResource)
            : base(EnumString.GetStringValue(dataConnectionResource))
        {
            switch (dataConnectionResource)
            {
                case DataConnectionResource.GENERICMYSQL:
                    break;
                case DataConnectionResource.LOCALMYSQL:
                    InitLocalMySQL();
                    break;
                case DataConnectionResource.LOCALAPI:
                    break;
                default:
                    break;
            }
        }

        public void InitLocalMySQL()
        {

            if (this.Database.CreateIfNotExists())
            {
                //Setup base datas to load
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /*modelBuilder.Entity<Class1>()
                .HasRequired(c => c.Address)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Class2>()
                .HasRequired(c => c.Client)
                .WithMany()
                .WillCascadeOnDelete(false);*/
        }
    }
}