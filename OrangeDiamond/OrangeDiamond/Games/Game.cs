using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Common;

namespace Charlotte.Games
{
	public class Game : IDisposable
	{
		public Map Map;

		// <---- prm

		public static Game I = null;

		private Player Player = new Player();

		public Game()
		{
			I = this;
		}

		public void Dispose()
		{
			I = null;
		}

		public void Perform()
		{
			this.LoadStartPosition();
			this.Player.Direction = int.Parse(this.Map.GetProperty("START_DIRECTION"));
		}

		private void LoadStartPosition()
		{
			for (int x = 0; x < this.Map.W; x++)
			{
				for (int y = 0; y < this.Map.H; y++)
				{
					MapCell cell = this.Map[x, y];

					if (cell.Script == "START")
					{
						this.Player.X = x;
						this.Player.Y = y;
						return;
					}
				}
			}
			throw new DDError();
		}
	}
}
