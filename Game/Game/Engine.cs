using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Engine
    {
        public Enemy mob;
        public Player player;
        public Map map;

        public void GameEngine()
        {
            bool first_turn = true;
            bool game_status = true;
            while (game_status == true)
            {

                if (first_turn)
                {
                    Console.WriteLine("What's your name adeventurer?");
                    string name = Console.ReadLine();

                    Console.WriteLine("Pick a class (1.Hunter || 2.Mage || 3.Rogue || 4.Paladin) :");
                    int clasa = int.Parse(Console.ReadLine());

                    Console.WriteLine("Pick a race (1.Human || 2.Orc || 3.Elf || 4.Troll) :");
                    int rasa = int.Parse(Console.ReadLine());

                    player = new Player(name, clasa, rasa, 1, 100, true, 1, 1, 1, 1, 1);
                    map = new Map();


                }
                Console.Clear();

                    Console.WriteLine("==============MMO Game==============\n");
                    Console.WriteLine("Welcome {0},\n", player.name);
                    player.Check_Status();

                    Console.WriteLine("Press Enter to start");

                    Console.ReadKey();

                    Console.Clear();
                    first_turn = false;
                
                
                map.Navigate();
                FindEnemy();

                string answer;
                Console.WriteLine("Do you want to fight this enemy or do you want to run(25% chance) (F/R):");
                answer = Console.ReadLine();

                if (player.TakeFight(answer))
                {
                    Console.Clear();
                    Console.WriteLine("You choosed to fight the {0} or you failed to run!Congratulations!\nPrepare...\n",mob.Name);
                    Fight();
                    if (player.life_status == false)
                    {
                        game_status = false;
                    }
                }
                else
                {
                    Console.WriteLine("You ran successfully from {0}.\n" +
                        "You can start again to find an enemy whenever you want.\nPres any key\n",mob.Name);
                    Console.ReadLine();
                }

                
            }

        }
        /*
         * Input player daca ataca
         *  {    
         *    in functie de resilienta ,intre 1 si 4 ,25% sa treaca de rezilienta ( mob take dmg in functie de str)
         *    in functie de lvl sa nu poata sa ia dmg(5 lvl mai mare)
         *    daca boss > 5 lvl ,one shot
         *  }
         * */

        public void Check_Enemy_Status()
        {
            Console.WriteLine("HP:{0}\n" +
                              "\nStrength:{1}\n" +
                              "AbilityPower:{2}\n" +
                              "Agility:{3}\n" +
                              "Resilience:{4}\n"
                              , mob.HP, mob.Strength, mob.AbilityPower, mob.Agility
                              , mob.Resilience);
        }

        public void FindEnemy()
        {
            Random rnd = new Random();
            mob = new Enemy(rnd.Next(1, 4));
            mob.lvl = mob.lvl + player.lvl;
            Console.WriteLine("\nCongratulations adventurer,you found an {0}!\n", mob.Name);
            Check_Enemy_Status();

        }
        
        public void Player_Attack()
        {
            int damage;
            if (mob.Resilience > player.Resilience && player.HP > 0 && mob.HP > 0)
            {
                damage = player.Strength - mob.Resilience;
                mob.HP = mob.HP - damage;
                Console.WriteLine("You hit the {0} with {1} damage ,Remaining HP:{2}", mob.Name, damage, mob.HP);
            }
            else if (mob.Resilience < player.Resilience && player.HP > 0 && mob.HP > 0)
            {
                damage = player.Strength + 2;
                mob.HP = mob.HP - damage;
                Console.WriteLine("You hit the {0} with {1} damage ,Remaining HP:{2}", mob.Name, damage, mob.HP);
            }
        }

        public void Mob_Attack()
        {
            int damage;
            if (player.Resilience > mob.Resilience && player.HP > 0 && mob.HP > 0)
            {
                damage = mob.Strength - player.Resilience;
                player.HP = player.HP - damage;
                Console.WriteLine("The {0} hit you with {1} damage,Remaining HP:{2}",mob.Name,damage,player.HP);
            }
            else if (player.Resilience < mob.Resilience && player.HP > 0 && mob.HP > 0)
            {
                damage = mob.Strength + 3;
                player.HP = player.HP - damage;
                Console.WriteLine("The {0} hit you with {1} damage ,Remaining HP:{2}", mob.Name, damage, player.HP);
            }
        }

        public void Fight()
        {
            bool fight_status = true;
            Console.WriteLine("The fight with {0} starts...", mob.Name);
            while (fight_status)
            {
                Console.WriteLine("Press A to attack");
                Console.ReadLine();
                Console.WriteLine("\n");
                if (mob.lvl >= player.lvl + 5 || mob.lvl >= player.lvl + 4)
                {
                    Console.WriteLine("You failed to attack {0},his level is too high and the monster kills you...");
                    player.life_status = false;
                    fight_status = false;
                }

                Player_Attack();
                Mob_Attack();

                if (player.HP <= 0)
                {
                    fight_status = false;
                    player.life_status = false;
                    Console.WriteLine("\nYou have been defeated by {0}...Game Over\n",mob.Name);
                }
                else if (mob.HP <= 0)
                {
                    fight_status = false;
                    player.XP = player.XP + 10 * mob.lvl;
                    Console.WriteLine("You defeated {0}.You XP is now:{1}...Press Enter to contiune\n",mob.Name,player.XP);
                    Console.ReadLine();
                    Console.Clear();
                }
            }
           // player.life_status = true;//testing
        }
    }
}
