using Terraria.ID;
using Terraria.ModLoader;

namespace Logicalty.Items.Weapons
{
	public class AvalancheFlail : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 10;
			item.rare = 10;
			item.noMelee = true;
			item.useStyle = 5;
			item.useAnimation = 40;
			item.useTime = 40;
			item.knockBack = 7.5F;
			item.damage = 28;
			item.scale = 1.1F;
			item.noUseGraphic = true;
			item.shoot = mod.ProjectileType("AvalancheFlail");
			item.shootSpeed = 13f;
			item.UseSound = SoundID.Item1;
			item.melee = true;
			item.channel = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Avalanche Flail");
			Tooltip.SetDefault("It's like a Avalanche..");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IceBlock, 60);
            recipe.AddIngredient(ItemID.SnowBlock, 60);
			recipe.AddIngredient(ItemID.Chain, 8);
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
