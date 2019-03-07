using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Player:Status_Combat
    {
        Random rnd = new Random();

        public string name;
        public int gold;
        public bool life_status;


        public int XP;
        public int XP_MAX;
        Player_Class clasa;
        Race rasa;

        /*LVL UP */
        /*Dead/Alive*/
        /*Take Damage + Log(De la cine ia dmg + statusuri) + la fel pentru enemy*/
        /*Attack*/
        /*Take Challange( Log pentru combat ) / Run( 25% sanse ) */

        /*Check_Status*/
        public Player(string name, int cls, int rsa, int lvl, int gold , bool life_status,int HP ,int MaxHp,
                      int Strength,int Agility,int Resilience)
        {
            clasa = new Player_Class(cls);
            rasa = new Race(rsa);
            this.name = name;
            this.lvl = clasa.lvl;
            this.gold = gold;
            this.life_status = life_status;

            this.HP = clasa.HP;
            this.MaxHP = clasa.MaxHP;
            this.Strength = clasa.Strength;
            this.Agility = clasa.Agility;
            this.Resilience = clasa.Resilience;
        }

        public void Check_Status()
        {
            Console.WriteLine("Class:{0} " +
                              "\nRace:{1}\n" +
                              "\nLvl:{2}" +
                              "\nGold:{3}" +
                              "\nHP:{4}" +
                              "\nAlive:{5}\n" +
                              "\nStrength:{6}" +
                              "\nAblityPower:{7}" +
                              "\nAgility:{8}\n" +
                              "\nResilience:{9}" +
                              "\nSpellResilience:{10}\n",
                              clasa.Name, rasa.RaceName, lvl, gold, clasa.HP, life_status, clasa.Strength,
                              clasa.AbilityPower, clasa.Agility, clasa.Resilience, clasa.SpellResilience);
        }

        

        public bool Check_If_Alive()
        {
            if (clasa.HP == 0)
            {
                life_status = false;
            }
            return life_status;
        }
        public void LevelUp()
        {
            if (XP == XP_MAX)
            {
                lvl = lvl + 1;
                clasa.MaxHP = clasa.MaxHP + 50;
                clasa.HP = clasa.MaxHP;
                switch (clasa.Name)
                {
                    case "Hunter":
                        clasa.Strength = clasa.Strength + 7;
                        clasa.Agility = clasa.Agility + 3;
                        clasa.Resilience = clasa.Resilience + 5;
                        break;

                    case "Mage":
                        clasa.Strength = clasa.Strength + 2;
                        clasa.Agility = clasa.Agility + 3;
                        clasa.Resilience = clasa.Resilience + 3;
                        break;

                    case "Rogue":
                        clasa.Strength = clasa.Strength + 4;
                        clasa.Agility = clasa.Agility + 7;
                        clasa.Resilience = clasa.Resilience + 6;
                        break;

                    case "Paladin":
                        clasa.Strength = clasa.Strength + 5;
                        clasa.Agility = clasa.Agility + 3;
                        clasa.Resilience = clasa.Resilience + 3;
                        break;
                    
                    default:
                        break;
                }
            }
            XP_MAX = XP_MAX + 50;
        }


        public bool TakeFight(string answer)
        {
            Random rnd = new Random();
            int chance_percent = rnd.Next(0, 100);
            

            if (answer == "F")
            {
                return true;
            }
            else if (answer == "R" && chance_percent <= 25)
            {
                return false;
            }
            return true;
        }
    }
}
