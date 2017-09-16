using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStore.Ball
{
    class TennisBall:BaseBall
    {
        public enum TypeCourt
        {
            Ground,
            Plant
        }

        protected TypeCourt Court;

        public TennisBall(string name, float price, float diameter, TypeCourt court): base(name, price, diameter)
        {
            Court = court;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $"Type of court:{Court.ToString()};";
        }
    }
}
