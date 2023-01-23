using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using PLEASE_DONT_OPEN_THE_CLOSED_DOOR;

namespace PLEASE_DONT_OPEN_THE_CLOSED_DOOR
{
    public  class TimeTicking
    {
        string iString = "I";
        string dash = "-";

        int CLOCK_START_X= 9;
        int CLOCK_START_Y = 1;

        int second = 0;
        enum ColorList
        {
            red = 0,
            darkred = 1,
            magenta = 2
        };

        public void RenderClock()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;

           
            Random random = new Random();
            int a = random.Next() % 6;
            
            if ( a == 0)
            {
                a = 12;
            }

            else if (a == 1) { a = 4; }
            else if (a == 2) { a = 13; }
            else { a = 12; }
            Console.ForegroundColor = (ConsoleColor)a;
            
              //Handle of the door
              //floor
             
             RenderClock(CLOCK_START_X + 1, CLOCK_START_Y ,second/120);

            second++;

            if(second/120 == 5)
            {
                RenderMessage(CLOCK_START_X + 5, CLOCK_START_Y, "Hey, You're running out of time.");
            }
            else if (second/120 == 8)
            {
                RenderMessage(CLOCK_START_X + 5, CLOCK_START_Y, "And see what is coming behind you.");
            }

           void RenderClock(int x, int y, int obj)
           {
            Console.SetCursorPosition(x, y);
            Console.Write(obj);
           }

            void RenderMessage(int x, int y, string obj)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(obj);
            }

        }

       
    }
}
