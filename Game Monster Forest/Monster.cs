using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Monster_Forest
{
    class Monster
    {
        string name;
        int hp;
        int ap;
        int rxp;

        public string Name { get => name; set => name = value; }
        public int Hp { get => hp; set => hp = value; }
        public int Ap { get => ap; set => ap = value; }
        public int Rxp { get => rxp; set => rxp = value; }

        public Monster(string name, int hp, int ap, int rxp)
        {
            Name = name;
            Hp = hp;
            Ap = ap;
            Rxp = rxp;
        }

        public bool IsDead()
        {
            if (Hp <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void TakeDamage(int damage)
        {
            Hp = Hp - damage; 
        }

        public void Attack(Player target)
        {
            int random = RNG.random.Next(0, Ap);
            target.TakeDamage(random);
            Message.Danger("\n You got hit by: " + random);
        }

        public static Monster CreateRandomMonster(int goblinChance, int ogreChance, int dragonChance)
        {
            int Max = goblinChance + ogreChance + dragonChance;
            int random = RNG.random.Next(0, Max);

            if (random <= goblinChance) // chance to get a goblin
            {
                return new Monster("Goblin", 40, 10, 1);
            }
            else if (random <= (goblinChance + ogreChance))  // chance to get a ogre
            {
                return new Monster("Ogre", 80, 20, 2);
            }
            else  // chance to get a dragon
            {
                return new Monster("Dragon", 100, 40, 3);
            }
        }

        public static Monster CreateMonster(int level)
        {
            switch (level)
            {
                case 1:
                    return CreateRandomMonster(80, 20, 0);
                case 2:
                    return CreateRandomMonster(50, 50, 0);
                case 3:
                    return CreateRandomMonster(40, 40, 20);
                default:
                    return CreateRandomMonster(30, 30, 40);
            }
        }
    }
}
