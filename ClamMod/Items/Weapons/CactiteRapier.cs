using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClamMod.Items.Weapons
{
	public class CactiteRapier : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cactite Rapier");
			Tooltip.SetDefault("A rapid Blade made out of Cactus and Iron.");	//The (English) text shown below your weapon's name
		}
		
		public override void SetDefaults()
		{
			item.damage = 7;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 1;
			item.knockBack = 2;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
            item.autoReuse = false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("CactiteBar"), 7);
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}