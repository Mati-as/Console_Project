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

        public double timePass = 0;
        public int timePassed = 0;
        public int timePassedDivided5 = 0;
        public bool runTrigger = false;
        public int murderSpeed = 0;
        public int timebooster = 0;

        public int murderAtPresent = 70;

        Random random = new Random();
        public int randomMoveMin = 30;
        public int randomMoveMax = 45;
        public int randomMoveMin2 = 10;
        public int randomMoveMax2 = 15;

        enum ColorList
        {
            red = 0,
            darkred = 1,
            magenta = 2
        };
        internal static Murder ghost = new Murder();
        internal static MessageWhatchOut messageW = new MessageWhatchOut();
        public RenderMurder murder = new RenderMurder();
        public void RenderClock()
        {
           
            
              //Handle of the door
              //floor
             
             RenderClock(CLOCK_START_X - 2, CLOCK_START_Y , 60 - (int)timePass);
            timePassed++;

            timePass = timePassed / 90; //1 second
            timePassedDivided5 = timePassed / 5;

            //MoveMurder--------------------------------------



            


            int k = random.Next(200,202);


            murderSpeed = timePassed / 160;
            timebooster = timePassed / 150;

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
                RenderMessage(CLOCK_START_X + 5, CLOCK_START_Y - 1, "Hey.... You're running out of time.");
                RenderMessage(CLOCK_START_X + 5, CLOCK_START_Y, "              ");


            }


            else if (timePassed % 100 > 20 && timePassed % 100 <= 30)
            {

                RenderMessage(CLOCK_START_X + 5, CLOCK_START_Y - 1, "And see what is coming behind you.");
                RenderMessage(CLOCK_START_X + 5, CLOCK_START_Y, "              ");

            }

            else if (timePassed % 100 > randomMoveMin && timePassed % 100 <= randomMoveMax)
            {
               
                RenderMessage(CLOCK_START_X + 5, CLOCK_START_Y, "                                     ");
                RenderMessage(CLOCK_START_X + 5, CLOCK_START_Y, "Watch Out!");
                murder.MoveMurder();
                murderAtPresent = murder.murder_X;
            }

            else if (timePassed % 100 > 90 && timePassed % 100 <= 100)
            {

                RenderMessage(CLOCK_START_X + 5, CLOCK_START_Y, "                                     ");
                RenderMessage(CLOCK_START_X + 5, CLOCK_START_Y, "Watch Out!");
                murder.MoveBackMurder();
                murderAtPresent = murder.murder_X;
            }




            if ( timePassed%1000 >= 480 && timePassed%1000 <= 490)
            {
                int r = random.Next(20 ,70 );
               
                ghost.CreatGhost(0,19,r);
                Console.Clear();
               
            }





            else if (timePassed / 120 == 10)
            {
                RenderMessage(CLOCK_START_X + 5, CLOCK_START_Y, "                                       ");
            }

            
             murder.crawlMurder();

            murder.crawlBackMurder();


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

        public void RenderRunMessage(int x)
        {

            Random random = new Random();
            int n = random.Next(2);
            if (n == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }


            Console.SetCursorPosition(x-1, 12);
            Console.Write("RUN!!!");
           
        }
    }
}
