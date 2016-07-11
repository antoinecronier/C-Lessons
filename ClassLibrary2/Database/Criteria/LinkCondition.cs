using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Database
{
    public class LinkCondition
    {
        private String columnStart;

        public String ColumnStart
        {
            get { return columnStart; }
            set { columnStart = value; }
        }

        private String columnArrive;

        public String ColumnArrive
        {
            get { return columnArrive; }
            set { columnArrive = value; }
        }

        public LinkCondition()
        {

        }

        public LinkCondition(String columnStart, String columnArrive)
        {
            this.ColumnStart = columnStart;
            this.ColumnArrive = columnArrive;
        }

        public String MySQLCompute()
        {
            return "ON " + this.ColumnStart + " = " + this.ColumnArrive;
        }
    }
}
