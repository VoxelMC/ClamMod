using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Logicalty.Projectiles
{
	public class ArdiumProjectile : ModProjectile
	{

        public override void SetDefaults()
		{
            projectile.netImportant = true;
            projectile.tileCollide = false;
            projectile.light = 0.1f;
            projectile.width = 14;
            projectile.height = 14;
            projectile.aiStyle = 42;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 180;
        }

        public override void AI()
        {
            Player owner = Main.player[projectile.owner]; //Makes a player variable of owner set as the player using the projectile
            projectile.light = 0.9f; //Lights up the whole room
            projectile.alpha = 128; //Semi Transparent
            projectile.rotation += (float)projectile.direction * 0.8f; //Spins in a good speed
            int DustID = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width + 4, projectile.height + 4, 36, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 120, default(Color), 0.75f); //Spawns dust
            Main.dust[DustID].noGravity = true; //Makes dust not fall
            if (projectile.timeLeft % 15 == 0) //”%” is modulate, which means the remainder, so this is saying that it will spawn projectiles every 15 frames
            {
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, MathHelper.Lerp(-1f, 1f, (float)Main.rand.NextDouble()), MathHelper.Lerp(-1f, 1f, (float)Main.rand.NextDouble()), mod.ProjectileType("ExampleBulletB"), 5 * (int)owner.rangedDamage, projectile.knockBack, Main.myPlayer); //owner.rangedDamage is basically the damage multiplier for ranged weapons
            }
        }


        public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
			}
			else
			{
				projectile.ai[0] += 0.1f;
				if (projectile.velocity.X != oldVelocity.X)
				{
					projectile.velocity.X = -oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y)
				{
					projectile.velocity.Y = -oldVelocity.Y;
				}
				projectile.velocity *= 0.75f;
				Main.PlaySound(2, projectile.position, 60);
			}
			return false;
		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Sparkle"), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
			}
			Main.PlaySound(SoundID.Item25, projectile.position);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.ai[0] += 0.1f;
			projectile.velocity *= 0.75f;
		}
	}
}