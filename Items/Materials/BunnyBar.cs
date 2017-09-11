using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Logicalty.Items.Materials
{
    public class BunnyBar : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 50;
            item.height = 57;
            item.maxStack = 99;
            item.value = Terraria.Item.sellPrice(0, 10, 0, 0);
            item.rare = 2;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bunny Bar");
            Tooltip.SetDefault("A special forged metal made out of Bunny flesh");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("BunnyFurr"), 3);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}