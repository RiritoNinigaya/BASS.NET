using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BASSdotNET
{
    public class Str
    {
        public string get_resourcefolder()
        {
            StringRes resource = new StringRes();
            return resource.GetBASS();
        }
    }
    public class BASS
    {
        string xz()
        {
            Str stringxz = new Str();
            return stringxz.get_resourcefolder();
        }
        [DllImport("C:\\BassLib\\bass.dll")]
        public static extern bool BASS_Start(); //BASS START

        [DllImport("C:\\BassLib\\bass.dll")]
        public static extern bool BASS_Stop(); //Stopping BASS Sound File

        [DllImport("C:\\BassLib\\bass.dll")]
        public static extern bool BASS_Init(int device, Int32 freq, Int32 flags, int win, int dsguid); //Initializating BASS

        [DllImport("C:\\BassLib\\bass.dll")]
        public static extern UInt32 BASS_StreamCreateFile(int mem, string filename, int offset, int length, int flags); //Creating Stream File :D

        [DllImport("C:\\BassLib\\bass.dll")]
        public static extern void BASS_ChannelPlay(UInt32 handle, bool restart); //Calling C Programming Function for Playing Sound File :D

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
        public void ChannelPlay(UInt32 hx, bool restart_music)
        {
            BASS_ChannelPlay(hx, restart_music);
        }
    }
}
