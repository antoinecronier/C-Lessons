using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplicationMVCSecure.Models.Base;

namespace WebApplicationMVCSecure.Models
{
    public class Country : BaseModel
    {
        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}