using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextVenture
{
    internal class HelperClass
    {
        public static int RndNumber(int X)
        {
            Random rnd = new Random();

            return rnd.Next(X);

        }
    }
}
