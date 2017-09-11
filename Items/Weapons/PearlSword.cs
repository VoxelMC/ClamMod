using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClamMod.Items.Weapons
{
	public class PearlSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pearl Sword");
			Tooltip.SetDefault("A Sword made out of pearls.");	//The (English) text shown below your weapon's name
		}
		
		public override void SetDefaults()
		{
			item.damage = 14;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 26;
			item.useAnimation = 26;
			item.useStyle = 1;
			item.knockBack = 4;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
            item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("PearlMaterial"), 20);
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}