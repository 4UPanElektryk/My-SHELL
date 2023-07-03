namespace MyShell.Essentials
{
    public class AppConfig
    {
        public bool AutoUpdate { get; set; }
        public bool UpdateToBeta { get; set; }
        public bool DevMode { get; set; }
        public bool UseAsciiOnly { get; set; }
        public string BindFile { get; set; }
        public void Reset()
        {
            AutoUpdate = true;
            UpdateToBeta = false;
            DevMode = false;
            UseAsciiOnly = false;
            BindFile = "binds.json";
        }
        public AppConfig()
        {

        }
    }
    public class LogsConfig
    {
        public string Prefix { get; set; }
        public string Path { get; set; }
        public bool Enabled { get; set; }
        public void Reset()
        {
            Prefix = "LOG";
            Path = "Logs\\";
            Enabled = true;
        }
        public LogsConfig()
        {

        }
    }
}
