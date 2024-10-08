﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TextVenture.Interfaces;

namespace TextVenture
{
    internal class BDragon:ICreature
    {
        private string Name;
        private int HP = 0;
        private int Mana = 0;

        public BDragon(string name, int hP, int mana)
        {
            Name = name;
            HP = hP;
            Mana = mana;
        }

        public List<String> DragonAbilities = new List<String>();

        public void DragonClaw()
        {
            int RndNum = HelperClass.RndNumber(10);
            Console.WriteLine($"The dragon uses a firce attack and deals {RndNum} damge to its foe!");
            DragonAbilities.Add("DragonClaw");
        }

        public void FlameBreath()
        {
            Console.WriteLine($"The dragon unleash a firey breath on everything in front of him! It deals {HelperClass.RndNumber(15)} damage!");
            DragonAbilities.Add("FlameBreath");
        }

        public void Death()
        {
            Console.WriteLine("The dragon trembels down and and takes it's last dieing breath... You won the batle!");
        }

    }
}
