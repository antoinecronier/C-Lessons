using ClassLibrary2.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Entities
{
    [Table(Class1Scheme.TABLE)]
    public class Class1
    {
        private Int32 id;
        private String name;
        private String surname;
        private Int32 addressId;
        private Class2 address;
        private List<Class2> addresses;

        [Key]
        [Column(Class1Scheme.ID)]
        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }

        [Column(Class1Scheme.NAME)]
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        [Column(Class1Scheme.SURNAME)]
        public String Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        [Column(Class1Scheme.ADDRESS_ID)]
        public Int32 AddressId
        {
            get { return addressId; }
            set { addressId = value; }
        }

        [Column(Class1Scheme.ADDRESS)]
        [ForeignKey("AddressId")]
        public Class2 Address
        {
            get { return address; }
            set { address = value; }
        }

        [Column(Class1Scheme.ADDRESSES)]
        public List<Class2> Addresses
        {
            get { return addresses; }
            set { addresses = value; }
        }

        public Class1()
        {
            Addresses = new List<Class2>();
        }
    }
}
