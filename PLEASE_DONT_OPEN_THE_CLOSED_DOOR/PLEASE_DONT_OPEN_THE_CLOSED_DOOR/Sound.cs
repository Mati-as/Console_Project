using System.Media;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using PLEASE_DONT_OPEN_THE_CLOSED_DOOR; 

namespace PLEASE_DONT_OPEN_THE_CLOSED_DOOR
{
   
        public partial class PlayMusic
        {

            WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();

            public void SoundPlayers(string a = " " )
            {
                player.URL = (a);
                //player.controls.play();
            }

           
        }
    
   
}
