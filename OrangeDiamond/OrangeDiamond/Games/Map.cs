using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Tools;
using Charlotte.Common;

namespace Charlotte.Games
{
	public class Map
	{
		private MapCell[] Cells;

		public int W;
		public int H;

		public Map(int w, int h)
		{
			if (
				w < 1 || IntTools.IMAX < w ||
				h < 1 || IntTools.IMAX < h
				)
				throw new DDError();

			this.Cells = new MapCell[w * h];

			for (int index = 0; index < this.Cells.Length; index++)
				this.Cells[index] = new MapCell();

			this.W = w;
			this.H = h;
		}

		public MapCell this[int x, int y]
		{
			get
			{
				return this.Cells[x + y * this.W];
			}
		}

		private Dictionary<string, string> Properties = DictionaryTools.Create<string>();

		public void AddProperty(string name, string value)
		{
			this.Properties.Add(name, value);
		}
	}
}
