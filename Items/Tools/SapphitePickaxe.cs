using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClamMod.Items.Tools
{
	public class SapphitePickaxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Mining with a crystal?");
			DisplayName.SetDefault("Sapphite Pickaxe");
		}

		public override void SetDefaults()
		{
			item.damage = 12;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 24;
			item.useAnimation = 24;
			item.pick = 120;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Sapphire, 12);
			recipe.AddIngredient(ItemID.Granite, 24);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}