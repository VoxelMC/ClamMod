using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace ClamMod.Biomes.Bubblegum.Mobs
{
    public class BubbleSlime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bubble Slime");
            Main.npcFrameCount[npc.type] = 2;
        }

        public override void SetDefaults()
        {
            npc.lifeMax = 80;
            npc.damage = 20;
            npc.defense = 4;
            npc.knockBackResist = 0.6f;
            npc.width = 32;
            npc.height = 22;
            animationType = 1;
            npc.aiStyle = 1;
            npc.npcSlots = 0.1f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = Item.buyPrice(0, 0, 1, 50);
            banner = npc.type;
            bannerItem = mod.ItemType("BubbleSlimeBanner");
        }

        public override void AI()
        {
            if (Main.rand.Next(4) == 0)
                Main.dust[Dust.NewDust(npc.position, npc.width, npc.height, 6, 0f, 0f, 200, npc.color)].velocity *= 0.3f;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
                Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
                Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

                for (int k = 0; k < 20; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
                    Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.6f);
                }
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
         {
                return SpawnCondition.OverworldDaySlime.Chance * 0.6f;
         }
    }
}