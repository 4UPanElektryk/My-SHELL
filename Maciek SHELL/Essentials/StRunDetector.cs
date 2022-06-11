using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MShell.Integrations.User_Manager;

namespace MShell.Essentials
{
    public class StRunDetector
    {
        public static bool Is1stRun()
        {
            if (File.Exists(Config.path))
            {
                Config.Load();
            }
            else
            {
                if (File.Exists(Config._UserConfig.File) || File.Exists(Config._UserConfig.FileBackup))
                {
                    new UserController(Config._UserConfig.File, Config._UserConfig.FileBackup);
                }
                
            }
            return false;
        }
    }
}
