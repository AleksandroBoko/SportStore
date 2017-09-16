using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStore
{
    class Program
    {
        static Shop shop;

        static void Main(string[] args)
        {
            shop = new Shop();
            shop.ShowMainManu();

            Console.ReadKey();
        }

        
    }
}
