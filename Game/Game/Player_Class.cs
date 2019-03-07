using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Player_Class:Status_Combat
    {
        public string Name;
        public Player_Class(int id)
        {
            switch (id)
            {
                case 1:
                    Name = "Hunter";

                    HP = 100;
                    MaxHP = 100;

                    lvl = 1;

                    Strength = 25;
                    Agility = 12;

                    Resilience = 20;
                    SpellResilience = 12;
                    break;

                case 2:
                    Name = "Mage";

                    HP = 100;
                    MaxHP = 100;

                    lvl = 1;

                    Strength = 15;
                    Agility = 7;

                    Resilience = 14;
                    break;

                case 3:
                    Name = "Rogue";

                    HP = 100;
                    MaxHP = 100;

                    lvl = 1;

                    Strength = 10;
                    Agility = 29;

                    Resilience = 12;
                    break;

                case 4:
                    Name = "Paladin";

                    HP = 100;
                    MaxHP = 100;

                    lvl = 1;

                    Strength = 14;
                    Agility = 9;
                    Resilience = 12;
                    break;

                default:
                    break;
            }
        }
    }
}
