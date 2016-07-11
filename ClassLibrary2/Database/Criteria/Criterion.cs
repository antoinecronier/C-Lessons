using ClassLibrary2.Entities.Base;
using ClassLibrary2.EnumManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Database
{
    public class Criterion
    {
        private DbOperator dbOperator;

        public DbOperator DbOperator
        {
            get { return dbOperator; }
            set { dbOperator = value; }
        }

        private DbVerb verb;

        public DbVerb Verb
        {
            get { return verb; }
            set { verb = value; }
        }

        private object value;

        public object Value
        {
            get { return value; }
            set { this.value = value; }
        }

        private String dbColumn;

        public String DbColumn
        {
            get { return dbColumn; }
            set { dbColumn = value; }
        }


        public Criterion()
        {

        }

        public Criterion(DbVerb verb, String dbColumn, DbOperator dbOperator, object value)
        {
            this.Verb = verb;
            this.DbColumn = dbColumn;
            this.DbOperator = dbOperator;
            this.Value = value;
        }

        public String MySQLCompute()
        {
            return EnumString.GetStringValue(this.Verb) + " " + this.DbColumn + " " + EnumString.GetStringValue(this.DbOperator) + " " + this.Value.ToString();
        }
    }
}
