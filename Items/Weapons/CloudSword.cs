using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClamMod.Items.Weapons
{
	public class CloudSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cloud of Devastation");
			Tooltip.SetDefault("A Mystic Sword made out of Clouds.");	//The (English) text shown below your weapon's name
		}

		public override void SetDefaults()
		{
			item.damage = 30;			//The damage of your weapon
			item.melee = true;			//Is your weapon a melee weapon?
			item.width = 40;			//Weapon's texture's width
			item.height = 40;			//Weapon's texture's height
			item.useTime = 40;			//The time span of using the weapon. Remember in terraria, 60 frames is a second.
			item.useAnimation = 40;			//The time span of the using animation of the weapon, suggest set it the same as useTime.
			item.useStyle = 1;			//The use style of weapon, 1 for swinging, 2 for drinking, 3 act like shortsword, 4 for use like life crystal, 5 for use staffs or guns
			item.knockBack = 15;			//The force of knockback of the weapon. Maximum is 20
			item.value = 1000000;			//The value of the weapon
			item.rare = 6;				//The rarity of the weapon, from -1 to 13
			item.UseSound = SoundID.DD2_BetsyWindAttack;		//The sound when the weapon is using
			item.autoReuse = true;			//Whether the weapon can use automatically by pressing mousebutton
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Cloud,30);
			recipe.AddIngredient(ItemID.SilverBroadsword,1);
			recipe.AddTile(TileID.SkyMill);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				//Emit dusts when swing the sword
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 16);
			}
		}
	}
}