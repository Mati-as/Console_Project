using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLEASE_DONT_OPEN_THE_CLOSED_DOOR
{
    internal class RenderMurder
    {
        Random random = new Random();
        int murder_X = 70;
        int murder_Y = 15;

        string a = string.Empty;



        public void crawlMurder(int a , int b)
        {
            RenderMurder(a, b);

            void RenderMurder(int x, int y)
            {


              


                int a = random.Next() % 6;


                if (a == 0)      { a = 12;}
                else if (a == 1) { a = 8; }
                else if (a == 2) { a = 12;}
                else { a = 8; }
                Console.ForegroundColor = (ConsoleColor)a;


                if (x % 2 == 0 )
                    {
                     RenderMurder(murder_X-x, murder_Y-3, "Q");
                     RenderMurder(murder_X-x, murder_Y-2,"|#|");
                     RenderMurder(murder_X-x, murder_Y-1,"|#|");
                     RenderMurder(murder_X-x, murder_Y-0," m");

                    RenderMurder(murder_X - x + 1, murder_Y - 3, "  ");
                    RenderMurder(murder_X - x + 1, murder_Y - 2, "  ");
                    RenderMurder(murder_X - x + 1 , murder_Y - 1, "  ");
                    RenderMurder(murder_X - x + 1, murder_Y - 0, "  ");

                }



                   else
                   {
                 
                    RenderMurder(murder_X- x - 1, murder_Y - 3, "Q");
                    RenderMurder(murder_X- x - 2, murder_Y - 2, "|#|");
                    RenderMurder(murder_X- x, murder_Y - 1, "|#|");
                    RenderMurder(murder_X- x, murder_Y - 0, " m");

                    RenderMurder(murder_X - x + 1, murder_Y - 3, "  ");
                    RenderMurder(murder_X - x + 1, murder_Y - 2, "  ");
                    RenderMurder(murder_X - x + 1, murder_Y - 1, "  ");
                    RenderMurder(murder_X - x + 1, murder_Y - 0, "  ");
                }
                
                static void RenderMurder(int x, int y, string obj)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(obj);
                }


                
            }
        } 
        

     

     
    }
}


