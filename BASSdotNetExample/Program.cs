using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BASSdotNET;
using AnyConsole;
using System.Drawing;

namespace BASSdotNetExample
{
    internal class Program
    {
        [DllImport("kernel32.dll")]
        private static extern Int32 WideCharToMultiByte(UInt32 CodePage, UInt32 dwFlags, [MarshalAs(UnmanagedType.LPWStr)] String lpWideCharStr, Int32 cchWideChar, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder lpMultiByteStr, Int32 cbMultiByte, IntPtr lpDefaultChar, IntPtr lpUsedDefaultChar);

        public static string Utf16ToUtf8(string utf16String)
        {
            Int32 iNewDataLen = WideCharToMultiByte(Convert.ToUInt32(Encoding.UTF8.CodePage), 0, utf16String, utf16String.Length, null, 0, IntPtr.Zero, IntPtr.Zero);
            if (iNewDataLen > 1)
            {
                StringBuilder utf8String = new StringBuilder(iNewDataLen);
                WideCharToMultiByte(Convert.ToUInt32(Encoding.UTF8.CodePage), 0, utf16String, -1, utf8String, utf8String.Capacity, IntPtr.Zero, IntPtr.Zero);

                return utf8String.ToString();
            }
            else
            {
                return String.Empty;
            }
        }
        static void Main(string[] args)
        {
            var console = new ExtendedConsole();
            console.Configure(config =>
            {
                config.SetStaticRow("Header", RowLocation.Top, Color.White, Color.DarkRed);
                config.SetStaticRow("SubHeader", RowLocation.Top, 1, Color.White, Color.FromArgb(30, 30, 30));
                config.SetStaticRow("Footer", RowLocation.Bottom, Color.White, Color.DarkBlue);
                config.SetLogHistoryContainer(RowLocation.Top, 2);
                config.SetUpdateInterval(TimeSpan.FromMilliseconds(100));
                config.SetMaxHistoryLines(1000);
                config.SetQuitHandler((consoleInstance) => {
                    Console.Write("Quiting...");
                    Environment.Exit(3021);
                });
            });
            console.Start();
            console.Title = "BASS.NET Example Console Edition by RiritoNinigaya";
            Console.WriteLine("Hello World from BASS.NET Library!!!");
            BASS bass = new BASS();
            if(bass.Init_Bass(-1, 48000, 0, 0, 0))
            {
                Console.WriteLine("Initializated Successfully");
                if (bass.START())
                {
                    Console.WriteLine("STARTED!!!");
                    UInt32 str = bass.CreateBASS_FileStream(0, Utf16ToUtf8("SixFeetUnderground.mp3"), 0, 0, 0x4);
                    if(str == 0)
                    {
                        Console.WriteLine("BASS.DLL IS FAILED TO CREATING FILE STREAM!!!");
                        Environment.Exit(323);
                    }
                    bass.ChannelPlay(str, false);
                    console.WaitForClose();
                }
            }
        }
    }
}
