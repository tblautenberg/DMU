using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextVenture.Interfaces;

namespace TextVenture
{
    internal class BFrog:ICreature
    {
        public void Death()
        {
            Console.WriteLine("The frog dies and the hero wins another battle!");
        }
    }
}
