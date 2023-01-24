using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


using PLEASE_DONT_OPEN_THE_CLOSED_DOOR;

namespace PLEASE_DONT_OPEN_THE_CLOSED_DOOR
{


    

    public class TimeTicking
    {
        string iString = "I";
        string dash = "-";

        int CLOCK_START_X= 9;
        int CLOCK_START_Y = 1;

        public int timePass = 0;
        public int timePassed = 0;
        public int timePassedDivided5 = 0;

        enum ColorList
        {
            red = 0,
            darkred = 1,
            magenta = 2
        };
        internal static Murder ghost = new Murder();
        internal static MessageWhatchOut messageW = new MessageWhatchOut();
        internal static RenderMurder murder = new RenderMurder();
        public void RenderClock()
        {
           
            
              //Handle of the door
              //floor
             
             RenderClock(CLOCK_START_X - 2, CLOCK_START_Y , 60 - timePass);

            timePass = timePassed / 90; //1 second
            timePassedDivided5 = timePassed / 5;
            timePassed++;

            Random random = new Random();
            int k = random.Next(200,202);



            
            int a = random.Next() % 6;

            if (a == 0)
            {
                a = 12;
            }

            else if (a == 1) { a = 4; }
            else if (a == 2) { a = 13; }
            else { a = 12; }
            Console.ForegroundColor = (ConsoleColor)a;


            if (timePass % 10 > 1 && timePass % 10 <= 2)
            {
                RenderMessage(CLOCK_START_X + 5, CLOCK_START_Y, "Hey.... You're running out of time.");
               


            }


            else if (timePass % 10 > 3 && timePass % 10 <= 4)
            {
               
                RenderMessage(CLOCK_START_X + 5, CLOCK_START_Y, "And see what is coming behind you.");
               
            }


            if (timePass % 10 > 4 && timePass % 10 <= 5)
            {


                RenderMessage(CLOCK_START_X + 5, CLOCK_START_Y , "Watch Out!");
                Console.Clear();

            }


            if ( timePassed%1000 >= 480 && timePassed%1000 <= 490)
            {
                int r = random.Next(20 ,70 );
               
                ghost.CreatGhost(0,20,r);
                Console.Clear();
                
            }
               
           
            else if (timePassed / 120 == 10)
            {
                RenderMessage(CLOCK_START_X + 5, CLOCK_START_Y, "                                       ");
            }


            murder.crawlMurder(timePass,15);
    
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
