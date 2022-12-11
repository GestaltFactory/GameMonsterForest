using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Monster_Forest
{
    class Player
    {
        string name;
        int hp;
        int hp_max;
        int xp;
        int gp;
        int level;
        Weapon currentWeapon;

        public int Hp { get => hp; set => hp = value; }
        public int Hp_max { get => hp_max; set => hp_max = value; }
        public int Xp { get => xp; set => xp = value; }
        public int Gp { get => gp; set => gp = value; }
        public int Level { get => level; set => level = value; }
        internal Weapon CurrentWeapon { get => currentWeapon; set => currentWeapon = value; }
        public string Name { get => name; set => name = value; }

        public Player(string name, int hp)
        {
            Name = name;
            
            Xp = 0;
            Gp = 0;
            Level = 1;

            Hp = hp;
            Hp_max = Hp;

            Weapon eqquippedWeapon = new Weapon("Wood Stick", 5, 15);
            CurrentWeapon = eqquippedWeapon;
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

        public void Heal()
        {
            Hp = Hp_max;
        }

        public void TakeDamage(int damage)
        {
            Hp = Hp - damage;
        }

        private void NextLevel()
        {
            int requiredXP = (int)Math.Floor(10 * Math.Pow(Level, 1.5));
            if (Xp >= requiredXP)
            {
                LevelUpgrade();
            }           
        }

        private void LevelUpgrade()
        {
            Level++;
            Hp_max += RNG.random.Next((2 + Level), (6 + Level));
            UpgradeWeapon();
        }

        public void UpgradeWeapon()
        {
            switch (Level)
            {
                case 0: 
                case 1:
                    CurrentWeapon = new Weapon("Wood Stick", 15, 20);
                    break;
                case 2:
                    CurrentWeapon = new Weapon("Big Rock", 20, 30);
                    break;
                case 3:
                    CurrentWeapon = new Weapon("Torch", 30, 40);
                    break;
                default:
                    CurrentWeapon = new Weapon("Magic Sword", 40, 50);
                    break;
            }
        }

        private void UpgradeByGP()
        {
            if (Gp >= 500)
            {
                Gp -= 500;
                LevelUpgrade();
            }
        }

        public void Attack(Monster enemy, int round)
        {
            int random = RNG.random.Next(CurrentWeapon.Damage);
            enemy.TakeDamage(random);
            Message.Success("\n You hit the enemy by: " + random);
            if (enemy.IsDead())
            {
                Xp += enemy.Rxp;
                NextLevel();
            }
            else
            {
                if (round >= 5)
                {
                    Message.Warning("\n" + Name + " ran away!");
                }
            }
        }

        public void Explore()
        {
            int random = RNG.random.Next(0, 100);
            Message.Success("\nYou are exploring the forest...");
            if (random < 35) // 35% change to meet a monster
            {
                Monster monster = Monster.CreateMonster(Level);
                Message.Danger("\nMonster " + monster.Name + " is approaching. Prepare for battle!");
                Battle(monster);
            }
            else if (random >= 35 && random < 70) // 35% change to find gold
            {
                int randomGP = RNG.random.Next(50, 500);
                Message.Warning("\nYou collected " + randomGP + " Gold Pieces!");
                Gp += randomGP;
            }
            else if (random >= 70 && random < 95) // 25% change to upgrade your level using gold pieces
            {
                Message.Warning("\nYou try to exchange 500 Gold Pieces for 1 level!");
                UpgradeByGP();
            }
            else // 5% change to keep exploring
            {
                Message.Success("\nYou are exploring the forest...");
            }
        }

        public void Battle(Monster monster)
        {
            int round = 0;

            while (round < 6)
            {
                monster.Attack(this);
                Attack(monster, round);
                round++;
            }           
        }

        public override string ToString()
        {
            if (Hp < 0)
            {
                Hp = 0;
            }
            
            string stats = "Name: " + Name + " | HP = " + Hp + " | XP = " + Xp + " | GP = " + Gp + " | Level = " + Level;
            stats += " | Weapon: " + CurrentWeapon.Name + "\n";
            
            return stats;
        }
    }
}
