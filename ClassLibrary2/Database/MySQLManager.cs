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
        //public MySQLManager() : base(EnumString.GetStringValue(DataConnectionResource.LOCALMYQSL))
        //{
            
        //}

        public MySQLManager(DataConnectionResource dataConnectionResource) 
            : base(EnumString.GetStringValue(dataConnectionResource))
        {

        }

        //public MySQLManager(String connection) : base(connection)
        //{

        //}

        public DbSet<TEntity> DbSetT { get; set; }

        public void Insert(TEntity item)
        {
            this.DbSetT.Add(item);
            this.SaveChanges();
        }

        public void Insert(List<TEntity> items)
        {
            foreach (var item in items)
            {
                this.DbSetT.Add(item);
            }
            this.SaveChanges();
        }

        public void Update(TEntity item)
        {
            this.Entry<TEntity>(item);
            this.SaveChanges();
        }

        public void Update(List<TEntity> items)
        {
            foreach (var item in items)
            {
                this.Entry<TEntity>(item);
            }
            this.SaveChanges();
        }

        public TEntity Get(int id)
        {
            return this.DbSetT.Find(id) as TEntity;
        }

        public List<TEntity> GetAll()
        {
            List<TEntity> result = new List<TEntity>();
            var temp = base.Set<TEntity>();
            result.AddRange(temp);
            return result;
        }
    }
}
