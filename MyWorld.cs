using System.IO;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;

namespace Logicalty
{
    public class MyWorld : ModWorld
    {
        private const int saveVersion = 0;

        public static int exampleTiles = 0;

        public int BlockLining(double x, double y, int repeats, int tileType, bool random, int max, int min = 3)
        {
            for (double i = x; i < x + repeats; i++)
            {
                if (random)
                {
                    for (double k = y; k < y + Main.rand.Next(min, max); k++)
                    {
                        WorldGen.PlaceTile((int)i, (int)k, tileType);
                    }
                }
                else
                {
                    for (double k = y; k < y + max; k++)
                    {
                        WorldGen.PlaceTile((int)i, (int)k, tileType);
                    }
                }
            }
            return repeats;
        }

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (ShiniesIndex == -1)
            {
                return;
            }

            tasks.Insert(ShiniesIndex + 4, new PassLegacy("Generating Dream Ore", delegate (GenerationProgress progress)
            {
                progress.Message = "Generating Dream Ore";

                for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
                {
                    int i2 = WorldGen.genRand.Next(0, Main.maxTilesX);
                    int j2 = WorldGen.genRand.Next((int)(Main.maxTilesY * .3f), (int)(Main.maxTilesY * .45f));
                    WorldGen.OreRunner(i2, j2, WorldGen.genRand.Next(3, 4), WorldGen.genRand.Next(3, 8), (ushort)mod.TileType("DreamOre"));
                }
            }));

            tasks.Insert(ShiniesIndex + 8, new PassLegacy("Mod Biomes", delegate (GenerationProgress progress)
            {
                progress.Message = "Generating BiomeExample";
                IL_19:
                int StartPositionX = WorldGen.genRand.Next(0, Main.maxTilesX - 2);
                int StartPositionY = (int)Main.worldSurface;
                int StartX = 0;
                int StartY = 0;
                int Size = 0;
                int[] BlockNums = { 23, 25, 147, 161, 163, 164, 200, 0, 2 };
                int[] OreNums = { 408 };
                if (Main.maxTilesX == 4200 && Main.maxTilesY == 1200)
                {
                    Size = 105;
                }
                if (Main.maxTilesX == 6300 && Main.maxTilesY == 1800)
                {
                    Size = 198;
                }
                if (Main.maxTilesX == 8400 && Main.maxTilesY == 2400)
                {
                    Size = 270;
                }
                if (Main.tile[StartPositionX, StartPositionY].type == TileID.SnowBlock)
                {
                    StartX = StartPositionX;
                    StartY = StartPositionY;
                    StartX = StartX - 100;
                    StartY = StartY - 100;
                    StartY++;
                    for (int X = StartX - Size; X <= StartX + Size; X++)
                    {
                        for (int Y = StartY - Size; Y <= StartY + Size; Y++)
                        {
                            if (Vector2.Distance(new Vector2(StartX, StartY), new Vector2(X, Y)) <= Size)
                            {
                                if (Main.tile[X, Y].wall == 40 || Main.tile[X, Y].wall == 71)
                                {
                                    Main.tile[X, Y].wall = 110;
                                }
                                if (Main.tile[X, Y].type == 23 || Main.tile[X, Y].type == 147 || Main.tile[X, Y].type == 161 || Main.tile[X, Y].type == 25 || Main.tile[X, Y].type == 163 || Main.tile[X, Y].type == 164 || Main.tile[X, Y].type == 200 || Main.tile[X, Y].type == 0 || Main.tile[X, Y].type == 2 || Main.tile[X, Y].type == TileID.Stone || Main.tile[X, Y].type == TileID.Sand)
                                {
                                    Main.tile[X, Y].type = 249;
                                }
                                if (Main.tile[X, Y].liquid == 3)
                                {
                                    WorldGen.PlaceTile(X, Y, 162);
                                }
                                if (Main.tile[X, Y].type == 6 || Main.tile[X, Y].type == 7 || Main.tile[X, Y].type == 8 || Main.tile[X, Y].type == 9 || Main.tile[X, Y].type == 221 || Main.tile[X, Y].type == 222 || Main.tile[X, Y].type == 223 || Main.tile[X, Y].type == 204 || Main.tile[X, Y].type == 166 || Main.tile[X, Y].type == 167 || Main.tile[X, Y].type == 168 || Main.tile[X, Y].type == 169 || Main.tile[X, Y].type == 221 || Main.tile[X, Y].type == 107 || Main.tile[X, Y].type == 108 || Main.tile[X, Y].type == 22 || Main.tile[X, Y].type == 111 || Main.tile[X, Y].type == 123 || Main.tile[X, Y].type == 224 || Main.tile[X, Y].type == 40 || Main.tile[X, Y].type == 59)
                                {
                                    Main.tile[X, Y].type = (ushort)mod.TileType("DreamOre");
                                }
                            }
                        }
                    }
                    for (int k = 0; k < 1000; k++)
                    {
                        int PositionX = WorldGen.genRand.Next(0, Main.maxTilesX);
                        int PositionY = WorldGen.genRand.Next(0, Main.maxTilesY);
                        if (Main.tile[PositionX, PositionY].type == 249)
                        {
                            WorldGen.TileRunner(PositionX, PositionY, WorldGen.genRand.Next(2, 8), WorldGen.genRand.Next(2, 8), mod.TileType("DreamOre"), false, 0f, 0f, false, true);
                        }
                    }
                    for (int k = 0; k < Main.maxTilesX; k++)
                    {
                        for (int i = 0; i < Main.maxTilesY; i++)
                        {
                            if (Main.tile[k, i].type == 249)
                            {
                                if (Main.tile[k + 1, i].active() && Main.tile[k, i - 1].active() && Main.tile[k - 1, i].active() && Main.tile[k, i + 1].active())
                                {
                                }
                                else
                                {
                                    Main.tile[k, i].type = 249;
                                }
                            }
                        }
                    }

                    while (!Main.tile[StartX, StartY].active() && StartY < Main.worldSurface)
                    {
                        StartY++;
                    }
                    for (int k = 0; k < 16; k++)
                    {
                        for (int l = 0; l < 10; l++)
                        {
                            WorldGen.KillTile(StartX - k, StartY - l, false, false, true);
                        }
                    }
                    for (int k = 0; k < 14; k++)
                    {
                        for (int l = 0; l < 8; l++)
                        {
                            WorldGen.KillWall(StartX - 1 - k, StartY - 1 - l, false);
                            WorldGen.PlaceWall(StartX - 1 - k, StartY - 1 - l, 110);
                        }
                    }
                    for (int k = 0; k < 15; k++)
                        WorldGen.PlaceTile(StartX - k, StartY, 371);
                    for (int l = 0; l < 9; l++)
                        WorldGen.PlaceTile(StartX, StartY - l, 371);
                    for (int l = 0; l < 9; l++)
                        WorldGen.PlaceTile(StartX - 15, StartY - l, 371);
                    for (int k = 0; k < 3; k++)
                        WorldGen.PlaceTile(StartX - k, StartY - 4, 371);
                    for (int k = 0; k < 3; k++)
                        WorldGen.PlaceTile(StartX - 15 + k, StartY - 4, 371);
                    for (int k = 0; k < 5; k++)
                        WorldGen.PlaceTile(StartX - 6 - k, StartY - 4, 371);
                    for (int l = 0; l < 2; l++)
                        WorldGen.PlaceTile(StartX - 2, StartY - 7 - l, 371);
                    for (int l = 0; l < 2; l++)
                        WorldGen.PlaceTile(StartX - 3, StartY - 8 - l, 371);
                    for (int k = 0; k < 3; k++)
                        WorldGen.PlaceTile(StartX - 4 - k, StartY - 9, 371);
                    for (int l = 0; l < 2; l++)
                        WorldGen.PlaceTile(StartX - 14, StartY - 7 - l, 371);
                    for (int l = 0; l < 2; l++)
                        WorldGen.PlaceTile(StartX - 13, StartY - 8 - l, 371);
                    for (int k = 0; k < 3; k++)
                        WorldGen.PlaceTile(StartX - 12 + k, StartY - 9, 371);
                    WorldGen.PlaceTile(StartX + 1, StartY - 4, 371);
                    WorldGen.PlaceTile(StartX - 16, StartY - 4, 371);
                    WorldGen.PlaceChest(StartX - 13, StartY - 5, 390, false, 2);
                    WorldGen.PlaceChest(StartX - 7, StartY - 5, 390, false, 2);
                    //----------------
                    StartX = StartPositionX - 42;
                    StartY = StartPositionY - 21;
                    for (int k = 0; k < 16; k++)
                    {
                        for (int l = 0; l < 10; l++)
                        {
                            WorldGen.KillTile(StartX - k, StartY - l, false, false, true);
                        }
                    }
                    for (int k = 0; k < 14; k++)
                    {
                        for (int l = 0; l < 8; l++)
                        {
                            WorldGen.KillWall(StartX - 1 - k, StartY - 1 - l, false);
                            WorldGen.PlaceWall(StartX - 1 - k, StartY - 1 - l, 110);
                        }
                    }
                    for (int k = 0; k < 15; k++)
                        WorldGen.PlaceTile(StartX - k, StartY, 371);
                    for (int l = 0; l < 9; l++)
                        WorldGen.PlaceTile(StartX, StartY - l, 371);
                    for (int l = 0; l < 9; l++)
                        WorldGen.PlaceTile(StartX - 15, StartY - l, 371);
                    for (int k = 0; k < 3; k++)
                        WorldGen.PlaceTile(StartX - k, StartY - 4, 342);
                    for (int k = 0; k < 3; k++)
                        WorldGen.PlaceTile(StartX - 15 + k, StartY - 4, 342);
                    for (int k = 0; k < 5; k++)
                        WorldGen.PlaceTile(StartX - 6 - k, StartY - 4, 342);
                    for (int l = 0; l < 2; l++)
                        WorldGen.PlaceTile(StartX - 2, StartY - 7 - l, 342);
                    for (int l = 0; l < 2; l++)
                        WorldGen.PlaceTile(StartX - 3, StartY - 8 - l, 342);
                    for (int k = 0; k < 3; k++)
                        WorldGen.PlaceTile(StartX - 4 - k, StartY - 9, 342);
                    for (int l = 0; l < 2; l++)
                        WorldGen.PlaceTile(StartX - 14, StartY - 7 - l, 342);
                    for (int l = 0; l < 2; l++)
                        WorldGen.PlaceTile(StartX - 13, StartY - 8 - l, 342);
                    for (int k = 0; k < 3; k++)
                        WorldGen.PlaceTile(StartX - 12 + k, StartY - 9, 342);
                    WorldGen.PlaceTile(StartX + 1, StartY - 4, 342);
                    WorldGen.PlaceTile(StartX - 16, StartY - 4, 342);
                    WorldGen.PlaceChest(StartX - 13, StartY - 5, 390, false, 2);
                    WorldGen.PlaceChest(StartX - 7, StartY - 5, 390, false, 2);
                    //-------------------------
                    StartX = StartPositionX - 120;
                    StartY = StartPositionY + 50;
                    for (int k = 0; k < 16; k++)
                    {
                        for (int l = 0; l < 10; l++)
                        {
                            WorldGen.KillTile(StartX - k, StartY - l, false, false, true);
                        }
                    }
                    for (int k = 0; k < 14; k++)
                    {
                        for (int l = 0; l < 8; l++)
                        {
                            WorldGen.KillWall(StartX - 1 - k, StartY - 1 - l, false);
                            WorldGen.PlaceWall(StartX - 1 - k, StartY - 1 - l, 110);
                        }
                    }
                    for (int k = 0; k < 15; k++)
                        WorldGen.PlaceTile(StartX - k, StartY, 342);
                    for (int l = 0; l < 9; l++)
                        WorldGen.PlaceTile(StartX, StartY - l, 342);
                    for (int l = 0; l < 9; l++)
                        WorldGen.PlaceTile(StartX - 15, StartY - l, 342);
                    for (int k = 0; k < 3; k++)
                        WorldGen.PlaceTile(StartX - k, StartY - 4, 342);
                    for (int k = 0; k < 3; k++)
                        WorldGen.PlaceTile(StartX - 15 + k, StartY - 4, 342);
                    for (int k = 0; k < 5; k++)
                        WorldGen.PlaceTile(StartX - 6 - k, StartY - 4, 342);
                    for (int l = 0; l < 2; l++)
                        WorldGen.PlaceTile(StartX - 2, StartY - 7 - l, 342);
                    for (int l = 0; l < 2; l++)
                        WorldGen.PlaceTile(StartX - 3, StartY - 8 - l, 342);
                    for (int k = 0; k < 3; k++)
                        WorldGen.PlaceTile(StartX - 4 - k, StartY - 9, 342);
                    for (int l = 0; l < 2; l++)
                        WorldGen.PlaceTile(StartX - 14, StartY - 7 - l, 342);
                    for (int l = 0; l < 2; l++)
                        WorldGen.PlaceTile(StartX - 13, StartY - 8 - l, 342);
                    for (int k = 0; k < 3; k++)
                        WorldGen.PlaceTile(StartX - 12 + k, StartY - 9, 342);
                    WorldGen.PlaceTile(StartX + 1, StartY - 4, 342);
                    WorldGen.PlaceTile(StartX - 16, StartY - 4, 342);
                    WorldGen.PlaceChest(StartX - 13, StartY - 5, 390, false, 2);
                    WorldGen.PlaceChest(StartX - 7, StartY - 5, 390, false, 2);
                }
                else
                    goto IL_19;
            }));

            int IglooIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Living Trees"));
            if (IglooIndex != -1)
            {
                tasks.Insert(IglooIndex + 1, new PassLegacy("Post Terrain", delegate (GenerationProgress progress)
                {
                    progress.Message = "Creating Igloo's..";
                    MakeIgloo();
                }));
            }
        }

        private void MakeIgloo()
        {
            float widthScale = (Main.maxTilesX / 4200f); //something about floating numbers
            int numberToGenerate = WorldGen.genRand.Next(1, (int)(2f * widthScale));
            for (int k = 0; k < numberToGenerate; k++)
            {
                bool success = false;
                int attempts = 0;
                while (!success)
                {
                    attempts++;
                    if (attempts > 1000)
                    {
                        success = true;
                        continue;
                    }
                    int i = WorldGen.genRand.Next(300, Main.maxTilesX - 300);
                    if (i <= Main.maxTilesX / 2 - 50 || i >= Main.maxTilesX / 2 + 50)
                    {
                        int j = 0;
                        while (!Main.tile[i, j].active() && (double)j < Main.worldSurface)
                        {
                            j++;
                        }
                        if (Main.tile[i, j].type == TileID.SnowBlock)  //spawn on type of tile
                        {
                            j--;
                            if (j > 150)
                            {
                                bool placementOK = true;
                                for (int l = i - 4; l < i + 4; l++)
                                {
                                    for (int m = j - 6; m < j + 20; m++) //i don't know what this line does
                                    {
                                        if (Main.tile[l, m].active())
                                        {
                                            int type = (int)Main.tile[l, m].type;
                                            if (type == TileID.BlueDungeonBrick || type == TileID.GreenDungeonBrick || type == TileID.PinkDungeonBrick || type == TileID.Cloud || type == TileID.RainCloud)
                                            {
                                                placementOK = false;
                                            }
                                        }
                                    }
                                }
                                if (placementOK)
                                {
                                    success = PlaceWell(i, j);
                                }
                            }
                        }
                    }
                }
            }
        }

        int[,] wellshape = new int[,]
        {
            {0,0,0,0,0,0,1,1,1,1,1,1,1,0,0,0,0,0 },
            {0,0,0,0,1,1,5,5,5,5,5,5,5,1,1,0,0,0 },
            {0,0,0,1,1,5,5,5,5,5,5,5,5,5,1,1,0,0 },
            {0,0,0,1,5,5,5,5,5,5,5,5,5,5,5,1,1,0 },
            {1,1,1,5,5,5,5,5,5,5,5,5,5,5,5,1,1,0 },
            {5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,1,0  },
            {5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,1  }, //trying to put a door here
            {5,5,5,5,5,5,5,5,6,6,6,5,5,5,5,5,5,1 },
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },

        };



        int[,] wellshapeWall = new int[,]
        {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,1,1,1,1,1,1,1,0,0,0,0,0 },
            {0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,0 },
            {0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0 },
            {0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0 },
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },


        };

        int[,] wellshapeWater = new int[,]
        {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },

        };

        public bool PlaceWell(int i, int j)
        {
            if (!WorldGen.SolidTile(i, j + 1))
            {
                return false;
            }
            if (Main.tile[i, j].active())
            {
                return false;
            }
            if (j < 150)
            {
                return false;
            }



            for (int y = 0; y < wellshape.GetLength(0); y++)
            {
                for (int x = 0; x < wellshape.GetLength(1); x++)
                {
                    int k = i - 3 + x;
                    int l = j - 6 + y;

                    if (WorldGen.InWorld(k, l, 30))
                        WorldGen.PlaceTile(k + -1, l + 2, 10, true, false, 0, 4); //placing the door

                    if (WorldGen.InWorld(k, l, 30))
                    {
                        Tile tile = Framing.GetTileSafely(k, l);
                        switch (wellshape[y, x])
                        {
                            case 1:
                                tile.type = TileID.SnowBrick;  //roof
                                tile.active(true);
                                break;
                            case 2:
                                tile.type = TileID.SnowBrick;  //base edge
                                tile.active(true);
                                tile.halfBrick(true);
                                break;
                            case 3:
                                tile.type = TileID.SnowBrick;  //left slant
                                tile.active(true);
                                tile.slope(2);  //to get the correct slope shader
                                break;
                            case 4:
                                tile.type = TileID.SnowBrick;  //right slant
                                tile.active(true);
                                tile.slope(1);
                                break;
                            case 5:
                                tile.active(false);       //nothing here
                                break;
                            case 6:
                                tile.type = TileID.Campfire;
                                tile.active(true);
                                break;


                        }

                        switch (wellshapeWall[y, x])
                        {
                            case 1:
                                tile.wall = WallID.SnowBrick;    //wall of well
                                break;
                        }
                        switch (wellshapeWater[y, x])
                        {
                            case 1:
                                tile.liquid = 255; //fills with corresponding biome liquid
                                break;
                        }
                    }
                }
            }
            return true;
        }

        public static bool PlaceIceChest(int x, int y, ushort type = 21, bool notNearOtherChests = false, int style = 0)
        {
            int num = -1;
            TileObject toBePlaced;
            if (TileObject.CanPlace(x, y, type, style, 1, out toBePlaced, false))
            {
                bool flag = true;
                if (notNearOtherChests && Chest.NearOtherChests(x - 1, y - 1))
                {
                    flag = false;
                }
                if (flag)
                {
                    TileObject.Place(toBePlaced);
                    num = Chest.CreateChest(toBePlaced.xCoord, toBePlaced.yCoord, -1);
                }
            }
            else
            {
                num = -1;
            }
            // if (num != -1 && Main.netMode == 1)
            // {
            //     NetMessage.SendData(34, -1, -1, "", 0, (float)x, (float)y, (float)style, 0, 0, 0);
            // }
            return true;
        }

        public override void PostWorldGen()
        {
            for (int i = 0; i < Main.maxTilesX; i++)
            {
                Main.tile[i, Main.maxTilesY / 2].type = TileID.Chlorophyte;
            }
            int num = NPC.NewNPC((Main.spawnTileX + 5) * 16, Main.spawnTileY * 16, mod.NPCType("BananaMan"), 0, 0f, 0f, 0f, 0f, 255);
            Main.npc[num].homeTileX = Main.spawnTileX + 5;
            Main.npc[num].homeTileY = Main.spawnTileY;
            Main.npc[num].direction = 1;
            Main.npc[num].homeless = true;
            // Place some items in Ice Chests
            int[] itemsToPlaceInWaterChests = new int[] { mod.ItemType("ClamItem"), mod.ItemType("Pearl"), ItemID.PinkJellyfishJar };
            int itemsToPlaceInWaterChestsChoice = 0;
            for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
            {
                Chest chest = Main.chest[chestIndex];
                if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 11 * 36)
                {
                    for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                    {
                        if (chest.item[inventoryIndex].type == 0)
                        {
                            chest.item[inventoryIndex].SetDefaults(itemsToPlaceInWaterChests[itemsToPlaceInWaterChestsChoice]);
                            itemsToPlaceInWaterChestsChoice = (itemsToPlaceInWaterChestsChoice + 1) % itemsToPlaceInWaterChests.Length;
                            break;
                        }
                    }
                }
            }
        }

        public override void ResetNearbyTileEffects()
        {
            MyPlayer modPlayer = Main.LocalPlayer.GetModPlayer<MyPlayer>(mod);
            exampleTiles = 0;
    }
    public override void TileCountsAvailable(int[] tileCounts)
    {
        exampleTiles = tileCounts[TileID.BubblegumBlock];
    }
}
}