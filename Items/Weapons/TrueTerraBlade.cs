using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClamMod.Items.Weapons
{
	public class TrueTerraBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("True Terra Blade");
			Tooltip.SetDefault("Shoots sword beams and flames!");	//The (English) text shown below your weapon's name
		}


        public override void SetDefaults()
		{
			item.damage = 140;			//The damage of your weapon
            item.magic = true;
			item.melee = true;			//Is your weapon a melee weapon?
			item.width = 40;			//Weapon's texture's width
			item.height = 40;			//Weapon's texture's height
			item.useTime = 10;			//The time span of using the weapon. Remember in terraria, 60 frames is a second.
			item.useAnimation = 10;			//The time span of the using animation of the weapon, suggest set it the same as useTime.
			item.useStyle = 1;			//The use style of weapon, 1 for swinging, 2 for drinking, 3 act like shortsword, 4 for use like life crystal, 5 for use staffs or guns
			item.knockBack = 5;			//The force of knockback of the weapon. Maximum is 20
			item.value = 10000000;			//The value of the weapon
			item.rare = 12;             //The rarity of the weapon, from -1 to 13
            item.UseSound = SoundID.Item60;
            item.autoReuse = true;          //Whether the weapon can use automatically by pressing mousebutton
            item.shoot = mod.ProjectileType("HomingTerra");
            item.shootSpeed = 20f;
		}

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TerraBlade,1);
			recipe.AddIngredient(ItemID.BrokenHeroSword,1);
            recipe.AddIngredient(ItemID.SoulofMight, 100);
            recipe.AddIngredient(ItemID.SoulofFright, 50);
            recipe.AddIngredient(ItemID.SoulofSight, 10);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				//Emit dusts when swing the sword
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 44);
			}
		}
	}
}