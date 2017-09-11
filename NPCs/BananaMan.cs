using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace Logicalty.NPCs
{
	[AutoloadHead]
	public class BananaMan : ModNPC
	{
		public override string Texture
		{
			get
			{
				return "Logicalty/NPCs/BananaMan";
			}
		}

		public override string[] AltTextures
		{
			get
			{
				return new string[] { "Logicalty/NPCs/BananaMan_Alt_1" };
			}
		}

		public override bool Autoload(ref string name)
		{
			name = "BananaMan";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("BananaMan");
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 40;
			npc.height = 56;
			npc.aiStyle = 7;
			npc.damage = 90;
			npc.defense = 15;
			npc.lifeMax = 500;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.PartyGirl;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			int num = npc.life > 0 ? 1 : 5;
			for (int k = 0; k < num; k++)
			{
                Dust.NewDust(npc.position, npc.width, npc.height, 80);
			}
		}

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            return NPC.downedBoss1;
        }

        public override bool CheckConditions(int left, int right, int top, int bottom)
		{
			int score = 0;
			for (int x = left; x <= right; x++)
			{
				for (int y = top; y <= bottom; y++)
				{
					int type = Main.tile[x, y].type;
					if (type == mod.TileType("ExampleBlock") || type == mod.TileType("ExampleChair") || type == mod.TileType("ExampleWorkbench") || type == mod.TileType("ExampleBed") || type == mod.TileType("ExampleDoorOpen") || type == mod.TileType("ExampleDoorClosed"))
					{
						score++;
					}
					if (Main.tile[x, y].wall == mod.WallType("ExampleWall"))
					{
						score++;
					}
				}
			}
			return score >= (right - left) * (bottom - top) / 2;
		}

		public override string TownNPCName()
		{
			switch (WorldGen.genRand.Next(4))
			{
				case 0:
					return "Peanut Butter Jelly Time";
				case 1:
					return "Jeff";
				case 2:
					return "Mr P";
				default:
					return "Wade";
			}
		}

		public override void FindFrame(int frameHeight)
		{
			/*npc.frame.Width = 40;
			if (((int)Main.time / 10) % 2 == 0)
			{
				npc.frame.X = 40;
			}
			else
			{
				npc.frame.X = 0;
			}*/
		}

		public override string GetChat()
		{
			int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
			if (partyGirl >= 0 && Main.rand.Next(4) == 0)
			{
				return "Yoooo " + Main.npc[partyGirl].GivenName + " Welcome to the Banana Party!";
			}
			switch (Main.rand.Next(3))
			{
				case 0:
					return "I feel like throwing a party every day, what about you?";
				case 1:
					return "Eat your vegetables, not fruits because that would endanger our species!";
				default:
					return "Hey you look fruity, can i eat you?";
			}
		}

		/* 
		// Consider using this alternate approach to choosing a random thing. Very useful for a variety of use cases.
		// The WeightedRandom class needs "using Terraria.Utilities;" to use
		public override string GetChat()
		{
			WeightedRandom<string> chat = new WeightedRandom<string>();

			int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
			if (partyGirl >= 0 && Main.rand.Next(4) == 0)
			{
				chat.Add("Can you please tell " + Main.npc[partyGirl].GivenName + " to stop decorating my house with colors?");
			}
			chat.Add("Sometimes I feel like I'm different from everyone else here.");
			chat.Add("What's your favorite color? My favorite colors are white and black.");
			chat.Add("What? I don't have any arms or legs? Oh, don't be ridiculous!");
			chat.Add("This message has a weight of 5, meaning it appears 5 times more often.", 5.0);
			chat.Add("This message has a weight of 0.1, meaning it appears 10 times as rare.", 0.1);
			return chat; // chat is implicitly cast to a string. You can also do "return chat.Get();" if that makes you feel better
		}
		*/

		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Lang.inter[28].Value;
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				shop = true;
			}
		}

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			shop.item[nextSlot].SetDefaults(mod.ItemType("BunnySword"));
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("GrassWhip"));
			nextSlot++;
			if (Main.moonPhase < 3)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("CloudSword"));
				nextSlot++;
			}
			if (Main.moonPhase < 4)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("AcornGun"));
				nextSlot++;
                shop.item[nextSlot].SetDefaults(mod.ItemType("AcornSword"));
                nextSlot++;
            }
			else if (Main.moonPhase < 5)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("UltimatePickaxe"));
				nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType("MoonShot"));
				nextSlot++;
			}
			else if (Main.moonPhase < 6)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("ZombieSummonStaff"));
				nextSlot++;
			}
			else
			{
			}
			// Here is an example of how your npc can sell items from other mods.
			if (ModLoader.GetLoadedMods().Contains("TremorMod"))
			{
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("TremorMod").ItemType("Bad Apple"));
				nextSlot++;
			}
		}

		public override void NPCLoot()
		{
			Item.NewItem(npc.getRect(), mod.ItemType<Items.Armor.ExampleCostume>());
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 20;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 30;
			randExtraCooldown = 30;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = 30;
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 2f;
		}
	}
}