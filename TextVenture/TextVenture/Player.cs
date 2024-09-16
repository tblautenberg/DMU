using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextVenture
{
    internal class Player
    {
        private string Name;
        private int Level;
        private int HP;
        private int Mana;
        private int HealthPotAmount = 3;
        private int ManaPotAmount = 3;

        public Player(string name, int level, int hP, int mana)
        {
            Name = name;
            Level = level;
            HP = hP;
            Mana = mana;
        }

        public void DrinkHealthPot()
        {
            if (HealthPotAmount > 0)
            {
                int RndNUm = HelperClass.RndNumber();
                Console.WriteLine($"The player drinks a health potion and restores {RndNUm} health back!");
                HealthPotAmount -= 1;
            }
            else
            {
                Console.WriteLine("The player is out of health pots!");
            }
        }

        public void DrinkManaPot()
        {
            if (HealthPotAmount > 0)
            {
                int RndNUm = HelperClass.RndNumber();
                Console.WriteLine($"The player drinks a mana potion and restores {RndNUm} Mana back!");
                ManaPotAmount -= 1;
            }
            else
            {
                Console.WriteLine("The player is out of mana pots!");
            }
        }
    }
}
