using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationMVC.Models
{
    public class User
    {
        private int? id;
        
        [Key]
        public int? Id
        {
            get { return id; }
            set { id = value; }
        }

        private String firstname;
        
        public String Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }

        private String lastname;
        
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

        private List<Address> addresses;

        public List<Address> Addresses
        {
            get { return addresses; }
            set { addresses = value; }
        }

    }
}