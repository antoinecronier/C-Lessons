using DBManager.Entities.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManager.Parser.DBParser
{
    public class ObjectToMySQL<T> where T : class
    {
        List<String> parsed = new List<String>();

        public ObjectToMySQL(String table)
        {

        }

        public void GenerateForTable(int number)
        {
            EntityGenerator<T> generator = new EntityGenerator<T>();
            for (int i = 0; i < number; i++)
            {
                Parse(generator.GenerateItem());
            }
            SendToFile();
        }

        public void SendToFile()
        {

        }

        public void Parse(T item)
        {

        }
    }
}
