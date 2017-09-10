using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClamMod.Projectiles
{
    public class ZombieMinion : ModProjectile
    {
        public float dust = 0f;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zombie Minion");
        }
        public override void SetDefaults()
        {
            projectile.netImportant = true;
            projectile.friendly = true;
            projectile.minionSlots = 1;
            projectile.alpha = 75;
            projectile.CloneDefaults(ProjectileID.OneEyedPirate);
            projectile.timeLeft = 250;
            aiType = ProjectileID.OneEyedPirate;
            projectile.timeLeft = 18000;
            Main.projFrames[projectile.type] = 15;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            projectile.penetrate = -1;
            projectile.timeLeft *= 5;
            projectile.minion = true;
        }

        public override void AI()
        {
            if (dust == 0f)
            {
                int num226 = 16;
                for (int num227 = 0; num227 < num226; num227++)
                {
                    Vector2 vector6 = Vector2.Normalize(projectile.velocity) * new Vector2((float)projectile.width / 2f, (float)projectile.height) * 0.75f;
                    vector6 = vector6.RotatedBy((double)((float)(num227 - (num226 / 2 - 1)) * 6.28318548f / (float)num226), default(Vector2)) + projectile.Center;
                    Vector2 vector7 = vector6 - projectile.Center;
                    int num228 = Dust.NewDust(vector6 + vector7, 0, 14, 0, vector7.X * 1f, vector7.Y * 1f, 100, default(Color), 1.1f);
                    Main.dust[num228].noGravity = true;
                    Main.dust[num228].noLight = true;
                    Main.dust[num228].velocity = vector7;
                }
                dust += 1f;
            }
            bool flag64 = projectile.type == mod.ProjectileType("ZombieMinion");
            Player player = Main.player[projectile.owner];
            MyPlayer modPlayer = (MyPlayer)player.GetModPlayer(mod, "MyPlayer");
            player.AddBuff(mod.BuffType("ZombieMinionBuff"), 3600);
            if (flag64)
            {
                if (player.dead)
                {
                    modPlayer.ZombieMinionBuff = false;
                }
                if (modPlayer.ZombieMinionBuff)
                {
                    projectile.timeLeft = 2;
                }
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.penetrate == 0)
            {
                projectile.Kill();
            }
            return false;
        }
    }
}