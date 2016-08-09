using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationMVC.Models
{
    public class Address
    {
        private int? id;

        [Key]
        public int? Id
        {
            get { return id; }
            set { id = value; }
        }

        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private String city;

        public String City
        {
            get { return city; }
            set { city = value; }
        }

        private Country country;

        public Country Country
        {
            get { return country; }
            set { country = value; }
        }

        private String way;

        public String Way
        {
            get { return way; }
            set { way = value; }
        }

        private String number;

        public String Number
        {
            get { return number; }
            set { number = value; }
        }

        private String postalCode;

        public String PostalCode
        {
            get { return postalCode; }
            set { postalCode = value; }
        }

    }
}