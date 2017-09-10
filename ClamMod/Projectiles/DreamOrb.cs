using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClamMod.Projectiles
{
	public class DreamOrb : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.friendly = true;
			projectile.width = 1;
			projectile.height = 1;
			projectile.aiStyle = 0;
			Main.projFrames[projectile.type] = 4;
			projectile.timeLeft = 1200;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 4;
			ProjectileID.Sets.TrailingMode[projectile.type] = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("DreamOrb");

		}


		public override void AI()
		{
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 177, default(Color), 0.9f);
			Main.dust[dust].noGravity = true;

			if (projectile.frameCounter < 5)
				projectile.frame = 0;
			else if (projectile.frameCounter >= 5 && projectile.frameCounter < 10)
				projectile.frame = 1;
			else if (projectile.frameCounter >= 10 && projectile.frameCounter < 15)
				projectile.frame = 2;
			else if (projectile.frameCounter >= 15 && projectile.frameCounter < 20)
				projectile.frame = 3;
			else
				projectile.frameCounter = 0;
			projectile.frameCounter++;
		}

		public override void Kill(int timeLeft)
		{


			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 62);
			projectile.position.X = projectile.position.X + projectile.width / 2;
			projectile.position.Y = projectile.position.Y + projectile.height / 2;
			projectile.width = 80;
			projectile.height = 80;
			projectile.position.X = projectile.position.X - projectile.width / 2;
			projectile.position.Y = projectile.position.Y - projectile.height / 2;
            Vector2 value16 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
            for (int num628 = 0; num628 < 40; num628++)
			{
				int num629 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 177, 0f, 0f, 491, default(Color), 2f);
				Main.dust[num629].velocity *= 3f;
				if (Main.rand.Next(2) == 0)
				{
					Main.dust[num629].scale = 0.5f;
					Main.dust[num629].fadeIn = 1f + Main.rand.Next(10) * 0.1f;
				}
			}
			for (int num630 = 0; num630 < 70; num630++)
			{
				int num631 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 177, 0f, 0f, 491, default(Color), 3f);
                Main.dust[num631].noGravity = true;
				Main.dust[num631].velocity *= 5f;
                num631 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 177, 0f, 0f, 491, default(Color), 2f);
				Main.dust[num631].velocity *= 2f;
			}
			for (int num632 = 0; num632 < 3; num632++)
			{
				float scaleFactor10 = 0.33f;
				if (num632 == 1)
				{
					scaleFactor10 = 0.66f;
				}
				if (num632 == 2)
				{
					scaleFactor10 = 1f;
				}
				int num633 = Gore.NewGore(new Vector2(projectile.position.X + projectile.width / 2 - 24f, projectile.position.Y + projectile.height / 2 - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[num633].velocity *= scaleFactor10;
				Gore expr_13E6D_cp_0 = Main.gore[num633];
				expr_13E6D_cp_0.velocity.X = expr_13E6D_cp_0.velocity.X + 1f;
				Gore expr_13E8D_cp_0 = Main.gore[num633];
				expr_13E8D_cp_0.velocity.Y = expr_13E8D_cp_0.velocity.Y + 1f;
				num633 = Gore.NewGore(new Vector2(projectile.position.X + projectile.width / 2 - 24f, projectile.position.Y + projectile.height / 2 - 24f), default(Vector2), Main.rand.Next(61, 64), 2f);
				Main.gore[num633].velocity *= scaleFactor10;
				Gore expr_13F30_cp_0 = Main.gore[num633];
				expr_13F30_cp_0.velocity.X = expr_13F30_cp_0.velocity.X - 1f;
				Gore expr_13F50_cp_0 = Main.gore[num633];
				expr_13F50_cp_0.velocity.Y = expr_13F50_cp_0.velocity.Y + 1f;
				num633 = Gore.NewGore(new Vector2(projectile.position.X + projectile.width / 2 - 24f, projectile.position.Y + projectile.height / 2 - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[num633].velocity *= scaleFactor10;
				Gore expr_13FF3_cp_0 = Main.gore[num633];
				expr_13FF3_cp_0.velocity.X = expr_13FF3_cp_0.velocity.X + 1f;
				Gore expr_14013_cp_0 = Main.gore[num633];
				expr_14013_cp_0.velocity.Y = expr_14013_cp_0.velocity.Y - 1f;
				num633 = Gore.NewGore(new Vector2(projectile.position.X + projectile.width / 2 - 24f, projectile.position.Y + projectile.height / 2 - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[num633].velocity *= scaleFactor10;
				Gore expr_140B6_cp_0 = Main.gore[num633];
				expr_140B6_cp_0.velocity.X = expr_140B6_cp_0.velocity.X - 1f;
				Gore expr_140D6_cp_0 = Main.gore[num633];
				expr_140D6_cp_0.velocity.Y = expr_140D6_cp_0.velocity.Y - 1f;
			}
			projectile.position.X = projectile.position.X + projectile.width / 2;
			projectile.position.Y = projectile.position.Y + projectile.height / 2;
			projectile.width = 10;
			projectile.height = 10;
			projectile.position.X = projectile.position.X - projectile.width / 2;
			projectile.position.Y = projectile.position.Y - projectile.height / 2;

			if (projectile.owner == Main.myPlayer)
			{
				int num220 = Main.rand.Next(3, 8);
				for (int num221 = 0; num221 < num220; num221++)
				{
					Vector2 value17 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
					value17.Normalize();
					value17 *= Main.rand.Next(10, 201) * 0.01f;
                    Projectile.NewProjectile(projectile.position.X, projectile.position.Y, value17.X, value17.Y, 659, projectile.damage, 1f, projectile.owner, 0f, Main.rand.Next(-45, 1));
                }
			}
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(2) == 0)
            {
                int debuff = GetDebuff();
                if (debuff > 0)
                {
                    target.AddBuff(debuff, GetDebuffTime());
                }
            }
        }

        public void LightColor()
        {
            float r = 0f;
            float g = 0f;
            float b = 0f;
            switch ((int)projectile.ai[0])
            {
                case 0:
                    r = 128f;
                    g = 0f;
                    b = 128f;
                    break;
                case 1:
                    r = 128f;
                    g = 0f;
                    b = 128f;
                    break;
                case 2:
                    r = 128f;
                    g = 0f;
                    b = 128f;
                    break;
                case 3:
                    r = 128f;
                    g = 0f;
                    b = 128f;
                    break;
                case 4:
                    r = 128f;
                    g = 0f;
                    b = 128f;
                    break;
                case 5:
                    r = 128f;
                    g = 0f;
                    b = 128f;
                    break;
            }
            Lighting.AddLight(projectile.position, r, g, b);
        }

        public int GetDebuff()
            {
                switch ((int)projectile.ai[0])
                {
                    case 0:
                        return 153;
                    case 1:
                        return 68;
                    case 2:
                        return 70;
                    case 3:
                        return 0;
                    case 4:
                        return 163;
                    case 5:
                        return 181;
                    default:
                        return 0;
                }
            }

            public int GetDebuffTime()
            {
                switch ((int)projectile.ai[0])
                {
                    case 0:
                        return 600;
                    case 1:
                        return 400;
                    case 2:
                        return 300;
                    case 3:
                        return 0;
                    case 4:
                        return 400;
                    case 5:
                        return 900;
                    default:
                        return 0;
                }
            }
        }
    }
