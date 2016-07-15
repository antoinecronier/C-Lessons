using SQLite.Net;
using SQLite.Net.Interop;
using SQLite.Net.Platform.WinRT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    public class SQLiteManager<T> : SQLiteConnection where T : class
    {
        public SQLiteManager(String dbPath) : base(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), dbPath)
        {
            try
            {
                this.CreateTable(typeof(T));
            }
            catch (Exception)
            {
                this.MigrateTable(typeof(T));
            }
        }
    }
}
