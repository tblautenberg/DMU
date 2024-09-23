using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextVenture.Interfaces;

namespace TextVenture
{
    internal class Player : ICreature
    {
        private string Name { get; set; }
        private int Level { get; set; }
        private int HP { get; set; }
        private int Mana { get; set; }
        private int HealthPotAmount = 3;
        private int ManaPotAmount = 3;
        private string[] PlayerSkills;

        public Player(string name, int level, int hP, int mana)
        {
            Name = name;
            Level = level;
            HP = hP;
            Mana = mana;
        }


        // Basic player methods

        public void GetPlayerinfo(Player CurrentPlayer)
        {
            Console.WriteLine($"Current name is {CurrentPlayer.Name}");
            Console.WriteLine($"Current player level is {CurrentPlayer.Level}");
            Console.WriteLine($"Current HP is {CurrentPlayer.HP}");
            Console.WriteLine($"Current mana is {CurrentPlayer.Mana}");
            Console.WriteLine($"Current amount of health pots left {CurrentPlayer.HealthPotAmount}");
            Console.WriteLine($"Current amount of mana pots left {CurrentPlayer.ManaPotAmount}");
        }

        public void DrinkHealthPot()
        {
            if (HealthPotAmount > 0)
            {
                int RndNUm = HelperClass.RndNumber(10);
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
                int RndNUm = HelperClass.RndNumber(10);
                Console.WriteLine($"The player drinks a mana potion and restores {RndNUm} Mana back!");
                ManaPotAmount -= 1;
            }
            else
            {
                Console.WriteLine("The player is out of mana pots!");
            }
        }

        public void Death()
        {
            Console.WriteLine("The player falls on hes knees in agony... Taking his last breath... and dies");
        }

        // This marks the start of creating player abilities and combat moves to choose from
        
        public void BasicAttack()
        {
            int RndNum = HelperClass.RndNumber(4);
            Console.WriteLine($"You swing at the foe and it for {RndNum}");
        }

        public void DoubleStrike()
        {
            Console.WriteLine("You lunge forward and strikes the foe with two powerfull attacks!");

            for (int i = 0; i < 2; i++)
            {
                int RndNum = HelperClass.RndNumber(5);
                Console.WriteLine($"The beast takes {RndNum} damage!");
            }
        }

        public void ElementStrike()
        {
            Console.WriteLine("You charge up a powerfull spell that is amplified by one of the elements (earth, fire, air or water");

            int RndNum = HelperClass.RndNumber(4);

            if (RndNum =) 
        }

    }
}
