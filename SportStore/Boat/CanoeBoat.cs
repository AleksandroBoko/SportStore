using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStore.Boat
{
    class CanoeBoat : BaseBoat
    {
        public enum TypePaddle
        {
            Long,
            Middle,
            Short
        }

        protected TypePaddle Paddle;

        public CanoeBoat(string name, float price, int countSeats, TypePaddle paddle) : base(name, price, countSeats)
        {
            Paddle = paddle;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $"Type of paddle:{Paddle.ToString()}";
        }
    }
}
