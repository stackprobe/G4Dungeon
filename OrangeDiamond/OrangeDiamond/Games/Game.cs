using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Common;
using Charlotte.Game3Common;

namespace Charlotte.Games
{
	public class Game : IDisposable
	{
		public Map Map;

		// <---- prm

		public static Game I = null;

		private DDPicture WallPicture;
		private DDPicture GatePicture;
		private DDPicture BackgroundPicture;

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
			if (this.Map.Find(out this.Player.X, out this.Player.Y, cell => cell.Script == "START") == false)
				throw new DDError();

			this.Player.Direction = int.Parse(this.Map.GetProperty("START_DIRECTION"));

			this.WallPicture = CResource.GetPicture(this.Map.GetProperty("WALL_PICTURE"));
			this.GatePicture = CResource.GetPicture(this.Map.GetProperty("GATE_PICTURE"));
			this.BackgroundPicture = CResource.GetPicture(this.Map.GetProperty("BACKGROUND_PICTURE"));
		}
	}
}
