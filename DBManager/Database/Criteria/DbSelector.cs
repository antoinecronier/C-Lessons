using DBManager.EnumManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManager.Database
{
    public enum DbSelector
    {
        [StringValue("*")]
        ALL,
        [StringValue("")]
        NONE,
    }
}
