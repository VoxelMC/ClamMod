using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
// If you are using c# 6, you can use: "using static Terraria.Localization.GameCulture;" which would mean you could just write "DisplayName.AddTranslation(German, "");"
using Terraria.Localization;

namespace ClamMod.Items.Placeable
{
	public class AcornBlock : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Acorn Block");
			Tooltip.SetDefault("A Block made out of Acorns");
			ItemID.Sets.ExtractinatorMode[item.type] = item.type;
		}

		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.createTile = mod.TileType("AcornBlock");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Acorn, 5);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void ExtractinatorUse(ref int resultType, ref int resultStack)
		{
			if (Main.rand.Next(30) == 0)
			{
				resultType = mod.ItemType("FoulOrb");
				if (Main.rand.Next(5) == 0)
				{
					resultStack += Main.rand.Next(2);
				}
			}
		}
	}
}
