using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClamMod.Items.Weapons.Magic
{
	public class HallophyteStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Hallophyte Staff");
            Tooltip.SetDefault("Shoots out Deadly Thorns at rapid speed.");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 23;
			item.magic = true;
			item.mana = 12;
			item.width = 40;
			item.height = 40;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
            item.shoot = 246;
			item.shootSpeed = 30f;
		}
	}
}