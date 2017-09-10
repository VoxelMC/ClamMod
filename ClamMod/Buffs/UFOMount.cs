using Terraria;
using Terraria.ModLoader;

namespace ClamMod.Buffs
{
	public class UFOMount : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("UFO Buff");
			Description.SetDefault("You feel from another planet..");
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			canBeCleared = false;
		}
	}
}
