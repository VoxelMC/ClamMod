using Terraria.ID;
using Terraria.ModLoader;

namespace ClamMod.Items.Placeable
{
	public class AcornDoor : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Acorn Door"); 
			Tooltip.SetDefault("It's a door made out of acorns.");
		}

		public override void SetDefaults()
		{
			item.width = 14;
			item.height = 28;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 150;
			item.createTile = mod.TileType("AcornDoorClosed");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WoodenDoor);
			recipe.AddIngredient(ItemID.Acorn, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}