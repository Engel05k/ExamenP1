using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Power
    {
        public string Name { get; private set; }
        public int ManaCost { get; private set; }
        public int Damage { get; private set; }

        public Power(string name, int manaCost, int damage)
        {
            Name = name;
            ManaCost = manaCost;
            Damage = damage;
        }
    }
}
