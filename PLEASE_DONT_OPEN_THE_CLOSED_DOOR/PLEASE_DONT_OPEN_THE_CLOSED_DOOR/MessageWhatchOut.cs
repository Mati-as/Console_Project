using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLEASE_DONT_OPEN_THE_CLOSED_DOOR
{
    internal class MessageWhatchOut
    {
      
        public void PrintMessageW()
        {
            void RenderMessage(int x, int y)
            {

                const int MESSAGE_X_W = 1;
                const int MESSAGE_Y_W = 19;
                RenderMessage(MESSAGE_X_W, MESSAGE_Y_W);


                Console.ForegroundColor = ConsoleColor.Red;
               

                Console.SetCursorPosition(MESSAGE_X_W, MESSAGE_Y_W);
                Console.Write("Watch Out! ");


            }
        }
    }
        
}
