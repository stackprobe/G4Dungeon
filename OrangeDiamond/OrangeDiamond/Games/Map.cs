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

			this.DefaultCell_4.Wall_6.Kind = MapWall.Kind_e.WALL;
			this.DefaultCell_6.Wall_4.Kind = MapWall.Kind_e.WALL;
			this.DefaultCell_8.Wall_2.Kind = MapWall.Kind_e.WALL;
			this.DefaultCell_2.Wall_8.Kind = MapWall.Kind_e.WALL;
		}

		private MapCell DefaultCell = new MapCell();
		private MapCell DefaultCell_4 = new MapCell();
		private MapCell DefaultCell_6 = new MapCell();
		private MapCell DefaultCell_8 = new MapCell();
		private MapCell DefaultCell_2 = new MapCell();

		public MapCell this[int x, int y]
		{
			get
			{
				if (
					x < 0 || this.W <= x ||
					y < 0 || this.H <= y
					)
				{
					if (0 <= y && y < this.H)
					{
						if (x == -1)
							return this.DefaultCell_4;

						if (x == this.W)
							return this.DefaultCell_6;
					}
					if (0 <= x && x < this.W)
					{
						if (y == -1)
							return this.DefaultCell_8;

						if (y == this.H)
							return this.DefaultCell_2;
					}
					return this.DefaultCell;
				}
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
