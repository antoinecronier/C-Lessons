﻿using ClassLibrary2.EnumManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Database
{
    public enum DbSelector
    {
        [StringValue("*")]
        ALL,
        [StringValue("")]
        NONE,
    }
}