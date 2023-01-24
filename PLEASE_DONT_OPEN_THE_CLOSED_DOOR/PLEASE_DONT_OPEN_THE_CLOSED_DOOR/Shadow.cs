using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLEASE_DONT_OPEN_THE_CLOSED_DOOR
{
    internal class Murder
    {
        public void CreatGhost(int x, int y, int z)
        {
            Random random = new Random();
            int MURDER_X = 0;
            int MURDER_Y = random.Next(2, 5);

            string a = string.Empty;

            for (int s = 0; s < z; s++)
            {
                a += " ";
            }

            RenderMurder(x, y, z);


            Thread.Sleep(5);

            Console.Clear();

            void RenderMurder(int x, int y, int z)
            {


                int n = random.Next(3);
                if (n == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
                Console.SetCursorPosition(0,0);



      


                Console.Write(a); Console.WriteLine("       ~    ~.......");
                Console.Write(a); Console.WriteLine("           .........");
                Console.Write(a); Console.WriteLine("       ~    ~.......");
                Console.Write(a); Console.WriteLine("      !      *......");
                Console.Write(a); Console.WriteLine("     ,        -.....");
                Console.Write(a); Console.WriteLine("     ~        :.....");
                Console.Write(a); Console.WriteLine("     : *:  :* ~     ");
                Console.Write(a); Console.WriteLine("...... ~=,,=~       ");
                Console.Write(a); Console.WriteLine("......:  ..  :      ");
                Console.Write(a); Console.WriteLine(".......:!;;!:       ");
                Console.Write(a); Console.WriteLine(".......-,-,.,       ");
                Console.Write(a); Console.WriteLine("          ..        ");

                a = string.Empty;
            }




        }

    }
}

