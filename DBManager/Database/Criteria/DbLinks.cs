using DBManager.EnumManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManager.Database
{
    public enum DbLinks
    {
        [StringValue("INNER JOIN")]
        INNERJOIN,
        [StringValue("FROM")]
        FROM
    }
}
