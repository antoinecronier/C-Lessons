using App1.Model.Base;
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
        private int id;
        private String name;
        private String surname;
        private int sold;
        private int bill;
        private List<Product> items;
        #endregion

        #region properties
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

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

        internal List<Product> Items
        {
            get
            {
                return items;
            }

            set
            {
                items = value;
                OnPropertyChanged("Items");
            }
        }
        #endregion

        #region constructor
        public Client()
        {

        }
        #endregion

        #region functions
        #endregion
    }
}
