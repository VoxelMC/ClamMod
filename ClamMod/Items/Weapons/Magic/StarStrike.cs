using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClamMod.Items.Weapons.Magic
{
	public class StarStrike : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Star Strike");
            Tooltip.SetDefault("Releases Hell from above!");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 83;
			item.magic = true;
			item.mana = 14;
			item.width = 40;
			item.height = 40;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 1000000;
			item.rare = 10;
			item.UseSound = SoundID.Item105;
			item.autoReuse = true;
            item.shoot = mod.ProjectileType("StarStrikeProjectile");
            item.shootSpeed = 16f;
        }
	}
}