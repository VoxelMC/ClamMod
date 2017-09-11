using Terraria.ID;
using Terraria.ModLoader;

namespace Logicalty.Items.Weapons
{
	public class SapphiteDagger : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sapphite Dagger");
			Tooltip.SetDefault("Maybe the sapphire will be sharp?");
		}
		public override void SetDefaults()
		{
			item.damage = 23;
			item.melee = true;
			item.width = 42;
			item.height = 42;
			item.useTime = 17;
			item.useAnimation = 17;
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
            recipe.AddIngredient(null, "SapphiteBar", 25);
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
