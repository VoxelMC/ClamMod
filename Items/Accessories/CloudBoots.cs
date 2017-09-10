using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ClamMod.Items.Accessories
{
    public class CloudBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cloud Boots");
            Tooltip.SetDefault("Walk Blazing Fast on Air");
        }

        public override void SetDefaults()
        {
            item.width = 42;
            item.height = 42;
            item.value = 1000000;
            item.rare = 10;
            item.accessory = true;
            item.defense = 0;
			item.UseSound = SoundID.DD2_BetsyWindAttack;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
				player.moveSpeed += 30;
				player.GetModPlayer<MyPlayer>(mod).CloudBoots = true;
				player.carpet = true;
        }
		

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RocketBoots, 1);
            recipe.AddIngredient(ItemID.Cloud,100);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
