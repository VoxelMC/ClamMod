using Terraria.ModLoader;

namespace Logicalty.Items.Placeable
{
	public class AcornWall : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("A Wall made out of Acorns");
		}

		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 7;
			item.useStyle = 1;
			item.consumable = true;
			item.createWall = mod.WallType("AcornWall");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AcornBlock");
			recipe.SetResult(this, 4);
			recipe.AddRecipe();
		}
	}
}