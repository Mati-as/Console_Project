using System;

namespace Sokoban_Mati
{//namespace 선언해야 다른 네임스페이스에서도 불러올 수 있다
//안그러면 namespaceaname.something 같이 불러와야한다.
    enum Direction // 방향을 저장하는 타입
    {
        None,
        Left,
        Right,
        Up,
        Down,
        LeftForSeoncd,
        RightForSeoncd,
        UpForSeoncd,
        DownForSecond,
        Javelin1P,
        Javelin2P
    }




    class Sokoban
    {

        internal static Player playerFirst = new Player();
        internal static Player playerSecond = new Player();

        public static void Main()
        {
           

            // 초기 세팅
            Console.ResetColor(); // 컬러를 초기화 하는 것
            Console.CursorVisible = false; // 커서를 숨기기
            Console.Title = "홍성재의 파이어펀치 2인용"; // 타이틀을 설정한다.
            Console.BackgroundColor = ConsoleColor.Black; // 배경색을 설정한다.
            Console.ForegroundColor = ConsoleColor.Yellow; // 글꼴색을 설정한다.
            Console.Clear(); // 출력된 내용을 지운다.

            // 기호 상수 정의
            const int GOAL_COUNT = 4;
            const int BOX_COUNT = GOAL_COUNT;
            const int WALL_COUNT = 4;

            const int MIN_X = 10;
            const int MAX_X = 40;
            const int MIN_Y = 10;
            const int MAX_Y = 25;

            const int FIRST_PLAYER_INSTRUCTION_X = 10;
            const int FIRST_PLAYER_INSTRUCTION_Y = 5;

            //2P Character's Map
            const int MIN_X_SECOND = 50;
            const int MIN_Y_SECOND = 10;
            const int MAX_X_SECOND = 80;
            const int MAX_Y_SECOND = 25;


            const int SECOND_PLAYER_INSTRUCTION_X = 50;
            const int SECOND_PLAYER_INSTRUCTION_Y = 5;


            // 플레이어 위치를 저장하기 위한 변수
            // int secondPlayerX = 0;
            // int playerY = 0;
            // Direction playerMoveDirection = Direction.None;
            // int pushedBoxIndex = 0;

            //structure 를 사용한 Player
            //Player player = new Player
            //{
            //    X = MIN_X + 2,
            //    Y = MIN_Y + 2,
            //    PreX = 0,
            //    PreY = 0,
            //    MoveDirection = Direction.None,
            //    PushedBoxIndex = 0

            //};

           
            
            playerFirst.X = MIN_X + 2;
            playerFirst.Y = MIN_Y + 2;
            playerFirst.PreX = 0;
            playerFirst.PreY = 0;
            playerFirst.MoveDirection = Direction.None;
            playerFirst.PushedBoxIndex = 0;



            playerSecond.X = MIN_X_SECOND + 2;
            playerSecond.Y = MIN_Y_SECOND + 2;
            playerSecond.PreX = 0;
            playerSecond.PreY = 0;
            playerSecond.MoveDirection = Direction.None;
            playerSecond.PushedBoxIndex = 0;



            //Box[] boxForFirst = new Box[]
            //{
            //    new Box { X = MIN_X + 6, Y = MIN_Y + 5, isOnGoal = false},
            //    new Box { X = MIN_X + 8, Y = MIN_Y + 3, isOnGoal = false},
            //    new Box { X = MIN_X + 4, Y = MIN_Y + 3, isOnGoal = false},
            //    new Box { X = MIN_X + 16,Y = MIN_Y + 10 ,isOnGoal = false}
            //};



            Random random = new Random();

            int randomBoxNumX = 0;
            int randomBoxNumY = 0;

          

            Box[] boxForFirst = new Box[BOX_COUNT] {
                  new Box { X = random.Next(MIN_X + 2, MAX_X - 2)/2*2 , Y = random.Next(MIN_Y + 2, MAX_Y - 1), isOnGoal = false},
                  new Box { X = random.Next(MIN_X + 2, MAX_X - 2)/2*2 , Y = random.Next(MIN_Y + 2, MAX_Y - 1), isOnGoal = false},
                  new Box { X = random.Next(MIN_X + 2, MAX_X - 2)/2*2 , Y = random.Next(MIN_Y + 2, MAX_Y - 1), isOnGoal = false},
                  new Box { X = random.Next(MIN_X + 2, MAX_X - 2)/2*2 , Y = random.Next(MIN_Y + 2, MAX_Y - 1) ,isOnGoal = false}

               };



            Box[] boxForSecond = new Box[]
             {              
                new Box { X = random.Next(MIN_X_SECOND + 2, MAX_X_SECOND - 2)/2*2, Y = random.Next(MIN_Y_SECOND + 2, MAX_Y_SECOND - 1), isOnGoal = false},
                new Box { X = random.Next(MIN_X_SECOND + 2, MAX_X_SECOND - 2)/2*2, Y = random.Next(MIN_Y_SECOND + 2, MAX_Y_SECOND - 1), isOnGoal = false},
                new Box { X = random.Next(MIN_X_SECOND + 2, MAX_X_SECOND - 2)/2*2, Y = random.Next(MIN_Y_SECOND + 2, MAX_Y_SECOND - 1), isOnGoal = false},
                new Box { X = random.Next(MIN_X_SECOND + 2, MAX_X_SECOND - 2)/2*2, Y = random.Next(MIN_Y_SECOND + 2, MAX_Y_SECOND - 1), isOnGoal = false}
             };



            Wall[] wallFirst = new Wall[]
            {
                new Wall { X = MIN_X + 8,  Y = MIN_Y + 10 },
                new Wall { X = MIN_X + 20, Y = MIN_Y + 10 },
                new Wall { X = MIN_X + 4,  Y = MIN_Y + 5 },
                new Wall { X = MIN_X + 12, Y = MIN_Y + 11 },
                new Wall { X = MIN_X + 16, Y = MIN_Y + 10 },
            };



            // 두번쨰 플레이어를 위한 맵
            Wall[] wallForSecond = new Wall[]
           {
                new Wall { X =  MIN_X_SECOND + 20,Y = MIN_Y_SECOND + 10 },
                new Wall { X =  MIN_X_SECOND + 4, Y = MIN_Y_SECOND + 5 },
                new Wall { X =  MIN_X_SECOND + 12,Y = MIN_Y_SECOND + 11 },
                new Wall { X =  MIN_X_SECOND +16, Y = MIN_Y_SECOND + 10 }
           };


            Goal[] goalFirst = new Goal[]
            {
                new Goal { X = MIN_X + 8, Y = MIN_Y + 9 },
                new Goal { X = MIN_X + 6, Y = MIN_Y + 6 },
                new Goal { X = MIN_X + 4, Y = MIN_Y + 6 },
                new Goal { X = MIN_X + 10,Y = MIN_Y + 8 }
            };

            Goal[] goalSecond = new Goal[]
            {
                new Goal { X = MIN_X_SECOND + 8, Y = MIN_Y_SECOND + 9 },
                new Goal { X = MIN_X_SECOND + 4, Y = MIN_Y_SECOND + 2 },
                new Goal { X = MIN_X_SECOND + 6, Y = MIN_Y_SECOND + 6 },
                new Goal { X = MIN_X_SECOND + 10,Y = MIN_Y_SECOND + 7 }
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
         

            string errorMessage = "[Error] 플레이어 이동 방향 데이터가 오류입니다. : {player.MoveDirection}";

            // 게임 루프 구성
            while (true)
            {
                Render();
               

                int boxOnGoalCount = 0;
                int boxOnGoalCountForSeCond = 0;

                key = ConsoleKey.Applications;

                
                    if (Console.KeyAvailable)
                    {   
                       
                        key = Console.ReadKey().Key;
                        UpdateForSecond(key);
                        Update(key);

                    }

                    Console.SetCursorPosition(25, 30);
                    Console.WriteLine($"key1 : {key}");

    
                //입력값을 블록킹을 방지하며 받아오기

          



                // 박스와 골의 처리
               

                // 골 지점에 박스에 존재하냐?
                for (int boxId = 0; boxId < BOX_COUNT; ++boxId) // 모든 골 지점에 대해서
                {
                    // 현재 박스가 골 위에 올라와 있는지 체크한다.
                    boxForFirst[boxId].isOnGoal = false; // 없을 가능성이 높기 때문에 false로 초기화 한다.

                    for (int goalId = 0; goalId < GOAL_COUNT; ++goalId) // 모든 박스에 대해서
                    {
                        // 박스가 골 지점 위에 있는지 확인한다.
                        if (boxForFirst[boxId].X == goalFirst[goalId].X && boxForFirst[boxId].Y == goalFirst[goalId].Y)
                        {
                            ++boxOnGoalCount;

                            boxForFirst[boxId].isOnGoal = true; // 박스가 골 위에 있다는 사실을 저장해둔다.

                            break;
                        }
                    }


                }

                for (int boxId = 0; boxId < BOX_COUNT; ++boxId) // 모든 골 지점에 대해서
                {
                    // 현재 박스가 골 위에 올라와 있는지 체크한다.
                    boxForSecond[boxId].isOnGoal = false; // 없을 가능성이 높기 때문에 false로 초기화 한다.


                    for (int goalId = 0; goalId < GOAL_COUNT; ++goalId) // 모든 박스에 대해서
                    {
                        // 박스가 골 지점 위에 있는지 확인한다.
                        if (boxForSecond[boxId].X == goalSecond[goalId].X && boxForSecond[boxId].Y == goalSecond[goalId].Y)
                        {
                            ++boxOnGoalCountForSeCond;

                            boxForSecond[boxId].isOnGoal = true; // 박스가 골 위에 있다는 사실을 저장해둔다.

                            break;
                        }
                    }
                }


                // 모든 골 지점에 박스가 올라와 있다면?
                if (boxOnGoalCount == GOAL_COUNT)
                {
                    Console.Clear();
                    Console.WriteLine("1P 승리");

                    break;
                }

                else if (boxOnGoalCountForSeCond == GOAL_COUNT)
                {
                    Console.Clear();
                    Console.WriteLine("2P 승리");

                    break;
                }
            }


            // 프레임을 그립니다.
            void Render()
            {
                // 이전 프레임을 지운다.


                // 플레이어를 그린다.
                Console.ForegroundColor = ConsoleColor.DarkRed;
                RenderObject(playerFirst.X, playerFirst.Y, "♤");
                if (playerFirst.X == playerFirst.PreX && playerFirst.Y == playerFirst.PreY)
                {
                    RenderObject(playerFirst.X, playerFirst.Y, "♤");
                }
                else
                {
                    RenderObject(playerFirst.PreX, playerFirst.PreY, "  ");
                }

                // 두번째 플레이어를 그린다.            
                RenderObject(playerSecond.X, playerSecond.Y, "♧");
                if(playerSecond.X == playerSecond.PreX && playerSecond.Y == playerSecond.PreY)
                {
                    RenderObject(playerSecond.X, playerSecond.Y, "♤");
                }
                else
                {
                    RenderObject(playerSecond.PreX, playerSecond.PreY, "  ");
                }
                

                Console.ForegroundColor = ConsoleColor.Yellow;


                // 테두리 그리기
                for (int i = MIN_X - 2; i < MAX_X + 2; i = i + 2)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    RenderObject(i, MIN_Y + 1, "▩");
                    RenderObject(i, MAX_Y + 1, "▩");

                }

                for (int i = MIN_Y + 1; i < MAX_Y + 2; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    RenderObject(MIN_X - 2, i, "▩");
                    RenderObject(MAX_X + 2, i, "▩");

                }

                for (int i = MIN_X_SECOND - 2; i < MAX_X_SECOND + 2; i = i + 2)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    RenderObject(i, MIN_Y_SECOND + 1, "▩");
                    RenderObject(i, MAX_Y_SECOND + 1, "▩");

                }

                // 테두리 그리기
                for (int i = MIN_Y_SECOND + 1; i < MAX_Y_SECOND + 2; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    RenderObject(MIN_X_SECOND - 2, i, "▩");
                    RenderObject(MAX_X_SECOND + 2, i, "▩");

                }



                Console.ForegroundColor = ConsoleColor.Yellow;
                // 골을 그린다.
                for (int i = 0; i < GOAL_COUNT; ++i)
                {
                    RenderObject(goalFirst[i].X, goalFirst[i].Y, "☆");
                    RenderObject(goalSecond[i].X, goalSecond[i].Y, "☆");
                }

                // 박스를 그린다.
                for (int boxId = 0; boxId < BOX_COUNT; ++boxId)
                {
                    string boxShape = boxForFirst[boxId].isOnGoal ? "★" : "■";
                    RenderObject(boxForFirst[boxId].X, boxForFirst[boxId].Y, boxShape);

                    string SecondboxShape = boxForSecond[boxId].isOnGoal ? "★" : "■";
                    RenderObject(boxForSecond[boxId].X, boxForSecond[boxId].Y, SecondboxShape);
                }

                // 벽을 그린다.
                for (int wallId = 0; wallId < WALL_COUNT; ++wallId)
                {
                    RenderObject(wallFirst[wallId].X, wallFirst[wallId].Y, "▩");

                    RenderObject(wallForSecond[wallId].X, wallForSecond[wallId].Y, "▩");
                }

                // 설명서를 그린다

                RenderObject(FIRST_PLAYER_INSTRUCTION_X, FIRST_PLAYER_INSTRUCTION_Y, "1P :WSDA");
                RenderObject(SECOND_PLAYER_INSTRUCTION_X, SECOND_PLAYER_INSTRUCTION_Y, "2P:↑↓←→");


            }



            // 오브젝트를 그립니다.
            void RenderObject(int x, int y, string obj)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(obj);
            }




            void Update(ConsoleKey key)
            {
                int preX = playerFirst.X;
                int preY = playerFirst.Y;

                MovePlayer(key, playerFirst);


                /// 1P 공백함수 위치 조건문
                for (int i = 0; i < GOAL_COUNT; i++)
                {
                 if    (playerFirst.X != goalFirst[i].X
                        && playerFirst.Y != goalFirst[i].Y
                        && playerFirst.X != boxForFirst[i].X
                        && playerFirst.Y != boxForFirst[i].Y
                      
                    )

                    {
                        playerFirst.PreX = preX;
                        playerFirst.PreY = preY;
                    }
                }
                // 플레이어와 벽의 충돌 처리
                for (int wallId = 0; wallId < WALL_COUNT; ++wallId)
                {
                    if (false == IsCollided(playerFirst.X, playerFirst.Y, wallFirst[wallId].X, wallFirst[wallId].Y))
                    {
                        continue;
                    }

                    switch (playerFirst.MoveDirection)
                    {
                        case Direction.Left:

                            playerFirst.X = wallFirst[wallId].X + 2;

                            break;
                        case Direction.Right:

                            playerFirst.X = wallFirst[wallId].X - 2;
                            break;
                        case Direction.Up:

                            playerFirst.Y = wallFirst[wallId].Y + 1;
                            break;
                        case Direction.Down:

                            playerFirst.Y = wallFirst[wallId].Y - 1;
                            break;


                        default:
                            ExitWithError(errorMessage);

                            return;
                    }


                    break;
                }




                void ExitWithError(string errorMessage)
                {
                    Console.Clear();
                    Console.WriteLine(errorMessage);
                }


                // 박스 이동 처리
                // 플레이어가 박스를 밀었을 때라는 게 무엇을 의미하는가?
                // => 플레이어가 이동했는데 플레이어의 위치와 박스 위치가 겹쳤다.
                for (int i = 0; i < BOX_COUNT; ++i)
                {
                    if (false == IsCollided(playerFirst.X, playerFirst.Y, boxForFirst[i].X, boxForFirst[i].Y))
                    {
                        continue;
                    }


                    switch (playerFirst.MoveDirection)
                    {
                        case Direction.Left:
                            boxForFirst[i].X = Math.Clamp(boxForFirst[i].X - 2, MIN_X, MAX_X);
                            playerFirst.X = boxForFirst[i].X + 2;
                            playerFirst.PushedBoxIndex = i;
                            break;
                        case Direction.Right:
                            boxForFirst[i].X = Math.Clamp(boxForFirst[i].X + 2, MIN_X, MAX_X);
                            playerFirst.X = boxForFirst[i].X - 2;
                            playerFirst.PushedBoxIndex = i;
                            break;
                        case Direction.Up:
                            boxForFirst[i].Y = Math.Clamp(boxForFirst[i].Y - 1, MIN_Y, MAX_Y);
                            playerFirst.Y = boxForFirst[i].Y + 1;
                            playerFirst.PushedBoxIndex = i;

                            break;
                        case Direction.Down:
                            boxForFirst[i].Y = Math.Clamp(boxForFirst[i].Y + 1, MIN_Y, MAX_Y);
                            playerFirst.Y = boxForFirst[i].Y - 1;
                            playerFirst.PushedBoxIndex = i;
                            break;


                        default:
                            Console.Clear();
                            Console.WriteLine($"[Error] 플레이어 이동 방향 데이터가 오류입니다. : {playerFirst.MoveDirection}");

                            return;
                    }

                }




                // 박스와 벽의 충돌 처리
                for (int wallId = 0; wallId < WALL_COUNT; ++wallId)
                {
                    if (false == IsCollided(boxForFirst[playerFirst.PushedBoxIndex].X, boxForFirst[playerFirst.PushedBoxIndex].Y, wallFirst[wallId].X, wallFirst[wallId].Y))
                    {
                        continue;
                    }

                    switch (playerFirst.MoveDirection)
                    {
                        case Direction.Left:
                            boxForFirst[playerFirst.PushedBoxIndex].X = wallFirst[wallId].X + 2;
                            playerFirst.X = boxForFirst[playerFirst.PushedBoxIndex].X + 2;
                            break;
                        case Direction.Right:
                            boxForFirst[playerFirst.PushedBoxIndex].X = wallFirst[wallId].X - 2;
                            playerFirst.X = boxForFirst[playerFirst.PushedBoxIndex].X - 2;
                            break;
                        case Direction.Up:
                            boxForFirst[playerFirst.PushedBoxIndex].Y = wallFirst[wallId].Y + 1;
                            playerFirst.Y = boxForFirst[playerFirst.PushedBoxIndex].Y + 1;
                            break;
                        case Direction.Down:
                            boxForFirst[playerFirst.PushedBoxIndex].Y = wallFirst[wallId].Y - 1;
                            playerFirst.Y = boxForFirst[playerFirst.PushedBoxIndex].Y - 1;
                            break;

                        //두번쨰 캐릭터 처리


                        default:
                            Console.Clear();
                            Console.WriteLine($"[Error] 플레이어 이동 방향 데이터가 오류입니다. : {playerFirst.MoveDirection}");

                            return;
                    }

                    break;
                }




                // 박스끼리 충돌 처리
                for (int collidedBoxId = 0; collidedBoxId < BOX_COUNT; ++collidedBoxId)
                {
                    // 같은 박스라면 처리할 필요가 X
                    if (Sokoban.playerFirst.PushedBoxIndex == collidedBoxId)
                    {
                        continue;
                    }
                    if (false == IsCollided(boxForFirst[Sokoban.playerFirst.PushedBoxIndex].X, boxForFirst[Sokoban.playerFirst.PushedBoxIndex].Y, boxForFirst[collidedBoxId].X, boxForFirst[collidedBoxId].Y))
                    {
                        continue;
                    }

                    switch (playerFirst.MoveDirection)
                    {
                        case Direction.Left:
                            boxForFirst[playerFirst.PushedBoxIndex].X = boxForFirst[collidedBoxId].X + 2;
                            playerFirst.X = boxForFirst[playerFirst.PushedBoxIndex].X + 2;

                            break;
                        case Direction.Right:
                            boxForFirst[playerFirst.PushedBoxIndex].X = boxForFirst[collidedBoxId].X - 2;
                            playerFirst.X = boxForFirst[playerFirst.PushedBoxIndex].X - 2;

                            break;
                        case Direction.Up:
                            boxForFirst[playerFirst.PushedBoxIndex].Y = boxForFirst[collidedBoxId].Y + 1;
                            playerFirst.Y = boxForFirst[playerFirst.PushedBoxIndex].Y + 1;

                            break;

                        case Direction.Down:
                            boxForFirst[playerFirst.PushedBoxIndex].Y = boxForFirst[collidedBoxId].Y - 1;
                            playerFirst.Y = boxForFirst[playerFirst.PushedBoxIndex].Y - 1;




                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine($"[Error] 플레이어 이동 방향 데이터가 오류입니다. : {playerFirst.MoveDirection}");

                            return;
                    }

                    break;
                }




            }


            void UpdateForSecond(ConsoleKey key2)
            {
                int preX = playerSecond.X;
                int preY = playerSecond.Y;


                MoveSecondPlayer(key2, ref playerSecond);


                /// 공백함수 위치 조건문
                for (int i = 0; i < GOAL_COUNT; i++)
                {
                    if (playerSecond.X != goalSecond[i].X &&
                        playerSecond.Y != goalSecond[i].Y &&
                        playerSecond.X != boxForSecond[i].X &&
                        playerSecond.Y != boxForSecond[i].Y)
                    {
                        playerSecond.PreX = preX;
                        playerSecond.PreY = preY;
                    }
                }

                for (int wallId = 0; wallId < WALL_COUNT; ++wallId)
                {
                    if (false == IsCollided(playerSecond.X, playerSecond.Y, wallForSecond[wallId].X, wallForSecond[wallId].Y))
                    {
                        continue;
                    }

                    switch (playerSecond.MoveDirection)
                    {

                        //플레이어 2와 벽과 충돌처리
                        case Direction.LeftForSeoncd:
                            playerSecond.X = wallForSecond[wallId].X + 2;

                            break;
                        case Direction.RightForSeoncd:
                            playerSecond.X = wallForSecond[wallId].X - 2;
                            break;
                        case Direction.UpForSeoncd:
                            playerSecond.Y = wallForSecond[wallId].Y + 1;
                            break;
                        case Direction.DownForSecond:
                            playerSecond.Y = wallForSecond[wallId].Y - 1;
                            break;


                        default:
                            Console.Clear();
                            Console.WriteLine($"[Error] 플레이어 이동 방향 데이터가 오류입니다. : {playerSecond.MoveDirection}");

                            return;
                    }


                    break;
                }
                //두번째 박스 이동처리
                for (int i = 0; i < BOX_COUNT; ++i)
                {
                    if (false == IsCollided(playerSecond.X, playerSecond.Y, boxForSecond[i].X, boxForSecond[i].Y))
                    {
                        continue;
                    }

                    switch (playerSecond.MoveDirection)
                    {
                        case Direction.LeftForSeoncd:
                            boxForSecond[i].X = Math.Clamp(boxForSecond[i].X - 2, MIN_X_SECOND, MAX_X_SECOND);
                            playerSecond.X = boxForSecond[i].X + 2;
                            playerSecond.PushedBoxIndex = i;
                            break;

                        case Direction.RightForSeoncd:
                            boxForSecond[i].X = Math.Clamp(boxForSecond[i].X + 2, MIN_X_SECOND, MAX_X_SECOND);
                            playerSecond.X = boxForSecond[i].X - 2;
                            playerSecond.PushedBoxIndex = i;
                            break;

                        case Direction.UpForSeoncd:
                            boxForSecond[i].Y = Math.Clamp(boxForSecond[i].Y - 1, MIN_Y_SECOND, MAX_Y_SECOND);
                            playerSecond.Y = boxForSecond[i].Y + 1;
                            playerSecond.PushedBoxIndex = i;
                            break;

                        case Direction.DownForSecond:
                            boxForSecond[i].Y = Math.Clamp(boxForSecond[i].Y + 1, MIN_Y_SECOND, MAX_Y_SECOND);
                            playerSecond.Y = boxForSecond[i].Y - 1;
                            playerSecond.PushedBoxIndex = i;
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine($"[Error] 플레이어 이동 방향 데이터가 오류입니다. : {playerSecond.MoveDirection}");

                            return;


                    }
                }

                // 두번째 박스와 벽의 충돌 처리
                for (int wallId = 0; wallId < WALL_COUNT; ++wallId)
                {
                    if (false == IsCollided(boxForSecond[playerSecond.PushedBoxIndex].X, boxForSecond[playerSecond.PushedBoxIndex].Y, wallForSecond[wallId].X, wallForSecond[wallId].Y))
                    {
                        continue;
                    }

                    switch (playerSecond.MoveDirection)
                    {
                        case Direction.LeftForSeoncd:
                            boxForSecond[playerSecond.PushedBoxIndex].X = wallForSecond[wallId].X + 2;
                            playerSecond.X = boxForSecond[playerSecond.PushedBoxIndex].X + 2;
                            break;
                        case Direction.RightForSeoncd:
                            boxForSecond[playerSecond.PushedBoxIndex].X = wallForSecond[wallId].X - 2;
                            playerSecond.X = boxForSecond[playerSecond.PushedBoxIndex].X - 2;
                            break;
                        case Direction.UpForSeoncd:
                            boxForSecond[playerSecond.PushedBoxIndex].Y = wallForSecond[wallId].Y + 1;
                            playerSecond.Y = boxForSecond[playerSecond.PushedBoxIndex].Y + 1;
                            break;
                        case Direction.DownForSecond:
                            boxForSecond[playerSecond.PushedBoxIndex].Y = wallForSecond[wallId].Y - 1;
                            playerSecond.Y = boxForSecond[playerSecond.PushedBoxIndex].Y - 1;
                            break;

                        //두번쨰 캐릭터 처리


                        default:
                            Console.Clear();
                            Console.WriteLine($"[Error] 플레이어 이동 방향 데이터가 오류입니다. : {playerSecond.MoveDirection}");

                            return;
                    }

                    break;
                }

                //두번째 플레이어의 박스끼리 충돌 
                for (int collidedBoxId = 0; collidedBoxId < BOX_COUNT; ++collidedBoxId)
                {
                    // 같은 박스라면 처리할 필요가 X
                    if (playerSecond.PushedBoxIndex == collidedBoxId)
                    {
                        continue;
                    }
                    if (false == IsCollided(boxForSecond[playerSecond.PushedBoxIndex].X, boxForSecond[playerSecond.PushedBoxIndex].Y, boxForSecond[collidedBoxId].X, boxForSecond[collidedBoxId].Y))
                    {
                        continue;
                    }

                    switch (playerSecond.MoveDirection)
                    {

                        case Direction.LeftForSeoncd:
                            boxForSecond[playerSecond.PushedBoxIndex].X = boxForSecond[collidedBoxId].X + 2;
                            playerSecond.X = boxForSecond[playerSecond.PushedBoxIndex].X + 2;

                            break;
                        case Direction.RightForSeoncd:
                            boxForSecond[playerSecond.PushedBoxIndex].X = boxForSecond[collidedBoxId].X - 2;
                            playerSecond.X = boxForSecond[playerSecond.PushedBoxIndex].X - 2;

                            break;
                        case Direction.UpForSeoncd:
                            boxForSecond[playerSecond.PushedBoxIndex].Y = boxForSecond[collidedBoxId].Y + 1;
                            playerSecond.Y = boxForSecond[playerSecond.PushedBoxIndex].Y + 1;

                            break;
                        case Direction.DownForSecond:
                            boxForSecond[playerSecond.PushedBoxIndex].Y = boxForSecond[collidedBoxId].Y - 1;
                            playerSecond.Y = boxForSecond[playerSecond.PushedBoxIndex].Y - 1;


                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine($"[Error] 플레이어 이동 방향 데이터가 오류입니다. : {playerSecond.MoveDirection}");

                            return;
                    }

                    break;
                }


               


            }


            // 플레이어를 이동시킨다.
            // 실제메모리는 힙 , 메모리는 스택
            void MovePlayer(ConsoleKey key, Player playerFirst)
            {//플레이어 이동함수

                if (key == ConsoleKey.A)
                {

                    playerFirst.X = Math.Max(MIN_X, playerFirst.X - 2);
                    playerFirst.MoveDirection = Direction.Left;
                }

                if (key == ConsoleKey.D)
                {

                    playerFirst.X = Math.Min(playerFirst.X + 2, MAX_X);
                    playerFirst.MoveDirection = Direction.Right;
                }

                if (key == ConsoleKey.W)
                {

                    playerFirst.Y = Math.Max(MIN_Y, playerFirst.Y - 1);
                    playerFirst.MoveDirection = Direction.Up;
                }

                if (key == ConsoleKey.S)
                {

                    playerFirst.Y = Math.Min(playerFirst.Y + 1, MAX_Y);
                    playerFirst.MoveDirection = Direction.Down;
                }


            }

            void MoveSecondPlayer(ConsoleKey key, ref Player secondPlayer)
            {
                //두번째 플레이어의 키
                if (key == ConsoleKey.LeftArrow)
                {

                    secondPlayer.X = Math.Max(MIN_X_SECOND, secondPlayer.X - 2);
                    secondPlayer.MoveDirection = Direction.LeftForSeoncd;
                }

                if (key == ConsoleKey.RightArrow)
                {

                    secondPlayer.X = Math.Min(secondPlayer.X + 2, MAX_X_SECOND);
                    secondPlayer.MoveDirection = Direction.RightForSeoncd;
                }

                if (key == ConsoleKey.UpArrow)
                {

                    secondPlayer.Y = Math.Max(MIN_Y_SECOND, secondPlayer.Y - 1);
                    secondPlayer.MoveDirection = Direction.UpForSeoncd;
                }

                if (key == ConsoleKey.DownArrow)
                {

                    secondPlayer.Y = Math.Min(secondPlayer.Y + 1, MAX_Y_SECOND);
                    secondPlayer.MoveDirection = Direction.DownForSecond;
                }
            }



        }
        // 두 물체가 충돌했는지 판별합니다.
        private static bool IsCollided(int x1, int y1, int x2, int y2)
        {
            if (x1 == x2 && y1 == y2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }



   
}


