using Terraria.ID;
using Terraria.ModLoader;

namespace Logicalty.Items.Weapons
{
	public class AvalancheWarAxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Avalanche War Axe");
			Tooltip.SetDefault("It's like a Avalanche..");
		}
		public override void SetDefaults()
		{
			item.damage = 28;
			item.melee = true;
			item.width = 42;
			item.height = 42;
			item.useTime = 70;
			item.useAnimation = 70;
			item.useStyle = 1;
			item.knockBack = 12;
			item.value = 7400;
            item.axe = 80;
			item.rare = 5;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SnowBlock, 70);
            recipe.AddIngredient(ItemID.IceBlock, 75);
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
