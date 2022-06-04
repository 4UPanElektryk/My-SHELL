using SimpleLogs4Net;
using System;
using System.IO;
using System.Net;

namespace Maciek_SHELL.Essentials
{
	public class Activation
	{
		public static string[] GetLicense()
		{
			try
			{
				WebClient webClient = new WebClient();
				if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "Licensing.tmp"))
				{
					webClient.DownloadFile(new Uri("http://techm.ugu.pl/Licensing.tmp"), AppDomain.CurrentDomain.BaseDirectory + "Licensing.tmp");
				}
				string[] file = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "Licensing.tmp");
				File.Delete(AppDomain.CurrentDomain.BaseDirectory + "Licensing.tmp");
				Log.AddEvent(new Event("Licensing - Activation: Succes", Event.Type.Informtion, DateTime.Now));
				return file;
			}
			catch
			{
				Log.AddEvent(new Event("Licensing - Licensing Failed: Connection Fail", Event.Type.Error, DateTime.Now));
				throw new Exception("Licensing Failed: Connection Fail");
			}
		}
		public static bool CheckLicense()
		{
			try
			{
				string License = "";
				string[] data = GetLicense();
				bool active = false;
				foreach (string item in data)
				{
					string[] xdata = item.Split('=');
					string args = xdata[1];
					switch (xdata[0])
					{
						case "MCOSCore4.3.License":
							License = args;
							break;
						default:
							break;
					}
					active = bool.Parse(xdata[2]);
				}
				if (Config.AppLicense == License && active)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch
			{
				return false;
			}
		}
	}
}
