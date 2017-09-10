using Terraria.ID;
using Terraria.ModLoader;

namespace ClamMod.Items.Weapons
{
	public class SapphiteBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sapphite Blade");
			Tooltip.SetDefault("Maybe the sapphire will be sharp?");
		}
		public override void SetDefaults()
		{
			item.damage = 27;
			item.melee = true;
			item.width = 60;
			item.height = 60;
			item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 7400;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SapphiteBar", 30);
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
