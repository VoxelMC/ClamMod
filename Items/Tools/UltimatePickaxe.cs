using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClamMod.Items.Tools
{
	public class UltimatePickaxe : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Ultimate Pickaxe");
            Tooltip.SetDefault("It's like Ultimate but with Capital U");
		}

		public override void SetDefaults()
		{
			item.damage = 9000;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 6;
			item.useAnimation = 6;
			item.pick = 600;
			item.useStyle = 1;
			item.knockBack = 0;
			item.value = 1000000000;
			item.rare = 11;
			item.UseSound = SoundID.Item33;
			item.autoReuse = true;

		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Picksaw);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(10) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 177);
                player.GetModPlayer<MyPlayer>(mod).Ultimate = true;
            }
		}
	}
}