using ClassLibrary2.EnumManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Database
{
    public class Criteria
    {
        private List<Criterion> criterions;

        public List<Criterion> Criterions
        {
            get { return criterions; }
            set { criterions = value; }
        }

        private DbAction dbAction;

        public DbAction DbAction
        {
            get { return dbAction; }
            set { dbAction = value; }
        }

        private DbTablesLinks dbTablesLinks;

        public DbTablesLinks DbTablesLinks
        {
            get { return dbTablesLinks; }
            set { dbTablesLinks = value; }
        }

        private String dbSelector;

        public String DbSelector
        {
            get { return dbSelector; }
            set { dbSelector = value; }
        }


        public Criteria()
        {
            this.Criterions = new List<Criterion>();
            this.DbTablesLinks = new DbTablesLinks();
        }

        public Criteria(DbAction action, String dbSelector)
        {
            this.Criterions = new List<Criterion>();
            this.DbTablesLinks = new DbTablesLinks();
            this.DbAction = action;
            this.DbSelector = dbSelector;
        }

        public void AddDbLink(String table, DbLinks link, LinkCondition condition = null)
        {
            Dictionary<DbLinks, LinkCondition> links = new Dictionary<DbLinks, LinkCondition>();
            links.Add(link, condition);
            this.DbTablesLinks.Links.Add(table, links);
        }

        public void AddCriterion(Criterion criterion)
        {
            this.Criterions.Add(criterion);
        }

        public String MySQLCompute()
        {
            String result = EnumString.GetStringValue(this.DbAction);
            result += " ";
            result += this.DbSelector;
            result += " ";
            result += DbTablesLinks.MySQLCompute();

            if (Criterions.Count > 0)
            {
                result += "WHERE";
                result += " ";
            }

            foreach (var item in Criterions)
            {
                result += item.MySQLCompute();
                result += " ";
            }
            return result;
        }
    }
}
