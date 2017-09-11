using Terraria;
using Terraria.ModLoader;

namespace Logicalty.Items.Wings
{
	[AutoloadEquip(EquipType.Wings)]
	public class ArdiumWings : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Ardium Wings");
            Tooltip.SetDefault("Metal Plated Wings with Spectre Flavour.");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.value = 10000;
			item.rare = 10;
			item.accessory = true;
            item.sentry = true;
            item.shoot = 28;
            item.shootSpeed = 5f;

		}
		//these wings use the same values as the solar wings
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.wingTimeMax = 500;
            player.GetModPlayer<MyPlayer>(mod).ArdiumWings = true;
            player.pirateMinion = true;
        }


        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 2.85f;
			ascentWhenRising = 3.15f;
			maxCanAscendMultiplier = 30f;
			maxAscentMultiplier = 2f;
			constantAscend = 3.135f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 29f;
			acceleration *= 1.5f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3261, 20);
            recipe.AddIngredient(528, 2);
            recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}