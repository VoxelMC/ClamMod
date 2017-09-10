using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace ClamMod.NPCs
{
    public class MeteorDrop : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (npc.type == NPCID.MeteorHead)
            {
                if (Main.rand.Next(10) == 0)
                {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("UFOMountItem"), 1);
                }
            }
        }
    }
}
