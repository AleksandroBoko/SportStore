using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStore.Bike
{
    class OffRoadBike : BaseBike
    {
        protected int CountDamper;

        public OffRoadBike(string name, float price, float weight, int countDamper) : base(name, price, weight)
        {
            CountDamper = countDamper;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $"Number of Damper:{CountDamper}";
        }
    }
}
