using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClamMod.Items.Weapons.Magic
{
	public class AcornStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Acorn Staff");
			Tooltip.SetDefault("Obtain the Power of the Trees.");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 6;
			item.magic = true;
			item.mana = 1;
			item.width = 40;
			item.height = 40;
			item.useTime = 10;
			item.useAnimation = 25;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 2;
			item.value = 100;
			item.rare = 1;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("AcornStaffProjectile");
			item.shootSpeed = 16f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Acorn,80);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}