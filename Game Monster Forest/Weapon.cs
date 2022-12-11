using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Monster_Forest
{
    class Weapon
    {
        string name;
        int minDamage;
        int maxDamage;

        public int Damage { get => RNG.random.Next(minDamage, maxDamage); }
        public string Name { get => name; set => name = value; }

        public Weapon(string name, int minDamage, int maxDamage)
        {
            Name = name;
            this.minDamage = minDamage;
            this.maxDamage = maxDamage;
        }
    }
}
