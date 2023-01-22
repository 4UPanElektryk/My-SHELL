using System.Collections.Generic;
using CoolConsole;
using CoolConsole.MenuItems;
using MyShell.Essentials;
using MyShell.Integrations.User_Manager;

namespace MyShell.Commands.SubCmds.Config
{
    public class CmdConfig_Menu : SubCmd
    {
        public CmdConfig_Menu(string name) : base(name)
        {

        }
        public override bool Execute(string[] args, string input, User user)
        {
            bool save = false;
            AppConfig appConfig = Essentials.Config._AppConfig;
            UserConfig userConfig = Essentials.Config._UserConfig;
            LogsConfig logsConfig = Essentials.Config._LogsConfig;
            bool loop = true;
            do
            {
                List<MenuItem> menus = new List<MenuItem>
                {
                    new MenuItem("App Config"),
                    new MenuItem("User Manager Config"),
                    new MenuItem("Logs Config"),
                    new MenuItem("Save & Exit"),
                    new MenuItem("Exit Without Saving"),
                };
                ReturnCode returnCode = Menu.Show(menus);
                if (returnCode.SelectedMenuItem > 2){ loop = false; }
                if (returnCode.SelectedMenuItem == 0){ appConfig = GetAppConfig(appConfig); }
                if (returnCode.SelectedMenuItem == 1){ userConfig = GetUserManagerConfig(userConfig); }
                if (returnCode.SelectedMenuItem == 2){ logsConfig = GetLogsConfig(logsConfig); }
                save = returnCode.SelectedMenuItem == 3;
            } while (loop);
            if (save)
            {
                Essentials.Config._AppConfig = appConfig;
                Essentials.Config._UserConfig = userConfig;
                Essentials.Config._LogsConfig = logsConfig;
                Essentials.Config.Save();
            }
            return true;
        }

        public UserConfig GetUserManagerConfig(UserConfig user)
        {
            List<MenuItem> items = new List<MenuItem>
            {
                new TextboxMenuItem("File",user.File),
                new TextboxMenuItem("File_Backup",user.FileBackup),
                new MenuItem("Continue")
            };
            ReturnCode returnCode = Menu.Show(items);
            user.File = returnCode.Textboxes[0]._Value;
            user.FileBackup = returnCode.Textboxes[1]._Value;
            return user;
        }
        public AppConfig GetAppConfig(AppConfig app)
        {
            List<MenuItem> items = new List<MenuItem>
            {
                new CheckboxMenuItem("AutoUpdate",app.AutoUpdate),
                new CheckboxMenuItem("UpdateToBeta",app.UpdateToBeta),
                new CheckboxMenuItem("DevMode",app.DevMode),
                new CheckboxMenuItem("UseASCIIOnly",app.UseAsciiOnly),
                new TextboxMenuItem("Binds_Database_File",app.BindFile),
                new MenuItem("Continue")
            };
            ReturnCode returnCode = Menu.Show(items);
            app.AutoUpdate = returnCode.Checkboxes[0]._Value;
            app.UpdateToBeta = returnCode.Checkboxes[1]._Value;
            app.DevMode = returnCode.Checkboxes[2]._Value;
            app.UseAsciiOnly = returnCode.Checkboxes[3]._Value;
            app.BindFile = returnCode.Textboxes[0]._Value;
            return app;
        }
        public LogsConfig GetLogsConfig(LogsConfig logs)
        {
            List<MenuItem> items = new List<MenuItem>
            {
                new TextboxMenuItem("Prefix",logs.Prefix),
                new TextboxMenuItem("Path",logs.Path),
                new CheckboxMenuItem("Enabled",logs.Enabled),
                new MenuItem("Continue")
            };
            ReturnCode returnCode = Menu.Show(items);
            logs.Prefix = returnCode.Textboxes[0]._Value;
            logs.Path = returnCode.Textboxes[1]._Value;
            logs.Enabled = returnCode.Checkboxes[0]._Value;
            return logs;
        }
    }
}
