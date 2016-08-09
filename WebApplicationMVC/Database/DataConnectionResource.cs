using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationMVC.EnumManager;

namespace WebApplicationMVC.Database
{
    public enum DataConnectionResource : Int32
    {
        [StringValue("Server=myServer;Port=3306;Database=db_name;Uid=userName;Pwd=password")]
        GENERICMYSQL = 1,
        [StringValue("Server=127.0.0.1;Port=3306;Database=db_asp;Uid=root;Pwd=''")]
        LOCALMYSQL = 2,
        [StringValue("Server=127.0.0.1;Database=db_asp;Uid=root;Pwd=''")]
        LOCALMYSQLNOPORT = 3,
        [StringValue("http://localhost:63684/api/")]
        LOCALAPI = 4,
    }
}
