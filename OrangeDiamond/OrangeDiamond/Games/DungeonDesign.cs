using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Common;
using Charlotte.Tools;

namespace Charlotte.Games
{
	public static class DungeonDesign
	{
		public const int DUNG_SCREEN_W = 970;
		public const int DUNG_SCREEN_H = 530;

		public static DDSubScreen DungScreen = new DDSubScreen(DUNG_SCREEN_W, DUNG_SCREEN_H);

		public static readonly D4Rect FRONT_WALL_0 = new D4Rect(30 * 0, 24 * 0, DUNG_SCREEN_W - (30 + 30) * 0, DUNG_SCREEN_H - (24 + 8) * 0);
		public static readonly D4Rect FRONT_WALL_1 = new D4Rect(30 * 1, 24 * 1, DUNG_SCREEN_W - (30 + 30) * 1, DUNG_SCREEN_H - (24 + 8) * 1);
		public static readonly D4Rect FRONT_WALL_2 = new D4Rect(30 * 3, 24 * 3, DUNG_SCREEN_W - (30 + 30) * 3, DUNG_SCREEN_H - (24 + 8) * 3);
		public static readonly D4Rect FRONT_WALL_3 = new D4Rect(30 * 7, 24 * 7, DUNG_SCREEN_W - (30 + 30) * 7, DUNG_SCREEN_H - (24 + 8) * 7);
		public static readonly D4Rect FRONT_WALL_4 = new D4Rect(30 * 15, 24 * 15, DUNG_SCREEN_W - (30 + 30) * 15, DUNG_SCREEN_H - (24 + 8) * 15);

		// LeftTurning_(Front 0 ～ 3 | Left 1 ～ 3)_(Front | Left)

		public static readonly P4Poly LT_F0_F = new P4Poly(
			DUNG_SCREEN_W / 2 + 120 * 0, 24 * 1,
			DUNG_SCREEN_W / 2 + 120 * 6, 24 * 0,
			DUNG_SCREEN_W / 2 + 120 * 6, DUNG_SCREEN_H - (24 + 8) * 0,
			DUNG_SCREEN_W / 2 + 120 * 0, DUNG_SCREEN_H - (24 + 8) * 1
			);
		public static readonly P4Poly LT_F0_L = new P4Poly(
			DUNG_SCREEN_W / 2 + 120 * -6, 24 * 0,
			DUNG_SCREEN_W / 2 + 120 * 0, 24 * 1,
			DUNG_SCREEN_W / 2 + 120 * 0, DUNG_SCREEN_H - (24 + 8) * 1,
			DUNG_SCREEN_W / 2 + 120 * -6, DUNG_SCREEN_H - (24 + 8) * 0
			);
		public static readonly P4Poly LT_F1_F = new P4Poly(
			DUNG_SCREEN_W / 2 + 120 * 3, 24 * 3,
			DUNG_SCREEN_W / 2 + 120 * 6, 24 * 1,
			DUNG_SCREEN_W / 2 + 120 * 6, DUNG_SCREEN_H - (24 + 8) * 1,
			DUNG_SCREEN_W / 2 + 120 * 3, DUNG_SCREEN_H - (24 + 8) * 3
			);
		public static readonly P4Poly LT_F1_L = new P4Poly(
			DUNG_SCREEN_W / 2 + 120 * 0, 24 * 1,
			DUNG_SCREEN_W / 2 + 120 * 3, 24 * 3,
			DUNG_SCREEN_W / 2 + 120 * 3, DUNG_SCREEN_H - (24 + 8) * 3,
			DUNG_SCREEN_W / 2 + 120 * 0, DUNG_SCREEN_H - (24 + 8) * 1
			);
		public static readonly P4Poly LT_F2_F = new P4Poly(
			DUNG_SCREEN_W / 2 + 120 * 5, 24 * 7,
			DUNG_SCREEN_W / 2 + 120 * 7, 24 * 3,
			DUNG_SCREEN_W / 2 + 120 * 7, DUNG_SCREEN_H - (24 + 8) * 3,
			DUNG_SCREEN_W / 2 + 120 * 5, DUNG_SCREEN_H - (24 + 8) * 7
			);
		public static readonly P4Poly LT_F2_L = new P4Poly(
			DUNG_SCREEN_W / 2 + 120 * 3, 24 * 3,
			DUNG_SCREEN_W / 2 + 120 * 5, 24 * 7,
			DUNG_SCREEN_W / 2 + 120 * 5, DUNG_SCREEN_H - (24 + 8) * 7,
			DUNG_SCREEN_W / 2 + 120 * 3, DUNG_SCREEN_H - (24 + 8) * 3
			);
		public static readonly P4Poly LT_F3_L = new P4Poly(
			DUNG_SCREEN_W / 2 + 120 * 5, 24 * 7,
			DUNG_SCREEN_W / 2 + 120 * 6, 24 * 15,
			DUNG_SCREEN_W / 2 + 120 * 6, DUNG_SCREEN_H - (24 + 8) * 15,
			DUNG_SCREEN_W / 2 + 120 * 5, DUNG_SCREEN_H - (24 + 8) * 7
			);
		public static readonly P4Poly LT_L1_F = new P4Poly(
			DUNG_SCREEN_W / 2 + 120 * -3, 24 * 3,
			DUNG_SCREEN_W / 2 + 120 * 0, 24 * 1,
			DUNG_SCREEN_W / 2 + 120 * 0, DUNG_SCREEN_H - (24 + 8) * 1,
			DUNG_SCREEN_W / 2 + 120 * -3, DUNG_SCREEN_H - (24 + 8) * 3
			);
		public static readonly P4Poly LT_L1_L = new P4Poly(
			DUNG_SCREEN_W / 2 + 120 * -6, 24 * 1,
			DUNG_SCREEN_W / 2 + 120 * -3, 24 * 3,
			DUNG_SCREEN_W / 2 + 120 * -3, DUNG_SCREEN_H - (24 + 8) * 3,
			DUNG_SCREEN_W / 2 + 120 * -6, DUNG_SCREEN_H - (24 + 8) * 1
			);
		public static readonly P4Poly LT_L2_F = new P4Poly(
			DUNG_SCREEN_W / 2 + 120 * -5, 24 * 7,
			DUNG_SCREEN_W / 2 + 120 * -3, 24 * 3,
			DUNG_SCREEN_W / 2 + 120 * -3, DUNG_SCREEN_H - (24 + 8) * 3,
			DUNG_SCREEN_W / 2 + 120 * -5, DUNG_SCREEN_H - (24 + 8) * 7
			);
		public static readonly P4Poly LT_L2_L = new P4Poly(
			DUNG_SCREEN_W / 2 + 120 * -7, 24 * 3,
			DUNG_SCREEN_W / 2 + 120 * -5, 24 * 7,
			DUNG_SCREEN_W / 2 + 120 * -5, DUNG_SCREEN_H - (24 + 8) * 7,
			DUNG_SCREEN_W / 2 + 120 * -7, DUNG_SCREEN_H - (24 + 8) * 3
			);
		public static readonly P4Poly LT_L3_F = new P4Poly(
			DUNG_SCREEN_W / 2 + 120 * -6, 24 * 15,
			DUNG_SCREEN_W / 2 + 120 * -5, 24 * 7,
			DUNG_SCREEN_W / 2 + 120 * -5, DUNG_SCREEN_H - (24 + 8) * 7,
			DUNG_SCREEN_W / 2 + 120 * -6, DUNG_SCREEN_H - (24 + 8) * 15
			);
	}
}
