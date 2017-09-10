using Terraria;
using Terraria.ModLoader;

namespace ClamMod.Projectiles
{
	public class LightningBolt : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(443);

			aiType = 443;
			projectile.magic = true;

			projectile.timeLeft = 500;
			Main.projFrames[projectile.type] = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("LightningBolt");

		}



	}
}
