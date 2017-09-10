using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClamMod.Items.Materials
{
    public class DreamBar : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 50;
            item.height = 57;
            item.maxStack = 99;
            item.value = Terraria.Item.sellPrice(0, 0, 1, 0);
            item.rare = 6;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dream Bar");
            Tooltip.SetDefault("The Dream finally becomes a reality.");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, ("DreamOre"), 3);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}