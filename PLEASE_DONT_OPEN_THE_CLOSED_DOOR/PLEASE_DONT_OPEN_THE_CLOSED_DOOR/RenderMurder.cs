using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PLEASE_DONT_OPEN_THE_CLOSED_DOOR
{
   public class RenderMurder
    {
        Random random = new Random();
        const int MURDER_START_POINT = 70;
        const int MURDER_START_POINT_BACK = 3;

        public int murder_X = MURDER_START_POINT;
        public int backMurder_X = MURDER_START_POINT_BACK;
        int murder_Prex = MURDER_START_POINT;
        int backMurder_PreX = MURDER_START_POINT_BACK;
        int murder_Y = 15;

        
        string a = string.Empty;
        
        
      


        public void crawlMurder()
        {
           

            int a = random.Next() % 6;
                

                if (a == 0)      { a = 12;}
                else if (a == 1) { a = 8; }
                else if (a == 2) { a = 12;}
                else { a = 8; }

                Console.ForegroundColor = (ConsoleColor)a;


                RenderMurder(murder_X , murder_Y-3  ,  "Q");
                RenderMurder(murder_X , murder_Y-2  , "|#|");
                RenderMurder(murder_X , murder_Y-1  , "|#|");
                RenderMurder(murder_X , murder_Y-0  , " m");


               RenderMurder(murder_X + 1, murder_Y - 3, "  ");
               RenderMurder(murder_X + 3, murder_Y - 2, "  ");
               RenderMurder(murder_X + 3, murder_Y - 1, "  ");
               RenderMurder(murder_X + 3, murder_Y - 0, "  ");

            //플레이어와 닿으면 게임종료





          






            static void RenderMurder(int a, int b, string obj)
                {
                    Console.SetCursorPosition(a, b);
                    Console.Write(obj);
                }


            


        }


        public void crawlBackMurder()
        {


            int a = random.Next() % 6;


            if (a == 0) { a = 12; }
            else if (a == 1) { a = 8; }
            else if (a == 2) { a = 12; }
            else { a = 8; }

            Console.ForegroundColor = (ConsoleColor)a;


            //RenderMurder(backMurder_X, murder_Y - 3, "");
            //RenderMurder(backMurder_X, murder_Y - 2, "");
            //RenderMurder(backMurder_X, murder_Y - 1, "");
            //RenderMurder(backMurder_X, murder_Y - 0, "");
                        
            //RenderMurder(backMurder_X - 1, murder_Y - 3, "  ");
            //RenderMurder(backMurder_X - 3, murder_Y - 2, "  ");
            //RenderMurder(backMurder_X - 3, murder_Y - 1, "  ");
            //RenderMurder(backMurder_X - 3, murder_Y - 0, "  ");

            //플레이어와 닿으면 게임종료












            static void RenderMurder(int a, int b, string obj)
            {
                Console.SetCursorPosition(a, b);
                Console.Write(obj);
            }





        }
        public void InitailzieMurder(int _murder_X)
        {
            murder_X = _murder_X;

            return;
        }

        public void MoveMurder()
        {
            if( murder_Prex >= murder_X || murder_X >= 1)
            {
                

                murder_X = murder_X - 1; //69

                murder_Prex = murder_X + 1;
            }

          
         
        }

        public void MoveBackMurder()
        {
            if (murder_Prex >= murder_X || murder_X >= 70)
            {
                backMurder_PreX = backMurder_X; //70

                backMurder_X = backMurder_X + 1; //69

            }



        }


    }
}


