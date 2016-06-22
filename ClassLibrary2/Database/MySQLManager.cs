using ClassLibrary1;
using ClassLibrary2.Entities.Context;
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
    public class MySQLManager<TEntity> : DbContext where TEntity : class
    {
        public MySQLManager() : base(EnumString.GetStringValue(ConnectionStringEnum.CURRENT))
        {
            
        }

        public DbSet<TEntity> DbSetT { get; set; }

        public void InsertInMySQL(TEntity item)
        {
            this.DbSetT.Add(item);
            this.SaveChanges();
        }

        public void InsertInMySQL(List<TEntity> items)
        {
            foreach (var item in items)
            {
                this.DbSetT.Add(item);
            }
            this.SaveChanges();
        }

        public TEntity GetFromMySQL(int id)
        {
            return this.DbSetT.Find(id) as TEntity;
        }

        public List<TEntity> GetFromMySQL()
        {
            return this.DbSetT.Find() as List<TEntity>;
        }
    }
}
