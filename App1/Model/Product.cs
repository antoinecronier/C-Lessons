﻿using App1.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Model
{
    public class Product : EntityBase
    {
        #region attributs
        private int id;
        private String name;
        private int value;
        private int clientId;
        
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

        public int Value
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
        
        public int ClientId
        {
            get { return clientId; }
            set { clientId = value; }
        }
        #endregion

        #region constructor
        public Product()
        {

        }
        #endregion

        #region functions
        #endregion
    }
}
