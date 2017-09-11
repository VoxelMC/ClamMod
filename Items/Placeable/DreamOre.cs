using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClamMod.Items.Placeable
{
    public class DreamOre : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("DreamOre");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 999;
            item.value = 700;
            item.rare = 6;
        }

    }
}