using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace Logicalty.Biomes.Bubblegum.Tree
{
	public class BubbleTree : ModTree
	{
        private Mod mod
        {
            get
            {
                return ModLoader.GetMod("Logicalty");
            }
        }

        public override int GrowthFXGore()
        {
            return mod.GetGoreSlot("Bubblegum/Tree/BubbleTreeFX");
        }

        public override int DropWood()
		{
            return mod.ItemType("AcornBlock");
		}

		public override Texture2D GetTexture()
		{
			return mod.GetTexture("Bubblegum/Tree/BubbleTree");
		}

		public override Texture2D GetBranchTextures(int i, int j, int trunkOffset, ref int frame)
		{
			return mod.GetTexture("Bubblegum/Tree/BubbleTree_Branches");
		}

        public override Texture2D GetTopTextures(int i, int j, ref int frame, ref int frameWidth, ref int frameHeight, ref int xOffsetLeft, ref int yOffset)
		{
			return mod.GetTexture("Bubblegum/Tree/BubbleTree_Tops");
		}
	}
}