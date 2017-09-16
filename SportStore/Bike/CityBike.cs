using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStore.Bike
{
    class CityBike:BaseBike
    {
        protected bool HasTrunk;

        public CityBike(string name, float price, float weight, bool hasTrunk) : base(name, price, weight)
        {
            HasTrunk = hasTrunk;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $"Trunk:{HasTrunk}";
        }

    }
}
