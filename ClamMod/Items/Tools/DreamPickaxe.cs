using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClamMod.Items.Tools
{
	public class DreamPickaxe : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Dream Pickaxe");
            Tooltip.SetDefault("It's like a dream but better!");
		}

		public override void SetDefaults()
		{
			item.damage = 15;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 20;
			item.useAnimation = 20;
			item.pick = 100;
			item.useStyle = 1;
			item.knockBack = 0;
			item.value = 1000;
			item.rare = 3;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;

		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("DreamBar"), 25);
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(10) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 177);
            }
		}
	}
}