using Terraria.ID;
using Terraria.ModLoader;

namespace Logicalty.Items.Weapons
{
	public class AvalancheKatana : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Avalanche Katana");
			Tooltip.SetDefault("It's like a Avalanche..");
		}
		public override void SetDefaults()
		{
			item.damage = 17;
			item.melee = true;
			item.width = 60;
			item.height = 60;
			item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = 1;
			item.knockBack = 8;
			item.value = 7400;
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SnowBlock, 56);
            recipe.AddIngredient(ItemID.IceBlock, 55);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
