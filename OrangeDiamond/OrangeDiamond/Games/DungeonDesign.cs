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
		public const int DUNG_SCREEN_W = 1440;
		public const int DUNG_SCREEN_H = 530;

		public static readonly D4Rect FRONT_WALL_0 = new D4Rect(30 * 0, 24 * 0, DUNG_SCREEN_W - (30 + 30) * 0, DUNG_SCREEN_H - (24 + 8) * 0);
		public static readonly D4Rect FRONT_WALL_1 = new D4Rect(30 * 8, 24 * 8, DUNG_SCREEN_W - (30 + 30) * 8, DUNG_SCREEN_H - (24 + 8) * 8);
		public static readonly D4Rect FRONT_WALL_2 = new D4Rect(30 * 12, 24 * 12, DUNG_SCREEN_W - (30 + 30) * 12, DUNG_SCREEN_H - (24 + 8) * 12);
		public static readonly D4Rect FRONT_WALL_3 = new D4Rect(30 * 14, 24 * 14, DUNG_SCREEN_W - (30 + 30) * 14, DUNG_SCREEN_H - (24 + 8) * 14);
		public static readonly D4Rect FRONT_WALL_4 = new D4Rect(30 * 15, 24 * 15, DUNG_SCREEN_W - (30 + 30) * 15, DUNG_SCREEN_H - (24 + 8) * 15);

		public static readonly D4Rect WALK_FRONT_WALL_0 = new D4Rect(30 * -8, 24 * -8, DUNG_SCREEN_W - (30 + 30) * -16, DUNG_SCREEN_H - (24 + 8) * -8);
		public static readonly D4Rect WALK_FRONT_WALL_1 = new D4Rect(30 * 4, 24 * 4, DUNG_SCREEN_W - (30 + 30) * 4, DUNG_SCREEN_H - (24 + 8) * 4);
		public static readonly D4Rect WALK_FRONT_WALL_2 = new D4Rect(30 * 10, 24 * 10, DUNG_SCREEN_W - (30 + 30) * 10, DUNG_SCREEN_H - (24 + 8) * 10);
		public static readonly D4Rect WALK_FRONT_WALL_3 = new D4Rect(30 * 13, 24 * 13, DUNG_SCREEN_W - (30 + 30) * 13, DUNG_SCREEN_H - (24 + 8) * 13);
		public static readonly D4Rect WALK_FRONT_WALL_4 = new D4Rect(30 * 14.5, 24 * 14.5, DUNG_SCREEN_W - (30 + 30) * 14.5, DUNG_SCREEN_H - (24 + 8) * 14.5);

		// LeftTurning_(Front 0 ～ 3 | Left 1 ～ 3)_(Front | Left)

		public static readonly P4Poly LT_F0_F = new P4Poly(
			DUNG_SCREEN_W / 2 + 120 * 0, 24 * 8,
			DUNG_SCREEN_W / 2 + 120 * 6, 24 * 0,
			DUNG_SCREEN_W / 2 + 120 * 6, DUNG_SCREEN_H - (24 + 8) * 0,
			DUNG_SCREEN_W / 2 + 120 * 0, DUNG_SCREEN_H - (24 + 8) * 8
			);
		public static readonly P4Poly LT_F0_L = new P4Poly(
			DUNG_SCREEN_W / 2 + 120 * -6, 24 * 0,
			DUNG_SCREEN_W / 2 + 120 * 0, 24 * 8,
			DUNG_SCREEN_W / 2 + 120 * 0, DUNG_SCREEN_H - (24 + 8) * 8,
			DUNG_SCREEN_W / 2 + 120 * -6, DUNG_SCREEN_H - (24 + 8) * 0
			);
		public static readonly P4Poly LT_F1_F = new P4Poly(
			DUNG_SCREEN_W / 2 + 120 * 3, 24 * 12,
			DUNG_SCREEN_W / 2 + 120 * 6, 24 * 8,
			DUNG_SCREEN_W / 2 + 120 * 6, DUNG_SCREEN_H - (24 + 8) * 8,
			DUNG_SCREEN_W / 2 + 120 * 3, DUNG_SCREEN_H - (24 + 8) * 12
			);
		public static readonly P4Poly LT_F1_L = new P4Poly(
			DUNG_SCREEN_W / 2 + 120 * 0, 24 * 8,
			DUNG_SCREEN_W / 2 + 120 * 3, 24 * 12,
			DUNG_SCREEN_W / 2 + 120 * 3, DUNG_SCREEN_H - (24 + 8) * 12,
			DUNG_SCREEN_W / 2 + 120 * 0, DUNG_SCREEN_H - (24 + 8) * 8
			);
		public static readonly P4Poly LT_F2_F = new P4Poly(
			DUNG_SCREEN_W / 2 + 120 * 5, 24 * 14,
			DUNG_SCREEN_W / 2 + 120 * 7, 24 * 12,
			DUNG_SCREEN_W / 2 + 120 * 7, DUNG_SCREEN_H - (24 + 8) * 12,
			DUNG_SCREEN_W / 2 + 120 * 5, DUNG_SCREEN_H - (24 + 8) * 14
			);
		public static readonly P4Poly LT_F2_L = new P4Poly(
			DUNG_SCREEN_W / 2 + 120 * 3, 24 * 12,
			DUNG_SCREEN_W / 2 + 120 * 5, 24 * 14,
			DUNG_SCREEN_W / 2 + 120 * 5, DUNG_SCREEN_H - (24 + 8) * 14,
			DUNG_SCREEN_W / 2 + 120 * 3, DUNG_SCREEN_H - (24 + 8) * 12
			);
		public static readonly P4Poly LT_F3_L = new P4Poly(
			DUNG_SCREEN_W / 2 + 120 * 5, 24 * 14,
			DUNG_SCREEN_W / 2 + 120 * 6, 24 * 15,
			DUNG_SCREEN_W / 2 + 120 * 6, DUNG_SCREEN_H - (24 + 8) * 15,
			DUNG_SCREEN_W / 2 + 120 * 5, DUNG_SCREEN_H - (24 + 8) * 14
			);
		public static readonly P4Poly LT_L1_F = new P4Poly(
			DUNG_SCREEN_W / 2 + 120 * -3, 24 * 12,
			DUNG_SCREEN_W / 2 + 120 * 0, 24 * 8,
			DUNG_SCREEN_W / 2 + 120 * 0, DUNG_SCREEN_H - (24 + 8) * 8,
			DUNG_SCREEN_W / 2 + 120 * -3, DUNG_SCREEN_H - (24 + 8) * 12
			);
		public static readonly P4Poly LT_L1_L = new P4Poly(
			DUNG_SCREEN_W / 2 + 120 * -6, 24 * 8,
			DUNG_SCREEN_W / 2 + 120 * -3, 24 * 12,
			DUNG_SCREEN_W / 2 + 120 * -3, DUNG_SCREEN_H - (24 + 8) * 12,
			DUNG_SCREEN_W / 2 + 120 * -6, DUNG_SCREEN_H - (24 + 8) * 8
			);
		public static readonly P4Poly LT_L2_F = new P4Poly(
			DUNG_SCREEN_W / 2 + 120 * -5, 24 * 14,
			DUNG_SCREEN_W / 2 + 120 * -3, 24 * 12,
			DUNG_SCREEN_W / 2 + 120 * -3, DUNG_SCREEN_H - (24 + 8) * 12,
			DUNG_SCREEN_W / 2 + 120 * -5, DUNG_SCREEN_H - (24 + 8) * 14
			);
		public static readonly P4Poly LT_L2_L = new P4Poly(
			DUNG_SCREEN_W / 2 + 120 * -7, 24 * 12,
			DUNG_SCREEN_W / 2 + 120 * -5, 24 * 14,
			DUNG_SCREEN_W / 2 + 120 * -5, DUNG_SCREEN_H - (24 + 8) * 14,
			DUNG_SCREEN_W / 2 + 120 * -7, DUNG_SCREEN_H - (24 + 8) * 12
			);
		public static readonly P4Poly LT_L3_F = new P4Poly(
			DUNG_SCREEN_W / 2 + 120 * -6, 24 * 15,
			DUNG_SCREEN_W / 2 + 120 * -5, 24 * 14,
			DUNG_SCREEN_W / 2 + 120 * -5, DUNG_SCREEN_H - (24 + 8) * 14,
			DUNG_SCREEN_W / 2 + 120 * -6, DUNG_SCREEN_H - (24 + 8) * 15
			);
	}
}
