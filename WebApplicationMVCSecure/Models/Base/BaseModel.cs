using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVCSecure.Models.Base
{
    public abstract class BaseModel
    {
        private Int32 id;

        [Key]
        [JsonProperty("Id")]
        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}