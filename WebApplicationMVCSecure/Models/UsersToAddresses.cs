using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationMVCSecure.Models.Base;

namespace WebApplicationMVCSecure.Models
{
    public class UsersToAddresses : BaseModel
    {
        private int? userId;

        public int? UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private int? addressId;

        public int? AddressId
        {
            get { return addressId; }
            set { addressId = value; }
        }

    }
}