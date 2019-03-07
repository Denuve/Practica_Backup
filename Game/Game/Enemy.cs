using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Enemy:Status_Combat
    {
        public string Name;
        public Enemy(int random_enemy)
        {
            switch (random_enemy)
            {
                case 1:
                    Name = "Ogre (Easy)";

                    lvl = 1;

                    HP = 50;
                    MaxHP = 50;

                    Strength = 5;
                    Agility = 4;

                    Resilience = 6;
                    
                    break;

                case 2:
                    Name = "Shapeshifter Vampire (Easy-Medium)";

                    lvl = 2;

                    HP = 100;
                    MaxHP = 100;

                    Strength = 9;
                    Agility = 9;

                    Resilience = 25;
                    
                    break;

                case 3:
                    Name = "Goblin(Medium)";

                    lvl = 3;

                    HP = 150;
                    MaxHP = 150;

                    Strength = 12;
                    Agility = 16;

                    Resilience = 30;
                    
                    break;

                case 4:
                    Name = "Gnome (Hard)";

                    lvl = 4;

                    HP = 170;
                    MaxHP = 170;

                    Strength = 34;
                    Agility = 25;

                    Resilience = 32;
                    break;
                case 5:
                    Name = "DEMON (!! BOSS !!)";

                    lvl = 5;

                    HP = 200;
                    MaxHP = 100;

                    Strength = 40;
                    Agility = 45;
                    Resilience = 38;

                    SpellResilience = 38;
                    break;
                default:
                    break;
            }
        }
        
    }
}
