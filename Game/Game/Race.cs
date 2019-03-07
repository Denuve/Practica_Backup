using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Race:Status_Combat
    {
        /*
         * Human:+strength
         * Orc:+agility
         * Elf:+AbilityPower
         * Troll:+AbilityPower/Strength
         * */

        public string RaceName;
        public Race(int race)
        {
            switch (race)
            {
                case 1:
                    RaceName = "Human";
                    Strength = Strength + 5;
                    break;

                case 2:
                    RaceName = "Orc";
                    Agility = Agility + 6;
                    break;

                case 3:
                    RaceName = "Elf";
                    AbilityPower = AbilityPower + 6;
                    break;

                case 4:
                    RaceName = "Troll";
                    AbilityPower = AbilityPower + 4;
                    Strength = Strength + 4;
                    break;
                
                default:
                    break;
            }
        }
    }
}
