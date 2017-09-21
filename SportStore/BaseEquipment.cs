using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStore
{

    class BaseEquipment
    {
        public string Name { get; protected set; }
        public float Price { get; protected set; }
        public float RentPrice { get { return Price * 0.01f; } }

        public BaseEquipment(string name, float price)
        {
            Name = name;
            Price = price;
        }

        public virtual string GetInfo()
        {
            return $"Name:{Name}; Price:{Price}; Rent price:{RentPrice}; ";
        } 

        public string GeTypeInfo()
        {
            return this.GetType().Name;
        }
    }
}
