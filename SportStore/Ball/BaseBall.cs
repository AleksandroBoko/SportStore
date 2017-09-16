using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStore.Ball
{
    class BaseBall: BaseEquipment
    {
        protected float Diameter;

        public BaseBall(string name, float price, float diameter):base(name, price)
        {
            Diameter = diameter;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $"Diameter:{Diameter.ToString()}; ";
        }
    }
}
