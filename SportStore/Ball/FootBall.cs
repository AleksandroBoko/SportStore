using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStore.Ball
{
    class Football : BaseBall
    {
        public enum TypeGame
        {
            MiniFootball,
            Soccer,
            BeachFotball
        }
        
        protected TypeGame Game;       

        public Football(string name, float price, float diameter, TypeGame game) : base(name, price, diameter)
        {
            Game = game;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $"Type of game:{Game.ToString()}";
        }

    }

    
}
