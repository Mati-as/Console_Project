using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLEASE_DONT_OPEN_THE_CLOSED_DOOR
{
    internal class Messages
    {
        public void PrintMessage()
        {
            const int MESSAGE_X = 1;
            const int MESSAGE_Y = 17;
            RenderMessage(MESSAGE_X, MESSAGE_Y);

            const int RUN_MESSAGE_Y = 17;

            RenderMessage(MESSAGE_X, MESSAGE_Y);

            void RenderMessage(int x, int y)
            {
                Random random = new Random();
                int timePass = 0;
                int timePassed = 0;
                int timeAtPresent = 0;
                timePass = timePassed / 120; //1 second

                int n = random.Next(2);
                if (n == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }

                Console.SetCursorPosition(MESSAGE_X, MESSAGE_Y);
                Console.Write("You've got a key ");

                Console.Write("but you don't think it's over,right?");



                timePass++;


            }

        }

    }
}