
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ClamMod.Tiles
{
    public class DreamOre : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            drop = mod.ItemType("DreamOre");
            AddMapEntry(new Color(255, 192, 203));
            mineResist = 15f;
            minPick = 100;
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 1.3f;
            g = 0.1f;
            b = 0.2f;
        }
        public override bool CanExplode(int i, int j)
        {
            if (Main.tile[i, j].type == mod.TileType("DreamOre"))
            {
                return false;
            }
            return false;
        }

    }
}