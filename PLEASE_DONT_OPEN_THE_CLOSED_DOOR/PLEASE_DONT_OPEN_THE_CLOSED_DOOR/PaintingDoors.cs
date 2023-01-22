//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using PLEASE_DONT_OPEN_THE_CLOSED_DOOR;

//namespace PLEASE_DONT_OPEN_THE_CLOSED_DOOR
//{

//    public class PaintingDoor
//    {

//        Rendering PaintWall = new Rendering()
//        {
//        };


//        int START_OF_DOOR_X = 25;
//        int START_OF_DOOR_Y = 3;
//        int END_OF_DOOR_X = 35;
//        int END_OF_DOOR_Y = 12;
//        int SIZE_OF_DOOR = 10;
//        int DOOR_HANDLE_X = START_OF_DOOR_X + 2;
//        int DOOR_HANDLE_Y = START_OF_DOOR_Y + 5;

//        RenderObject(START_OF_DOOR_X, START_OF_DOOR_Y, "----------");

//                for(int i = START_OF_DOOR_Y; i<END_OF_DOOR_Y; i++)
//            {
//                    RenderObject(START_OF_DOOR_X, i, "I");
//        RenderObject(START_OF_DOOR_X + SIZE_OF_DOOR, i, "I");
//        RenderObject(DOOR_HANDLE_X, DOOR_HANDLE_Y, "o");

//        RenderObject(START_OF_DOOR_X - 10, END_OF_DOOR_Y, "-------------------------------");

//        Console.ForegroundColor = ConsoleColor.White;
//                Thread.Sleep(200);
//                RenderObject(15, 15, "Hey, do you want to open this door?");

//        Thread.Sleep(2100);

//                RenderObject(15, 16, "If so, say whatever if you want to.");
//        Thread.Sleep(2500);

//                Console.ForegroundColor = ConsoleColor.DarkGray;
//                RenderObject(15, 18, "(Press Any Key You Want.)");

//         void RenderObject(int x, int y, string obj)
//    {
//        Console.SetCursorPosition(x, y);
//        Console.Write(obj);
//    }

//    }





//}
    

//}







