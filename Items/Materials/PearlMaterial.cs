﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClamMod.Items.Materials
{
    public class PearlMaterial : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 50;
            item.height = 57;
            item.maxStack = 99;
            item.value = Terraria.Item.sellPrice(0, 0, 25, 0);
            item.rare = 5;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pearl");
            Tooltip.SetDefault("It Shines proud at you..");
        }
    }
}