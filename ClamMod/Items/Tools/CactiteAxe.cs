using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClamMod.Items.Tools
{
	public class CactiteAxe : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Cactite Axe");
            Tooltip.SetDefault("A axe made out of iron and cactus!");
		}

		public override void SetDefaults()
		{
			item.damage = 20;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 25;
			item.useAnimation = 25;
			item.axe = 40;			//How much axe power the weapon has, note that the axe power displayed in-game is this value multiplied by 5
			item.hammer = 0;		//How much hammer power the weapon has
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 100;
			item.rare = 3;
			item.UseSound = SoundID.Item79;
            item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "CactiteBar", 14);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(10) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 93);
            }
		}
	}
}
