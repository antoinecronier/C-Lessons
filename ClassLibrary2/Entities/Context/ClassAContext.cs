using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Entities.Context
{
    public class ClassAContext : DbContext
    {
        public ClassAContext() : base()
        {

        }

        public DbSet<ClassA> ClassAs { get; set; }
    }
}
