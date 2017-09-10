using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ClamMod.Items.Accessories
{
    public class ClamItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Giant Clam");
            Tooltip.SetDefault("Gain the Power of the Pearl, grants quicker health when equipped.");
        }

        public override void SetDefaults()
        {
            item.width = 42;
            item.height = 42;
            item.value = 100;
            item.rare = 2;
            item.accessory = true;
            item.defense = 0;
            item.lifeRegen = 40;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
                player.lifeRegen = 6;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("PearlMaterial"), 1);
            recipe.AddIngredient(ItemID.Seashell);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
