using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Charlotte.Games
{
	public class MapCell
	{
		public Wall_e Wall_2 = Wall_e.NONE; // 南側
		public Wall_e Wall_4 = Wall_e.NONE; // 西側
		public Wall_e Wall_6 = Wall_e.NONE; // 東側
		public Wall_e Wall_8 = Wall_e.NONE; // 北側

		public string Structure = null; // null == 構造物無し

		// <---- prm

		public enum Wall_e
		{
			NONE = 1,
			WALL,
			GATE,
		}
	}
}
