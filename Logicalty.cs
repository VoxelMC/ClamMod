using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Logicalty.Tiles;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
using System;

namespace Logicalty
{
    public class Logicalty : Mod
    {

        internal static Logicalty instance;
        public static Effect exampleEffect;

        public Logicalty()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }
		public override void Load()
        {
            AddEquipTexture(new Items.Armor.ExampleCostume(), EquipType.Head, "BlockyHead", "Logicalty/Items/Armor/ExampleCostume_Head");
		    AddEquipTexture(new Items.Armor.ExampleCostume(), EquipType.Legs, "BlockyLegs", "Logicalty/Items/Armor/ExampleCostume_Legs");
			AddEquipTexture(new Items.Armor.ExampleCostume(), EquipType.Body, "BlockyBody", "Logicalty/Items/Armor/ExampleCostume_Body", "Logicalty/Items/Armor/ExampleCostume_Arms");
            exampleEffect = GetEffect("Effects/ExampleEffect");
            Ref<Effect> exampleEffectRef = new Ref<Effect>();
            exampleEffectRef.Value = exampleEffect;
            GameShaders.Armor.BindShader<ArmorShaderData>(ItemType<Items.Accessories.DreamDye>(), new ArmorShaderData(exampleEffectRef, "DreamDyePass"));
        }
        public override void Unload()
        {
            // Unload static references
            // You need to clear static references to assets (Texture2D, SoundEffects, Effects). 
            exampleEffect = null;
        }
    }
}