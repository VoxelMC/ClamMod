using Logicalty.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Logicalty.Items.Weapons
{
	public class ThunderBurst : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Thunder Burst");
            Tooltip.SetDefault("Shoots Lightning from Above!");

			// These are all related to gamepad controls and don't seem to affect anything else
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 17;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.useStyle = 5;
			item.width = 24;
			item.height = 24;
			item.useAnimation = 27;
			item.useTime = 27;
			item.shootSpeed = 20f;
			item.knockBack = 2.5f;
			item.damage = 40;
			item.rare = 4;

			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.noUseGraphic = true;

			item.UseSound = SoundID.Item93;
			item.value = Item.sellPrice(platinum: 1);
			item.shoot = mod.ProjectileType<ThunderBurstProjectile>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SapphiteBar", 20);
            recipe.AddIngredient(ItemID.SoulofFlight, 12);
            recipe.AddIngredient(ItemID.Cobweb, 10);
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
