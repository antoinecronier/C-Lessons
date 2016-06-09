using App1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.BaseItems
{
    public class BaseItemClient : Client
    {
        public BaseItemClient()
        {
            base.Name = "Hugue";
            base.Surname = "Raoul";
            base.Sold = 100;
            base.Bill = 0;
        }
    }
}
