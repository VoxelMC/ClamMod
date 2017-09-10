using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClamMod.Items.Materials
{
	public class CactiteBar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cactite Bar");
			Tooltip.SetDefault("A bar forged of cactus and iron?");	//The (English) text shown below your weapon's name
		}
		
		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 34;
			item.maxStack = 999;
			item.value = 450;
			item.rare = 0;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Cactus, 4);
            recipe.AddIngredient(ItemID.IronBar, 1);
            recipe.anyIronBar = true;
            recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}