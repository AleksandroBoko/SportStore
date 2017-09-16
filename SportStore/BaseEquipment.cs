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
        protected float Price;

        public BaseEquipment(string name, float price)
        {
            Name = name;
            Price = price;
        }

        public virtual string GetInfo()
        {
            return $"Name:{Name}; Price{Price}; ";
        } 

        public string GeTypeInfo()
        {
            return this.GetType().Name;
        }
    }
}
