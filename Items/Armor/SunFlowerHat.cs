using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClamMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class SunFlowerHat : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.rare = 2;
			item.value = 200;
		}

		public override bool DrawHead()
		{
			return true;
		}
		
			public override void UpdateEquip(Player player)
    {
                player.AddBuff(BuffID.Sunflower,2);
				player.AddBuff(BuffID.Shine,2);
}
		
				public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Sunflower,3);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}