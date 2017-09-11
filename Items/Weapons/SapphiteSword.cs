using Terraria.ID;
using Terraria.ModLoader;

namespace Logicalty.Items.Weapons
{
	public class SapphiteSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sapphite Sword");
			Tooltip.SetDefault("Maybe the sapphire will be sharp?");
		}
		public override void SetDefaults()
		{
			item.damage = 27;
			item.melee = true;
			item.width = 42;
			item.height = 42;
			item.useTime = 13;
			item.useAnimation = 13;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 7400;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("SapphiteShockwave");
            item.shootSpeed = 12f;
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
