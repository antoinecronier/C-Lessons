using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationMVC.EnumManager;
using WebApplicationMVC.Models;
using WebApplicationMVC.Utils.Generator;

namespace WebApplicationMVC.Database
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class MySQLFullDB : DbContext
    {
        public DbSet<User> DbSetUser { get; set; }
        public DbSet<Address> DbSetAddress { get; set; }

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

        public async void InitLocalMySQL()
        {

            if (this.Database.CreateIfNotExists())
            {
                //Setup base datas to load
                EntityGeneratorFakerTyper<User> generatorUser = new EntityGeneratorFakerTyper<User>();
                List<User> users = generatorUser.GenerateListItems() as List<User>;

                EntityGeneratorFakerTyper<Address> generatorAddress = new EntityGeneratorFakerTyper<Address>();
                foreach (var item in users)
                {
                    item.Addresses = generatorAddress.GenerateListItems() as List<Address>;
                }

                MySQLManager<User> managerClass1 = new MySQLManager<User>(DataConnectionResource.LOCALMYSQL);
                await managerClass1.Insert(users);
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}