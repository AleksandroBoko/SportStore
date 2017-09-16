using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStore.Boat
{
    class BaseBoat:BaseEquipment
    {
        protected int CountSeats;

        public BaseBoat(string name, float price, int countSeats) : base(name, price)
        {
            CountSeats = countSeats;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $"Number of seats:{CountSeats}, ";
        }
    }
}
