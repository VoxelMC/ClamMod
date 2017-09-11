using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent;
using Terraria.GameContent.UI;
using Terraria.GameInput;
using Terraria.Graphics.Capture;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.ModLoader;

namespace Logicalty
{
    public class MyPlayer : ModPlayer
    {
        private const int saveVersion = 0;
        public static bool hasProjectile;
        private const int num = 1;

        public bool ZombieMinionBuff = false;
        public bool blockyAccessoryPrevious;
        public bool blockyAccessory;
        public bool blockyHideVanity;
        public bool blockyForceVanity;
        public bool blockyPower;
        public bool CloudBoots;
        public bool ArdiumWings;
        public bool ArdiumBuff = false;
        public bool Calming;
        public bool Ultimate;
        public bool ZoneExample = false;

        public override void ResetEffects()
        {
            CloudBoots = false;
            ZombieMinionBuff = false;
            blockyAccessoryPrevious = blockyAccessory;
            blockyAccessory = blockyHideVanity = blockyForceVanity = blockyPower = false;
            ArdiumWings = false;
            ArdiumBuff = false;
            Calming = false;
            Ultimate = false;

        }

        public override void UpdateBiomes()
        {
            ZoneExample = (MyWorld.exampleTiles > 50);
        }

        public override bool CustomBiomesMatch(Player other)
        {
            MyPlayer modOther = other.GetModPlayer<MyPlayer>(mod);
            return ZoneExample == modOther.ZoneExample;
        }

        public override void CopyCustomBiomesTo(Player other)
        {
            MyPlayer modOther = other.GetModPlayer<MyPlayer>(mod);
            modOther.ZoneExample = ZoneExample;
        }

        public override void SendCustomBiomes(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = ZoneExample;
            writer.Write(flags);
        }

        public override void ReceiveCustomBiomes(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            ZoneExample = flags[0];
        }

        public override void PostUpdate()
        {
            if (ZoneExample)
            {
                player.ZoneHoly = true;
            }
        }

        public override void UpdateBadLifeRegen()
        {
            if (ZombieMinionBuff)
            {
                player.minionDamage += 0.05f;
                player.moveSpeed += 0.1f;
            }
        }
        public override void UpdateVanityAccessories()
        {
            for (int n = 13; n < 18 + player.extraAccessorySlots; n++)
            {
                Item item = player.armor[n];
                if (item.type == mod.ItemType<Items.Armor.ExampleCostume>())
                {
                    blockyHideVanity = false;
                    blockyForceVanity = true;
                }
            }
        }
        public override void FrameEffects()
        {
            if ((blockyPower || blockyForceVanity) && !blockyHideVanity)
            {
                player.legs = mod.GetEquipSlot("BlockyLegs", EquipType.Legs);
                player.body = mod.GetEquipSlot("BlockyBody", EquipType.Body);
                player.head = mod.GetEquipSlot("BlockyHead", EquipType.Head);
            }
        }
        public override void ModifyDrawInfo(ref PlayerDrawInfo drawInfo)
        {
            if ((blockyPower || blockyForceVanity) && !blockyHideVanity)
            {
                player.headRotation = player.velocity.Y * (float)player.direction * 0.1f;
                player.headRotation = Utils.Clamp(player.headRotation, -0.3f, 0.3f);
            }
        }
        public override void PostUpdateEquips()
        {
            for (int n = 13; n < 18 + player.extraAccessorySlots; n++)
            {
                Item item = player.armor[n];
                if (item.type == mod.ItemType<Items.Weapons.AnnihilationCannon>())
                {
                    player.blockRange = 9999;
                }
            }

            if (CloudBoots && player.velocity.Y != 0 && !player.controlDown)
            {
                float num = player.gravity;
                player.slowFall = false;
                Main.PlaySound(2, player.position, 24);
                Dust.NewDust(new Vector2(player.position.X, player.position.Y + 40), 0, 0, 16);
                if (player.gravDir == 1f && player.velocity.Y > -num && !player.controlUp)
                {
                    player.velocity.Y = -(num + 1E-06f);
                }
                else if (player.gravDir == -1f && player.velocity.Y < num && !player.controlUp)
                {
                    player.velocity.Y = num + 1E-06f;
                }
                else if (player.controlUp)
                {
                    player.velocity.Y = -5 * player.gravDir;
                }
            }
            if (ArdiumWings && player.velocity.Y != 0)
            {
                Dust.NewDust(new Vector2(player.position.X, player.position.Y + 40), 0, 0, 15);
            }
            if (Calming)
            {
                player.calmed = true;
            }
        }
        public override void MeleeEffects(Item item, Rectangle hitbox)
        {
            if (Ultimate)
            {
                player.meleeSpeed += 30;
            }
        }

        public override void OnHitNPCWithProj(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            if (projectile.type == mod.ProjectileType("BandageArrow") && (damage > target.life) && target.dontTakeDamage == false) 
                {
                int d = (int)(damage / 2);
                player.statLife += d;
                player.HealEffect(d, false);
                }

        }

    }
}
