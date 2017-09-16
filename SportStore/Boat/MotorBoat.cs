using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStore.Boat
{

    class MotorBoat:BaseBoat
    {
        protected float MotorPower;

        public MotorBoat(string name, float price, int countSeats, float motorPower) : base(name, price, countSeats)
        {
            MotorPower = motorPower;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $"Power:{MotorPower}";
        }
    }
}
