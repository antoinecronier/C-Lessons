using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationMVCSecure.EnumManager;
using WebApplicationMVCSecure.Models;
using WebApplicationMVCSecure.Utils.Generator;

namespace WebApplicationMVCSecure.Database
{
    public class SQLFullDB : DbContext
    {
        public DbSet<User> DbSetUser { get; set; }
        public DbSet<Address> DbSetAddress { get; set; }
        public DbSet<Country> DbSetCountry { get; set; }
        public DbSet<UsersToAddresses> DbSetUsersToAddresses { get; set; }

        public SQLFullDB(DataConnectionResource dataConnectionResource)
            : base(EnumString.GetStringValue(dataConnectionResource))
        {
            switch (dataConnectionResource)
            {
                case DataConnectionResource.GENERICMYSQL:
                    break;
                case DataConnectionResource.LOCALMYSQL:
                    InitLocalSQL();
                    break;
                case DataConnectionResource.LOCALAPI:
                    break;
                case DataConnectionResource.LOCALMSSQLSERVER:
                    InitLocalSQL();
                    break;
                default:
                    break;
            }
        }

        public async void InitLocalSQL()
        {
            if (this.Database.CreateIfNotExists())
            {
                #region Users
                EntityGeneratorFakerTyper<User> generatorUser = new EntityGeneratorFakerTyper<User>();
                List<User> users = generatorUser.GenerateListItems(4) as List<User>;

                EntityGeneratorFakerTyper<Address> generatorAddress = new EntityGeneratorFakerTyper<Address>();
                List<Address> addresses = generatorAddress.GenerateListItems() as List<Address>;

                EntityGeneratorFakerTyper<Country> generatorCountry = new EntityGeneratorFakerTyper<Country>();
                List<Country> countries = generatorCountry.GenerateListItems() as List<Country>;

                EntityGeneratorFakerTyper<UsersToAddresses> generatorUsersToAddresses = new EntityGeneratorFakerTyper<UsersToAddresses>();
                List<UsersToAddresses> usersToAddresses = generatorUsersToAddresses.GenerateListItems() as List<UsersToAddresses>;

                SQLManager<User> managerUser = new SQLManager<User>(DataConnectionResource.LOCALMSSQLSERVER);
                await managerUser.Insert(users);

                SQLManager<Address> managerAddress = new SQLManager<Address>(DataConnectionResource.LOCALMSSQLSERVER);
                await managerAddress.Insert(addresses);

                SQLManager<Country> managerCountry = new SQLManager<Country>(DataConnectionResource.LOCALMSSQLSERVER);
                await managerCountry.Insert(countries);

                SQLManager<UsersToAddresses> managerUsersToAddresses = new SQLManager<UsersToAddresses>(DataConnectionResource.LOCALMSSQLSERVER);
                await managerUsersToAddresses.Insert(usersToAddresses);
                #endregion
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<User>()
            .HasOptional(p => p.Address)
            .WithMany()
            .HasForeignKey(p => p.AddressId)
            .WillCascadeOnDelete(true);

            modelBuilder.Entity<User>()
            .HasOptional(p => p.Addresses)
            .WithMany();

            modelBuilder.Entity<Address>()
            .HasOptional(p => p.Country)
            .WithMany()
            .HasForeignKey(p => p.CountryId)
            .WillCascadeOnDelete(true);*/

            /*modelBuilder.Entity<User>()
            .HasMany(a => a.Addresses)
            .WithMany()
            .Map(x =>
            {
                x.MapLeftKey("UserId");
                x.MapRightKey("AddressId");
                x.ToTable("UsersToAddresses");
            });*/

            /*modelBuilder.Entity<Address>()
            .HasMany(a => a.Users)
            .WithMany()
            .Map(x =>
            {
                x.MapLeftKey("AddressId");
                x.MapRightKey("UserId");
                x.ToTable("UsersToAddresses");
            });*/
        }
    }
}