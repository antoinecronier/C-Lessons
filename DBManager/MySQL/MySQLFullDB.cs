using DBManager.Database;
using DBManager.Entities;
using DBManager.Entities.Base;
using DBManager.Entities.Generator;
using DBManager.EnumManager;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManager.Mysql
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class MySQLFullDB : DbContext
    {
        public DbSet<EntityBase> DbSetClass { get; set; }

        public MySQLFullDB(DataConnectionResource dataConnectionResource)
            : base(EnumString.GetStringValue(dataConnectionResource))
        {
            switch (dataConnectionResource)
            {
                case DataConnectionResource.GENERICMYSQL:
                    break;
                case DataConnectionResource.LOCALMYSQL:
                    break;
                case DataConnectionResource.LOCALAPI:
                    break;
                default:
                    break;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}