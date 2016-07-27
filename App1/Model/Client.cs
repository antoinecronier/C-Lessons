using App1.Model.Base;
using ClassLibrary1;
using ClassLibrary2.Attributs;
using ClassLibrary2.Entities.Generator;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Model
{
    public class Client : EntityBase
    {
        #region attributs
        private String name;
        private String surname;
        private int sold;
        private int bill;

        private List<Product> products;

        [OneToMany]
        public List<Product> Products
        {
            get { return products; }
            set { products = value; }
        }

        #endregion

        #region properties
        
        [FakerTyper(TypeEnumCustom.NAME)]
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        [FakerTyper(TypeEnumCustom.SURNAME)]
        public string Surname
        {
            get
            {
                return surname;
            }

            set
            {
                surname = value;
                OnPropertyChanged("Surname");
            }
        }

        public int Sold
        {
            get
            {
                return sold;
            }

            set
            {
                sold = value;
                OnPropertyChanged("Sold");
            }
        }

        public int Bill
        {
            get
            {
                return bill;
            }

            set
            {
                bill = value;
                OnPropertyChanged("Bill");
            }
        }
        #endregion

        #region constructor
        public Client()
        {

        }

        public Client(String name, String surname, int sold, int bill)
        {
            this.name = name;
            this.surname = surname;
            this.sold = sold;
            this.bill = bill;
        }
        #endregion

        #region functions
        #endregion
    }
}
