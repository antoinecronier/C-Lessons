using ClassLibrary2;
using ConsoleApplication1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        private Entity1 monEntity;
        private SubEntities.Entity1 monEntity2;
        static void Main(string[] args)
        {
            Logger logger = new Logger("Console Application",LogMode.CONSOLE, AlertMode.CONSOLE);
            logger.Log("plop");
        }
    }
}
