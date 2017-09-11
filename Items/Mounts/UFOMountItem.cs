using Terraria.ID;
using Terraria.ModLoader;

namespace ClamMod.Items.Mounts
{
	public class UFOMountItem : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("UFO Ship");
            Tooltip.SetDefault("Right Click to fly in a UFO!");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.value = 30000;
			item.rare = 7;
			item.UseSound = SoundID.Item79;
			item.noMelee = true;
			item.mountType = mod.MountType("UFOMount");
		}
	}
}