using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maciek_SHELL.Essentials;
using MOS_User_Menager_Integration;

namespace Maciek_SHELL.Commands.Cmds.Nano
{
	class NanoCmd : Cmd
	{
		public NanoCmd (string name) : base (name) { }
        public override bool Execute(string[] args, string input, User user)
        {
			List<Text> texts = new List<Text>();
			bool color_formating = false;
			int k = 0, w = 0, g = 0, nbt = args.Length;
			bool action = true;
			string path;
			if (nbt > 1)
			{
				path = Dual.TrimStart(input, args[0] + " ");
			}
			else
			{
				Console.Write("Path: ");
				path = Console.ReadLine();
			}
			if (path.Contains(':'))
			{

			}
			else
			{
				path = LoggedProgram.DIR + path;
			}
			if (File.Exists(path))
			{
				string[] file = File.ReadAllLines(path);
				if (file[0] == "#color_formating_enabled")
				{
					foreach (string item in file)
					{
						if (k != 0)
						{
							string[] jhj = item.Split('#');
							string jh = jhj[0] + "#" + jhj[1] + "#";
							string t = Dual.TrimStart(item, jh);
							Text jjjtext = new Text(k - 1, t);
							jjjtext.Color = Dual.IntToColor(int.Parse(jhj[0]));
							jjjtext.BGColor = Dual.IntToColor(int.Parse(jhj[1]));
							texts.Add(jjjtext);
						}
						k++;
					}
					color_formating = true;
				}
				else
				{
					foreach (string item in file)
					{
						texts.Add(new Text(k, item));
						k++;
					}
					color_formating = false;
				}
				k--;
			}
			bool loop = true;
			w = k;
			do
			{
				Console.Clear();
				Dual.NanoWatermark();

				foreach (Text item in texts)
				{
					if (item.N.ToString().Length > g)
					{
						g = item.N.ToString().Length;
					}
				}
				int lw = 0;
				bool c = true;
				do
				{
					foreach (Text item in texts)
					{
						if (lw == item.N)
						{
							Console.Write(item.N + ".");
							for (int i = 0; i <= g; i++)
							{
								Console.Write(" ");
							}
							Console.ForegroundColor = item.Color;
							Console.BackgroundColor = item.BGColor;
							Console.WriteLine(item.S);
							Console.ForegroundColor = ConsoleColor.White;
							Console.BackgroundColor = ConsoleColor.Black;
						}
					}
					if (lw == w)
					{
						c = false;
					}
					lw++;
				} while (c);
				Console.Write(">");
				string dt = Console.ReadLine();
				string linput = dt.ToLower();
				string[] TInput = linput.Split(' ');
				int mnbt = TInput.Length;
				switch (TInput[0])
				{
					case "colorformating":
					case "cf":
						if (mnbt == 2)
						{
							if (TInput[1] == "-on")
							{
								color_formating = true;
							}
							if (TInput[1] == "-off")
							{
								color_formating = false;
							}
						}
						if (mnbt == 1)
						{
							if (color_formating)
							{
								Console.WriteLine("Color foramting is enabled");
							}
							else
							{
								Console.WriteLine("Color foramting is disabled");
							}
						}
						break;

					case "writeline":
					case "wl":
						string h = Console.ReadLine();
						texts.Add(new Text(w, h));
						w++;
						break;

					case "color":
					case "c":
						if (mnbt == 4)
						{
							if (int.TryParse(TInput[1], out int id))
							{
								if (int.TryParse(TInput[2], out int color1))
								{
									if (int.TryParse(TInput[3], out int color2))
									{
										Text Htext = null;
										bool nfail = false;
										foreach (Text item in texts)
										{
											if (item.N == id)
											{
												Htext = item;
												nfail = true;
											}
										}
										if (nfail)
										{
											texts.Remove(Htext);
											Htext.Color = Dual.IntToColor(color1);
											Htext.BGColor = Dual.IntToColor(color2);
											texts.Add(Htext);
										}
									}
								}
							}
						}
						break;

					case "palete":
					case "p":
						for (int i = 0; i < 16; i++)
						{
							if (i == 0)
							{
								Console.BackgroundColor = Dual.IntToColor(15);
								Console.ForegroundColor = Dual.IntToColor(i);
								Console.Write(i + " Tset ");
							}
							else
							{
								Console.BackgroundColor = Dual.IntToColor(0);
								Console.ForegroundColor = Dual.IntToColor(i);
								Console.Write(i + " Tset ");
							}

						}
						Console.WriteLine();
						for (int i = 0; i < 16; i++)
						{
							if (i > 0)
							{
								Console.ForegroundColor = Dual.IntToColor(0);
							}
							Console.BackgroundColor = Dual.IntToColor(i);
							Console.Write(i + " Tset ");
						}
						Console.BackgroundColor = Dual.IntToColor(0);
						Console.ForegroundColor = Dual.IntToColor(15);
						Console.WriteLine();
						Console.ReadLine();
						break;

					case "changeline":
					case "cl":
						if (mnbt == 2)
						{
							if (int.TryParse(TInput[1], out int f))
							{
								Text text = null;
								foreach (Text item in texts)
								{

									if (item.N == f)
									{
										text = item;
									}
								}
								texts.Remove(text);
								Console.WriteLine(text.S);
								text.S = Console.ReadLine();

								texts.Add(text);
							}
						}
						break;

					case "deleteline":
					case "dl":
						if (mnbt == 2)
						{
							if (int.TryParse(TInput[1], out int xf))
							{
								Text ktext = null;
								foreach (Text item in texts)
								{
									if (item.N == xf)
									{
										ktext = item;
									}
								}
								texts.Remove(ktext);
								List<Text> listd = new List<Text>();
								foreach (Text item in texts)
								{
									if (item.N > ktext.N)
									{
										listd.Add(item);
									}
								}
								foreach (Text item in listd)
								{
									texts.Remove(item);
									Text text2 = item;
									text2.N = item.N - 1;
									texts.Add(text2);
								}
								w--;
							}
						}
						break;

					case "save":
					case "s":
						if (color_formating)
						{
							string[] vls = new string[texts.Count + 1];
							int ggg = 1;
							bool m = true;
							vls[0] = "#color_formating_enabled";
							do
							{
								foreach (Text item in texts)
								{
									if (ggg - 1 == item.N)
									{
										vls[ggg] = Dual.ColorToInt(item.Color) + "#" + Dual.ColorToInt(item.BGColor) + "#" + item.S;
									}
								}
								if (ggg == w)
								{
									m = false;
								}
								ggg++;
							} while (m);
							if (File.Exists(path))
							{
								Console.ForegroundColor = ConsoleColor.Yellow;
								Console.Write("File already exis do you want to repalce it? Y | N >>");
								ConsoleKey Keyj = Console.ReadKey().Key;
								if (Keyj == ConsoleKey.Y)
								{
									Console.WriteLine("");
									File.Delete(path);
									File.WriteAllLines(path, vls, Encoding.UTF8);
								}
								else
								{
									Console.WriteLine("");
								}
							}
							else
							{
								File.WriteAllLines(path, vls, Encoding.UTF8);
							}
						}
						else
						{
							string[] vls = new string[texts.Count];
							int ggg = 0;
							bool m = true;
							do
							{
								foreach (Text item in texts)
								{
									if (ggg == item.N)
									{
										vls[ggg] = item.S;
									}
								}
								if (ggg == w)
								{
									m = false;
								}
								ggg++;
							} while (m);
							if (File.Exists(path))
							{
								Console.ForegroundColor = ConsoleColor.Yellow;
								Console.Write("File already exis do you want to repalce it? Y | N >>");
								ConsoleKey Keyj = Console.ReadKey().Key;
								if (Keyj == ConsoleKey.Y)
								{
									Console.WriteLine("");
									File.Delete(path);
									File.WriteAllLines(path, vls, Encoding.UTF8);
								}
								else
								{
									Console.WriteLine("");
								}
							}
							else
							{
								File.WriteAllLines(path, vls, Encoding.UTF8);
							}
						}
						break;

					case "saveas":
					case "sa":
						Console.WriteLine("Path:");
						path = Console.ReadLine();
						goto case "save";

					case "exit":
					case "e":
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.Write("Are you sure you want to exit? Y | N >>");
						ConsoleKey Key = Console.ReadKey().Key;
						if (Key == ConsoleKey.Y)
						{
							Console.WriteLine("");
							loop = false;
						}
						else
						{
							Console.WriteLine("");
						}
						break;

					case "help":
					case "?":
						string[] gtext = {
							"Commands:",
							"Write Line    | wl",
							"Change Line   | cl [lineNumber]",
							"Delete Line   | dl [lineNumber]",
							"Color         | c [lineNumber] [colorNumber] [backgorundColorNumber]",
							"Save          | s",
							"Save As       | sa",
							"Exit          | e",
							"Color Palette | p"
						};
						Dual.ShowMsg(gtext, ConsoleColor.White, ConsoleColor.Blue);
						Console.ReadLine();

						break;

					default:
						break;
				}
			} while (loop);
			Console.Clear();
			Dual.Watermark();
			return action;
		}
	}
}
