using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClamMod.Items.Weapons
{
	public class BandageBow : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 32;
			item.width = 16;
			item.height = 32;
			item.ranged = true;
			item.useTime = 20;
			item.shoot = 1;

			item.shootSpeed = 60f;
			item.useAnimation = 20;
			item.useStyle = 5;
			item.knockBack = 5;
			item.value = 1250000;
			item.useAmmo = AmmoID.Arrow;
			item.rare = 4;
			item.crit = 6;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bandage Bow");
			Tooltip.SetDefault("Heals Player upon killing enemies");
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = mod.ProjectileType("BandageArrow");
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AdhesiveBandage,10);
            recipe.AddIngredient(ItemID.WoodenBow, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
