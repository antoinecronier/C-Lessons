using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApplicationMVCSecure.Models.Base;
using WebApplicationMVCSecure.Utils.Generator;
using WebApplicationMVCSecure.Utils.Generator.Attributs;

namespace WebApplicationMVCSecure.Models
{
    public class User : BaseModel
    {
        private String firstname;
        
        [FakerTyper(TypeEnumCustom.USERFIRSTNAME)]
        public String Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }

        private String lastname;
        
        [FakerTyper(TypeEnumCustom.USERLASTNAME)]
        public String Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        private int? addressid;

        public int? AddressId
        {
            get { return addressid; }
            set { addressid = value; }
        }

        private Address address;

        [ForeignKey("AddressId")]
        public Address Address
        {
            get { return address; }
            set { address = value; }
        }
    }
}