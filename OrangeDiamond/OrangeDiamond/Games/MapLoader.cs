using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Tools;
using Charlotte.Common;
using System.Text.RegularExpressions;
using System.IO;

namespace Charlotte.Games
{
	public static class MapLoader
	{
		public static Map Load(string file)
		{
			file = Path.Combine("Map", file);

			string[] lines = FileTools.TextToLines(StringTools.ENCODING_SJIS.GetString(DDResource.Load(file)));
			int c = 0;

			string[] mapLines;

			{
				List<string> dest = new List<string>();

				while (c < lines.Length)
				{
					string line = lines[c++];

					if (line == "")
						break;

					dest.Add(line);
				}
				mapLines = dest.ToArray();
			}

			Dictionary<string, string> mapDefines = DictionaryTools.Create<string>();

			while (c < lines.Length)
			{
				string line = lines[c++];

				if (line == "")
					break;

				var tokens = line.Split("=".ToArray(), 2);

				string name = tokens[0].Trim();
				string value = tokens[1].Trim();

				if (name == "") throw new DDError();
				if (value == "") throw new DDError();

				mapDefines.Add(name, value);
			}

			Map map = Load(mapLines, mapDefines);

			while (c < lines.Length)
			{
				var tokens = lines[c++].Split("=".ToArray(), 2);

				string name = tokens[0].Trim();
				string value = tokens[1].Trim();

				if (name == "") throw new DDError();
				if (value == "") throw new DDError();

				map.AddProperty(name, value);
			}
			return map;
		}

		private static Map Load(string[] mapLines, Dictionary<string, string> mapDefines)
		{
			if (mapLines.Length < 3)
				throw new DDError();

			if (mapLines.Length % 2 != 1)
				throw new DDError();

			if (mapLines.Select(line => line.Length).Distinct().Count() != 1)
				throw new DDError();

			for (int y = 0; y < mapLines.Length; y++)
			{
				string mapLine = mapLines[y];

				if (y == 0 || y == mapLines.Length - 1)
				{
					if (Regex.IsMatch(mapLine, @"^\+(--\+)+$") == false)
						throw new DDError();
				}
				else if (y % 2 == 0)
				{
					if (Regex.IsMatch(mapLine, @"^\+((  |--|G-)\+)+$") == false)
						throw new DDError();
				}
				else
				{
					if (Regex.IsMatch(mapLine, @"^\|((  |[0-9A-Za-z]{2})[ \|G])+$") == false || mapLine.EndsWith("|") == false)
						throw new DDError();
				}
			}
			int w = mapLines[0].Length / 3;
			int h = mapLines.Length / 2;

			Map map = new Map(w, h);

			for (int x = 0; x < w; x++)
			{
				for (int y = 0; y < h; y++)
				{
					string s8 = mapLines[y * 2 + 0].Substring(x * 3 + 1, 2);
					string s5 = mapLines[y * 2 + 1].Substring(x * 3 + 1, 2);
					string s2 = mapLines[y * 2 + 2].Substring(x * 3 + 1, 2);
					string s4 = mapLines[y * 2 + 1].Substring(x * 3 + 0, 1);
					string s6 = mapLines[y * 2 + 1].Substring(x * 3 + 3, 1);

					MapCell cell = map[x, y];

					cell.Wall_8 = GetWall_NS(s8);
					cell.Wall_2 = GetWall_NS(s2);
					cell.Wall_4 = GetWall_WE(s4);
					cell.Wall_6 = GetWall_WE(s6);

					if (s5 == "  ")
					{
						cell.Structure = null;
					}
					else
					{
						cell.Structure = mapDefines[s5];
					}
				}
			}
			return map;
		}

		private static MapCell.Wall_e GetWall_NS(string s)
		{
			switch (s)
			{
				case "  ": return MapCell.Wall_e.NONE;
				case "--": return MapCell.Wall_e.WALL;
				case "G-": return MapCell.Wall_e.GATE;

				default:
					throw null; // never
			}
		}

		private static MapCell.Wall_e GetWall_WE(string s)
		{
			switch (s)
			{
				case " ": return MapCell.Wall_e.NONE;
				case "|": return MapCell.Wall_e.WALL;
				case "G": return MapCell.Wall_e.GATE;

				default:
					throw null; // never
			}
		}
	}
}
