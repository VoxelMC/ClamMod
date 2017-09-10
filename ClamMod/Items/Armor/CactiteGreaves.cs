using Terraria;
using Terraria.ModLoader;

namespace ClamMod.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class CactiteGreaves : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 18;
			item.value = 1500;
			item.rare = 1;

			item.defense = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cactite Greaves");
			Tooltip.SetDefault("10% increased movement speed");
		}


		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.1f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "CactiteBar", 18);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}

	}
}
