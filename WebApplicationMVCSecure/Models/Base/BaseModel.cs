using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVCSecure.Models.Base
{
    public abstract class BaseModel
    {
        private Int32 id;

        [Key]
        public Int32 Id
        {
            get { return id; }
            private set { id = value; }
        }
    }
}