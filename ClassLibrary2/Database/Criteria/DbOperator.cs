﻿using ClassLibrary2.EnumManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Database
{
    public enum DbOperator
    {
        [StringValue("=")]
        EQUAL,
        [StringValue(">")]
        SUPERIOR,
        [StringValue("<")]
        INFERIOR,
        [StringValue(">=")]
        SUPERIOREQUAL,
        [StringValue("<=")]
        INFERIOREQUAL,
        [StringValue("IN")]
        IN,
        [StringValue("NOT IN")]
        NOTIN,
        [StringValue("IS NULL")]
        ISNULL,
        [StringValue("IS NOT NULL")]
        ISNOTNULL,
        [StringValue("LIKE")]
        LIKE
    }
}
