using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BASSdotNET
{
    public class BASS
    {
        [DllImport(@"bass.dll")]
        public static extern bool BASS_Start(); //BASS START

        [DllImport(@"bass.dll")]
        public static extern bool BASS_Stop();

        [DllImport(@"bass.dll")]
        public static extern bool BASS_Init(int device, Int32 freq, Int32 flags, int win, int dsguid);

        [DllImport(@"bass.dll")]
        public static extern UInt32 BASS_StreamCreateFile(int mem, string filename, int offset, int length, int flags);

        [DllImport(@"bass.dll")]
        public static extern void BASS_ChannelPlay(int handle, bool restart);

        public bool Init_Bass(int dev_id, Int32 frequence, Int32 flags_bass ,int windows, int dsGUID)
        {
            if (BASS_Init(dev_id, frequence, flags_bass, windows, dsGUID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool START()
        {
            if(BASS_Start() == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Stop_Bass()
        {
            if(BASS_Stop() == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public UInt32 CreateBASS_FileStream(int m, string file_name, int offs, int length_filename, int flag)
        {
            UInt32 fx = BASS_StreamCreateFile(m, file_name, offs, length_filename, flag);
            if(fx == 0)
            {
                return 0; //Returning Zero if BASS Is Not Creating File :D
            }
            return fx;
        }
        public void ChannelPlay(int hx, bool restart_music)
        {
            BASS_ChannelPlay(hx, restart_music);
        }
    }
}
