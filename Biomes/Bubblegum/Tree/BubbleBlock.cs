using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Logicalty.Biomes.Bubblegum.Tree
{
	public class BubbleBlock : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			//Main.tileMerge[Type][mod.TileType("TremorTree")] = true;
			Main.tileMerge[Type][249] = true;
			Main.tileMerge[Type][161] = true;
			Main.tileMerge[Type][162] = true;
			Main.tileMerge[Type][163] = true;
			Main.tileMerge[Type][164] = true;
			Main.tileMerge[Type][147] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = false;
			//Main.tileMinPick[Type] = 200;
			dustType = 80;
			soundType = 21;
			soundStyle = 2;
			Main.tileLighted[Type] = true;
			AddMapEntry(new Color(104, 155, 195));
			SetModTree(new BubbleTree());
			drop = ItemID.BubblegumBlock;
		}

		public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
		{
			Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
			Tile tile = Main.tile[i, j];
			int height = tile.frameY == 36 ? 18 : 16;
			int animate = 0;
			if (tile.frameY >= 56)
			{
				animate = Main.tileFrame[Type] * animationFrameHeight;
			}
			Texture2D texture = Main.tileTexture[Type];
			Main.spriteBatch.Draw(texture, new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.frameX, tile.frameY + animate, 16, height), Lighting.GetColor(i, j), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
			return false;
		}
		public override void RandomUpdate(int i, int j)
		{
			if (Main.tile[i - 1, j].type == TileID.BubblegumBlock && CanGrow(i - 1, j))
			{
				Main.tile[i - 1, j].type = (ushort)mod.TileType("BubbleBlock");
			}
			if (Main.tile[i + 1, j].type == TileID.BubblegumBlock && CanGrow(i + 1, j))
			{
				Main.tile[i + 1, j].type = (ushort)mod.TileType("BubbleBlock");
			}
		}

		public bool CanGrow(int i, int j)
		{
			bool flag = false;
			for (int x = 0; x < 3; x++)
				for (int y = 0; y < 3; y++)
				{
					if (!Main.tile[i - 1 + x, j - 1 + y].active())
						flag = true;
				}
			return flag;
		}

		public override int SaplingGrowthType(ref int style)
		{
			style = 0;
			return mod.TileType("BubbleSapling");
		}
	}
}