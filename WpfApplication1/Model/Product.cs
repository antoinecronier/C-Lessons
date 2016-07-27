using App1.Model.Base;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace App1.Model
{
    public class Product : EntityBase
    {
        #region attributs
        private int id;
        private String name;
        private double value;
        private Stock myVar;
        #endregion

        #region properties
        [PrimaryKey, AutoIncrement]
        [Column("id")]
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

        public double Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
                OnPropertyChanged("Value");
            }
        }

        public Stock Stock
        {
            get { return myVar; }
            set { myVar = value; }
        }

        #endregion

        #region constructor
        public Product()
        {
            this.Stock = new Stock();
            this.Stock.Handler += Stock_Handler;
        }

        #endregion

        #region functions
        private void Stock_Handler(object sender, EventArgs e)
        {
            if (this.Stock.Number > 10)
            {
                this.Value *= Stock.UP;
            }
            else
            {
                this.Value *= Stock.DOWN;
                MessageBox.Show("Low Stock");
            }
            
        }
        #endregion
    }
}
