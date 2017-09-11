using Terraria;
using Terraria.ModLoader;

namespace Logicalty.Buffs
{
    public class ZombieMinionBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Zombie Defender");
            Description.SetDefault("Zombies are your personal undead army.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;

        }


        public override void Update(Player player, ref int buffIndex)
        {
            MyPlayer modPlayer = (MyPlayer)player.GetModPlayer(mod, "MyPlayer");
            if (player.ownedProjectileCounts[mod.ProjectileType("ZombieMinion")] > 0)
            {
                modPlayer.ZombieMinionBuff = true;
            }
            if (!modPlayer.ZombieMinionBuff)
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
            else
            {
                player.buffTime[buffIndex] = 18000;
            }
        }
    }
}