using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Logicalty.Items.Materials
{
    public class SapphiteBar : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 50;
            item.height = 57;
            item.maxStack = 99;
            item.value = Terraria.Item.sellPrice(0, 0, 10, 0);
            item.rare = 5;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sapphite Bar");
            Tooltip.SetDefault("A special forged metal made out of Sapphire and Granite Gems");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Sapphire, 3);
            recipe.AddIngredient(null, "GraniteGem", 3);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}