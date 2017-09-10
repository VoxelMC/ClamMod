using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ClamMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class CactiteHelmet : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 22;
			item.value = 1500;

			item.rare = 3;
			item.defense = 3;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cactite Helmet");
			Tooltip.SetDefault("10% increased damage");
		}


		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.1f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("CactiteBreastplate") && legs.type == mod.ItemType("CactiteGreaves");
		}

		public override void UpdateArmorSet(Player player)
		{

			player.setBonus = "Your body become spiky";
			player.thorns = 1;


			if (Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y) > 1f && !player.rocketFrame) // Makes sure the player is actually moving
			{
				for (int k = 0; k < 2; k++)
				{
					int index = Dust.NewDust(new Vector2(player.position.X - player.velocity.X * 2f, player.position.Y - 2f - player.velocity.Y * 2f), player.width, player.height, 44, 0f, 0f, 100, default(Color), 2f);
					Main.dust[index].noGravity = true;
					Main.dust[index].noLight = true;
					Dust dust = Main.dust[index];
					dust.velocity.X = dust.velocity.X - player.velocity.X * 0.5f;
					dust.velocity.Y = dust.velocity.Y - player.velocity.Y * 0.5f;
				}
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "CactiteBar", 25);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}

	}
}
