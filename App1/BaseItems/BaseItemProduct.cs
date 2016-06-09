using App1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.BaseItems
{
    class BaseItemProduct : Product
    {
        public BaseItemProduct()
        {
            base.Name = "salade";
            base.Value = 10;
        }

        public BaseItemProduct(EnumProduct product)
        {
            base.Name = Enum.GetName(typeof(EnumProduct), product);
            base.Value = (int) product;
        }

        public List<Product> getItemList()
        {
            List<Product> result = new List<Product>();
            result.Add(new BaseItemProduct(EnumProduct.CHOU));
            result.Add(new BaseItemProduct(EnumProduct.SALADE));
            result.Add(new BaseItemProduct(EnumProduct.TOMATE));
            result.Add(new BaseItemProduct(EnumProduct.POIVRON));
            result.Add(new BaseItemProduct(EnumProduct.PATATE));
            return result;
        }

        public enum EnumProduct
        {
            SALADE = 10,
            CHOU = 5,
            TOMATE = 2,
            POIVRON = 6,
            PATATE = 10
        }
    }
}
