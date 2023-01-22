using PLEASE_DONT_OPEN_THE_CLOSED_DOOR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace PLEASE_DONT_OPEN_THE_CLOSED_DOOR
{
    internal class Player
    {
        public int X;
        public int Y;
        public int PreX;
        public int PreY;
        public Direction MoveDirection;
        public int PushedBoxIndex;

        //class player가 PushBoxIndex를 굳이 묶지 않아도 된다고 판단할 수도 있음.
        //; 충돌처리와 관련되어있기 때문에, 확장성이 더 높을 수 있음.

        //pushout은 플레이어뿐아니라, 박스끼리 충돌시에도 사용하기;에 따로 구분하지 않음.\\
        ConsoleKeyInfo ConsoleKeyInfo;
        ConsoleKey ConsoleKey;
    }
}

