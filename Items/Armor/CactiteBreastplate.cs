using Terraria;
using Terraria.ModLoader;

namespace ClamMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class CactiteBreastplate : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 18;
			item.value = 250;
			item.rare = 2;

			item.defense = 3;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cactite Breastplate");
			Tooltip.SetDefault("10% increased Melee Speed");
		}


		public override void UpdateEquip(Player player)
		{
			player.meleeSpeed += 0.10f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "CactiteBar", 20);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
