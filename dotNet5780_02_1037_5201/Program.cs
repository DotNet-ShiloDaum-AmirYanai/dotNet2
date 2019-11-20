using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780_02_1037_5201
{
 class Program
    {
        
        static Random rand = new Random(DateTime.Now.Millisecond);

        private static GuestRequest CreateRandomRequest()
        {
            GuestRequest gs = new GuestRequest();

            //Fill randomally the Entry and Release dates of gs

            return gs;
        }

        static void Main(string[] args)
        {
           
        }
    }
}
