using Terraria.ID;
using Terraria.ModLoader;

namespace ClamMod.Items.Weapons
{
	public class AcornBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Acorn Bullet"); 
			Tooltip.SetDefault("Ammo for the Acorn Gun.");
		}

		public override void SetDefaults()
		{
			item.damage = 3;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 1.5f;
			item.value = 10;
			item.rare = 2;
			item.shoot = mod.ProjectileType("AcornBullet");   //The projectile shoot when your weapon using this ammo
			item.shootSpeed = 50f;                  //The speed of the projectile
			item.ammo = AmmoID.Bullet;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Acorn, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}
