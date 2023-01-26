using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using PLEASE_DONT_OPEN_THE_CLOSED_DOOR;

namespace PLEASE_DONT_OPEN_THE_CLOSED_DOOR
{

    public class PaintingDoor
    {

        public void PaintDoor(int x, int y, int z)
        {


            string iString = "I";
            string dash = "-";

            const int DOOR_SIZE_WIDTH = 10;
            const int DOOR_SIZE_HEIGHT = 10;
            const int HANDLE_X = DOOR_SIZE_WIDTH - 2;
            const int HANDLE_Y = DOOR_SIZE_HEIGHT - 2;
            const int FLOOR_LENGTH = 70;

            Console.ForegroundColor = (ConsoleColor)z;

            RenderDoor(x, y, "----------");
            RenderDoor(x + 2, y + 4, "o");  //Handle of the door

            
            RenderDoor(x + 4, y + 9, "O");

            for (int i = y; i < y + DOOR_SIZE_HEIGHT; i++)
            {
                Console.ForegroundColor = (ConsoleColor)z;


                RenderDoor(x + DOOR_SIZE_WIDTH, i, iString);
                RenderDoor(x, i, iString);



            };








            static void RenderDoor(int x, int y, string obj)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(obj);
            }




        }
        public void Renderflooer()
        {
            for (int floorLength = 0; floorLength < 90; ++floorLength)
            {
                Random random = new Random();
                int a = random.Next() % 6;

                if (a == 0)
                {
                    a = 12;
                }

                else if (a == 1) { a = 4; }
                else if (a == 2) { a = 13; }
                else if (a == 3) { a = 12; }
                Console.ForegroundColor = (ConsoleColor)a;
                RenderDoor(floorLength + 5, 15, "-"); //floor

                static void RenderDoor(int x, int y, string obj)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(obj);
                }

            }
        }

        public void RenderflooerToHell()
        {
            for (int floorLength = 0; floorLength < 70; ++floorLength)
            {
                Random random = new Random();
                int a = random.Next() % 6;

                if (a == 0)     
                {
                    a = 12;
                }

                else if (a == 1) { a = 4; }
                else if (a == 2) { a = 13; }
                else if (a == 3) { a = 12; }
                Console.ForegroundColor = (ConsoleColor)a;
                RenderDoor(floorLength + 5, 15, "-"); //floor
                RenderDoor(floorLength + 5, 15, "-"); //floor

             

            }

            for (int floorLength = 15; floorLength < 30; ++floorLength)
            {
                Random random = new Random();
                int a = random.Next() % 6;

                if (a == 0)
                {
                    a = 12;
                }

                else if (a == 1) { a = 4; }
                else if (a == 2) { a = 13; }
                else if (a == 3) { a = 12; }
                Console.ForegroundColor = (ConsoleColor)a;
                RenderDoor(70 , floorLength , "I"); //floor
               


            }

            static void RenderDoor(int x, int y, string obj)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(obj);
            }
        }




    }


}







