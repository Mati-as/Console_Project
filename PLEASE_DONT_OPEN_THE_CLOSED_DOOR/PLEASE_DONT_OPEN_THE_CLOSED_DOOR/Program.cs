using System;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Media;
using System.Windows.Input;


namespace PLEASE_DONT_OPEN_THE_CLOSED_DOOR
{//namespace 선언해야 다른 네임스페이스에서도 불러올 수 있다
 //안그러면 namespaceaname.something 같이 불러와야한다.
    enum Direction // 방향을 저장하는 타입
    {
        None,
        Left,
        Right
       
    }




    class Sokoban
    {
        //생성자 목록 

        //player constructor
        internal static Player player = new Player();
        internal static Messages message = new Messages();
        //clock constructor
        internal static TimeTicking timeClock = new TimeTicking();

        //Doors
        internal static PaintingDoor firstDoor = new PaintingDoor();
        internal static PaintingDoor secondDoor = new PaintingDoor();
        internal static PaintingDoor thirdDoor = new PaintingDoor();
        internal static Murder ghost = new Murder();



        public static int keyCount = 0;


        public static void Main()
        {

            PlayMusic playerMusic = new PlayMusic();
            // 초기 세팅
            Console.ResetColor(); // 컬러를 초기화 하는 것
            Console.CursorVisible = false; // 커서를 숨기기
            Console.Title = "PLEASE_DONT_OPEN_THE_CLOSED_DOOR"; // 타이틀을 설정한다.
            Console.BackgroundColor = ConsoleColor.Black; // 배경색을 설정한다.
            Console.ForegroundColor = ConsoleColor.Yellow; // 글꼴색을 설정한다.
            Console.Clear(); // 출력된 내용을 지운다.


            //걸린시간 (time
            //Door Dimension


            //First door's start point: the start point is upper-left corner.
            //Second door's start point: the start point is upper-left corner.
            //Third door's start point: the start point is upper-left corner.
            //Fourth door's start point: the start point is upper-left corner.
            //Fifth door's start point: the start point is upper-left corner.

            //
            // 기호 상수 정의
            const int GOAL_COUNT = 4;
            const int BOX_COUNT = GOAL_COUNT;
            const int WALL_COUNT = 4;
            const int DOOR_COUNT = 3;


            const int MIN_X = 5;
            const int MAX_X = 70;
            const int MIN_Y = 10;
            const int MAX_Y = 25;

            const int FIRST_PLAYER_INSTRUCTION_X = 10;
            const int FIRST_PLAYER_INSTRUCTION_Y = 5;


            const int PLAYER_START_POINT_X = 6;
            const int PLAYER_START_POINT_Y = 15;
            Random random = new Random();

            //문짝의 위치를 랜덤함수로 배치되게 하였다. 
            int FIRST_DOOR_LOCATION = random.Next(5, 6);
            int SECOND_DOOR_LOCATION = random.Next(20, 24);
            int THIRD_DOOR_LOCATION = random.Next(32, 50);

            bool playStart = false;
            player.X = PLAYER_START_POINT_X;
            player.Y = PLAYER_START_POINT_Y;
            player.PreX = PLAYER_START_POINT_X;
            player.PreY = PLAYER_START_POINT_Y;
            player.MoveDirection = Direction.None;
            player.PushedBoxIndex = 0;




            DoorPoint[] doorPoint = new DoorPoint[]
          {
                new DoorPoint { X = FIRST_DOOR_LOCATION + 4,  Y = PLAYER_START_POINT_Y    , playerIsOnGoal = false},
                new DoorPoint { X = SECOND_DOOR_LOCATION + 4, Y =PLAYER_START_POINT_Y     , playerIsOnGoal = false },
                new DoorPoint { X = THIRD_DOOR_LOCATION + 4,  Y = PLAYER_START_POINT_Y    , playerIsOnGoal = false },

          };


            // 시간을 체크하기 위한 함수
            int timePass = 0;

            int randomBoxNumX = 0;
            int randomBoxNumY = 0;



            Box[] boxForFirst = new Box[BOX_COUNT] {
                  new Box { X = random.Next(MIN_X + 2, MAX_X - 2)/2*2 , Y = random.Next(MIN_Y + 2, MAX_Y - 1),},
                  new Box { X = random.Next(MIN_X + 2, MAX_X - 2)/2*2 , Y = random.Next(MIN_Y + 2, MAX_Y - 1),},
                  new Box { X = random.Next(MIN_X + 2, MAX_X - 2)/2*2 , Y = random.Next(MIN_Y + 2, MAX_Y - 1),},
                  new Box { X = random.Next(MIN_X + 2, MAX_X - 2)/2*2 , Y = random.Next(MIN_Y + 2, MAX_Y - 1) }

               };


           

            Keys[] KeyLocations = new Keys[]
            {
                new Keys { X = 5, Y = PLAYER_START_POINT_Y - 1},
               
            };







            //// 박스 위치를 저장하기 위한 변수
            //int[] boxPositionsX = { 5, 7, 4 };
            //int[] boxPositionsY = { 5, 3, 4 };
            //// 박스가 골 위에 있는지를 저장하기 위한 변수
            //bool[] isBoxOnGoal = new bool[BOX_COUNT];

            //// 벽 위치를 저장하기 위한 변수
            //int[] wallPositionsX = { 7, 8 };
            //int[] wallPositionsY = { 7, 5 };

            //// 골 위치를 저장하기 위한 변수
            //int[] goalPositionsX = { 9, 1, 3 };
            //int[] goalPositionsY = { 9, 2, 3 };


            ConsoleKey key;

            ////-----------------------------------------------------------------------------------  // intro
            while (true)
            {
                //intro

                firstDoor.PaintDoor(15, 5, 15);

                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(200);
                RenderObject(15, 15, "Hey, do you want to open this door?");
                Thread.Sleep(2100);
                RenderObject(15, 16, "If so, say whatever if you want to.");
                Thread.Sleep(2500);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                RenderObject(15, 18, "(> Press Any Key)");

                RenderObject(0, 0, "");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Black;

                key = Console.ReadKey().Key;

                if (Console.KeyAvailable)
                {
                    Console.Clear();
                    break;
                }
            }

            Console.Clear();

            ////preclude
            //while (true)
            //{

            //    Console.ForegroundColor = ConsoleColor.DarkRed;

            //    const int START_OF_DOOR_X = 15;
            //    const int START_OF_DOOR_Y = 5;
            //    const int END_OF_DOOR_X = 35;
            //    const int END_OF_DOOR_Y = 12;
            //    const int SIZE_OF_DOOR = 10;
            //    const int DOOR_HANDLE_X = START_OF_DOOR_X + 2;
            //    const int DOOR_HANDLE_Y = START_OF_DOOR_Y + 5;

            //    firstDoor.PaintDoor(START_OF_DOOR_X, START_OF_DOOR_Y, 4);


            //    Console.ForegroundColor = ConsoleColor.White;
            //    RenderObject(15, 15, "And you know what?");

            //    Thread.Sleep(2100);

            //    RenderObject(14, 15, "You shouldn't have......");


            //    //MUsic play here.
            //    //playerMusic.SoundPlayers(@"C:\\Users\\Mati Kong\\Documents\\Matias\\doonot_open_the_closed_door\\doonot_open_the_closed_door\\PLEASE_DONT_OPEN_THE_CLOSED_DOOR\\PLEASE_DONT_OPEN_THE_CLOSED_DOOR\\bin\\Debug\\net7.0\\Noisy.wav");

            //    for (int i = 0; i < 6; i++)
            //    {
            //        playerMusic.SoundPlayers(@"C:\\Users\\Mati Kong\\Documents\\Matias\\doonot_open_the_closed_door\\doonot_open_the_closed_door\\PLEASE_DONT_OPEN_THE_CLOSED_DOOR\\PLEASE_DONT_OPEN_THE_CLOSED_DOOR\\bin\\Debug\\net7.0\\Growl.wav");
            //        Thread.Sleep(500);
            //    }
            //    Thread.Sleep(30);
            //    Console.ForegroundColor = ConsoleColor.DarkGray;
            //    RenderObject(13, 15, " You wouldn't even know......");
            //    Thread.Sleep(2100);

            //    for (int i = 0; i < 30; i++)
            //    {
            //        Console.ForegroundColor = ConsoleColor.DarkRed;
            //        RenderObject(15, i, " ----------------------------");
            //        Console.ForegroundColor = (ConsoleColor)(8);
            //        Thread.Sleep(50);
            //    }
            //    Console.Clear();
            //    break;

            //}


            // --------------------------------------------------------------------------------------게임화면
            while (true)
            {

                Render();


                if (Console.KeyAvailable)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    key = Console.ReadKey().Key;
                    Update(key);

                }


            }
            //----------------------------------------------------------------------------------------구현부분          

            // 프레임을 그립니다.
            void Render()
            {
                RenderObject(1, 18, "Key to escape :");
                RenderNumber(15, 18, keyCount);
                firstDoor.PaintDoor(FIRST_DOOR_LOCATION, 5, 12); //argument는 Startpoint
                secondDoor.PaintDoor(SECOND_DOOR_LOCATION, 5, 5);
                thirdDoor.PaintDoor(THIRD_DOOR_LOCATION, 5, 4);

                RenderObject(KeyLocations[0].X , KeyLocations[0].Y ,"K");

                //RenderColock
                timeClock.RenderClock();

                if (player.X == player.PreX)
                {

                }
                else
                {
                    RenderObject(player.PreX, player.PreY - 2, " ");
                    RenderObject(player.PreX, player.PreY - 1, " ");
                }


                Random random1 = new Random();
                int a = random1.Next() % 3;
                Console.ForegroundColor = (ConsoleColor)a;




                for (int i = 0; i < 1; ++i)
                {
                    string playerInstruction = playStart ? "" : " \n\n\n AD to move";
                    RenderObject(player.X, PLAYER_START_POINT_Y - 2, playerInstruction);

                    if (doorPoint[i].playerIsOnGoal == true || doorPoint[i + 1].playerIsOnGoal == true || doorPoint[i + 2].playerIsOnGoal == true)
                    {
                        string playerShape = "!";
                        RenderObject(player.X, PLAYER_START_POINT_Y - 2, playerShape);
                    }

                    else
                    {
                        string playerShape = "@";
                        RenderObject(player.X, PLAYER_START_POINT_Y - 2, playerShape);
                    }



                    RenderObject(player.X, player.Y - 1, "U");
                    if (doorPoint[i].playerIsOnGoal == true || doorPoint[i + 1].playerIsOnGoal == true || doorPoint[i + 2].playerIsOnGoal == true)
                    {
                        a = random1.Next() % 3;
                        Console.ForegroundColor = ConsoleColor.White;

                        string spaceInstruction = "\n\n\n SPACE to open";
                        RenderObject(player.X, PLAYER_START_POINT_Y - 2, spaceInstruction);
                    }
                    else if (doorPoint[i].playerIsOnGoal == false) //출력안하는걸 검은색으로 대체 
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        string spaceInstruction = "\n\n\n SPACE to open";
                        RenderObject(player.X, PLAYER_START_POINT_Y - 2, spaceInstruction);


                    }

                    a = random1.Next() % 3;
                    Console.ForegroundColor = (ConsoleColor)a;



                }






            }



            // 오브젝트를 그립니다.
            void RenderObject(int x, int y, string obj)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(obj);
            }

            void RenderNumber(int x, int y, int number)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(number);
            }





            void Update(ConsoleKey key)
            {
                int preX = player.X;
                int preY = player.Y;

                MovePlayer(key, player);


                /// 1P 공백함수 위치 조건문
                for (int i = 0; i < 3; i++)
                {
            

                    {
                        player.PreX = preX;
                        player.PreY = preY;
                    }
                }
                // 플레이어와 벽의 충돌 처리

                // 박스 이동 처리
                // 플레이어가 박스를 밀었을 때라는 게 무엇을 의미하는가?
                // => 플레이어가 이동했는데 플레이어의 위치와 박스 위치가 겹쳤다.
               
                    if (false == IsCollided(player.X, player.Y, KeyLocations[0].X, KeyLocations[0].Y))
                 {
                    switch (player.MoveDirection)
                    {
                        case Direction.Left:
                            //boxForFirst[i].X = Math.Clamp(boxForFirst[i].X - 2, MIN_X, MAX_X);
                            //player.X = boxForFirst[i].X + 2;
                            //player.PushedBoxIndex = i;


                         

                            break;
                        case Direction.Right:
                            //boxForFirst[i].X = Math.Clamp(boxForFirst[i].X + 2, MIN_X, MAX_X);
                            //player.X = boxForFirst[i].X + 2;
                            //player.PushedBoxIndex = i;
                           


                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine($"[Error] 플레이어 이동 방향 데이터가 오류입니다. : {player.MoveDirection}");

                            return;
                    }
                }


                  

                

                for (int DoorID = 0; DoorID < DOOR_COUNT; ++DoorID) // 모든 골 지점에 대해서
                {
                    // 플레이어가 도어입구에 있는지 확인한다.
                    doorPoint[DoorID].playerIsOnGoal = false; // 없을 가능성이 높기 때문에 false로 초기화 한다.


                    for (int goalId = 0; goalId < GOAL_COUNT; ++goalId) // 모든 박스에 대해서
                    {
                        // 박스가 골 지점 위에 있는지 확인한다.
                        if (player.X == doorPoint[DoorID].X)
                        {


                            doorPoint[DoorID].playerIsOnGoal = true; // 박스가 골 위에 있다는 사실을 저장해둔다.

                            break;
                        }
                    }
                }



                // 플레이어를 이동시킨다.
                // 실제메모리는 힙 , 메모리는 스택
                void MovePlayer(ConsoleKey key, Player playerFirst)
                {//플레이어 이동함수

                    if (key == ConsoleKey.A)
                    {

                        playerFirst.X = Math.Max(MIN_X, playerFirst.X - 1);
                        playerFirst.MoveDirection = Direction.Left;
                        playStart = true;
                    }

                    if (key == ConsoleKey.D)
                    {

                        playerFirst.X = Math.Min(playerFirst.X + 1, MAX_X);
                        playerFirst.MoveDirection = Direction.Right;
                        playStart = true;
                    }
                    for(int i =0 ; i < DOOR_COUNT;i++)
                    {
                        if (key == ConsoleKey.Spacebar || doorPoint[i].playerIsOnGoal == true)
                        {
                            int a = random.Next(0,15);
                            Console.BackgroundColor = (ConsoleColor)a;
                            Render();
                            Console.Clear();

                            FIRST_DOOR_LOCATION = random.Next(5, 30);
                            SECOND_DOOR_LOCATION = random.Next(30, 50);
                            THIRD_DOOR_LOCATION = SECOND_DOOR_LOCATION;
                            
                           

                        }
                    }
                  
                    
                }




            }
            // 두 물체가 충돌했는지 판별합니다.
              bool IsCollided(int x1, int y1, int x2, int y2 )
            {
                if (x1 == x2)
                {
                    keyCount++;
                    Console.Clear();
                    message.PrintMessage();
                    Random random = new Random();
                    KeyLocations[0].X = random.Next(5, 50);
                    return true;
                  
                }
                else
                {
                    return false;
                }
               
            }
        }


    }

}


