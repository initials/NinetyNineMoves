using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using org.flixel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NinetyNineMoves
{
    public class SpriteFactory
    {
        public SpriteFactory()
        {

        }

        public static FlxSprite createObject(string Name, int x, int y)
        {
            string namePass = "NinetyNineMoves." + Name;
            var typ = Type.GetType(namePass);
            var newSprite = (FlxSprite)Activator.CreateInstance(typ, x, y);
            return newSprite;
        }



        public static FlxSprite createTileblock(Dictionary<string, string> SpriteInfo)
        {
            string namePass = "NinetyNineMoves." + SpriteInfo["Name"];
            var typ = Type.GetType(namePass);

            var myObject = (FlxSprite)Activator.CreateInstance(typ,
                Convert.ToInt32(SpriteInfo["x"]),
                Convert.ToInt32(SpriteInfo["y"]),
                Convert.ToInt32(SpriteInfo["width"]),
                Convert.ToInt32(SpriteInfo["height"]));
            return myObject;

        }

        public static FlxSprite createSprite(Dictionary<string, string> SpriteInfo)
        {
            string namePass = "NinetyNineMoves." + SpriteInfo["Name"];
            var typ = Type.GetType(namePass);

            var myObject = (FlxSprite)Activator.CreateInstance(typ,
                Convert.ToInt32(SpriteInfo["x"]),
                Convert.ToInt32(SpriteInfo["y"]));
            return myObject;
        }
        public static FlxTilemap createCave()
        {
            FlxCaveGenerator cav = new FlxCaveGenerator((int)Registry.levelSize.X, (int)Registry.levelSize.Y, 0.55f, 30);
            
            int[,] matr = cav.generateCaveLevel(null, null, null, null, null, null, null, null);

            matr = cav.editRectangle(matr, 0, (int)Registry.levelSize.Y / 2, (int)Registry.levelSize.X, 4, 1);
            matr = cav.editRectangle(matr, (int)Registry.levelSize.X / 2, 0, 4, (int)Registry.levelSize.Y, 1);

            matr = cav.grow(matr);

            matr = cav.editRectangle(matr, 0, 0, (int)Registry.levelSize.X, 1, 0);
            matr = cav.editRectangle(matr, 0, 0, 1, (int)Registry.levelSize.Y, 0);

            matr = cav.editRectangle(matr, 0, (int)Registry.levelSize.Y-1, (int)Registry.levelSize.X, 1, 0);
            matr = cav.editRectangle(matr, (int)Registry.levelSize.X-1, 0, 1, (int)Registry.levelSize.Y, 0);

            string newMap = cav.convertMultiArrayToString(matr);

            FlxTilemap tiles = new FlxTilemap();
            // Remap guide before loading map
            tiles.remapGuide = Registry.createAltTileRemap();
            tiles.auto = FlxTilemap.REMAPALT;
            tiles.loadMap(newMap, FlxG.Content.Load<Texture2D>("tiles/oryx_16bit_fantasy_world_trans"), Registry.tileSize, Registry.tileSize);

            tiles.setScrollFactors(1, 1);

            Registry.levelAsTilemap = tiles;

            return tiles;

        }
    }
}
