using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStore.Bike
{
    class BaseBike: BaseEquipment
    {
        protected float Weight;

        public BaseBike(string name, float price, float weight) : base(name, price)
        {
            Weight = weight;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $"Weigth:{Weight}; ";
        }
    }
}
