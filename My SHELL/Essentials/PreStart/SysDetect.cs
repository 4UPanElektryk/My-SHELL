using System;
namespace MyShell.Essentials.PreStart
{
    public class SysDetect
    {
        public enum Sys
        {
            Windows,
            Unix,
            NotSupported
        }
        public static Sys Check()
        {
            OperatingSystem os = Environment.OSVersion;
            switch (os.Platform)
            {
                case PlatformID.Unix: return Sys.Unix;
                case PlatformID.Win32NT: return Sys.Windows;
                default: return Sys.NotSupported;
            }
        }
    }
}
