using System.Collections.Generic;
using CoolConsole;
using CoolConsole.MenuItems;
using MyShell.Essentials;

namespace MyShell.Commands.SubCmds.CConfig
{
    public class CmdConfig_Menu : SubCmd
    {
        public CmdConfig_Menu(string name) : base(name)
        {

        }
        public override bool Execute(string[] args, string input)
        {
            bool save = false;
            AppConfig appConfig = Essentials.Config._AppConfig;
            LogsConfig logsConfig = Essentials.Config._LogsConfig;
            bool loop = true;
            do
            {
                List<MenuItem> menus = new List<MenuItem>
                {
                    new MenuItem("App Config"),
                    new MenuItem("Logs Config"),
                    new MenuItem("Save & Exit"),
                    new MenuItem("Exit Without Saving"),
                };
                ReturnCode returnCode = Menu.Show(menus);
                if (returnCode.SelectedMenuItem > 2){ loop = false; }
                if (returnCode.SelectedMenuItem == 0){ appConfig = GetAppConfig(appConfig); }
                if (returnCode.SelectedMenuItem == 2){ logsConfig = GetLogsConfig(logsConfig); }
                save = returnCode.SelectedMenuItem == 3;
            } while (loop);
            if (save)
            {
                Essentials.Config._AppConfig = appConfig;
                Essentials.Config._LogsConfig = logsConfig;
                Essentials.Config.Save();
            }
            return true;
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
            app.AutoUpdate = returnCode.Checkboxes[0];
            app.UpdateToBeta = returnCode.Checkboxes[1];
            app.DevMode = returnCode.Checkboxes[2];
            app.UseAsciiOnly = returnCode.Checkboxes[3];
            app.BindFile = returnCode.Textboxes[0];
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
            logs.Prefix = returnCode.Textboxes[0];
            logs.Path = returnCode.Textboxes[1];
            logs.Enabled = returnCode.Checkboxes[0];
            return logs;
        }
    }
}
