using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /*Coordonate X ;Y */
    class Map
    {
        public int x, y;
        Random rnd = new Random();
        public Map()
        {
            x = 0;
            y = 0;
        }
        public void Navigate()
        {
            string Coord;
            Console.WriteLine("Please choose where you want to go(N,S,E,V):");

                Coord = Console.ReadLine();    
                switch (Coord.ToUpper())
                {
                    case "N":
                        x = 0;
                        y = y + 1;
                        Console.WriteLine("You choosed Nort!");
                        break;

                    case "S":
                        x = 0;
                        y = y - 1;
                        Console.WriteLine("You choosed South!");
                        break;

                    case "E":
                        x = x + 1;
                        y = 0;
                        Console.WriteLine("You choosed Est!");
                        break;

                    case "V":
                        x = x - 1;
                        y = 0;
                        Console.WriteLine("You choosed Vest!");
                        break;

                    default:
                        x = 0;
                        y = y - 1;
                        Console.WriteLine("You choosed South!");
                        break;
                }
        }
    }
}
