using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using org.flixel;
using Microsoft.Xna.Framework;

namespace NinetyNineMoves
{
    public class Registry
    {
        //public static Dictionary<string, string> boxes;

        public static List<Dictionary<string, string>> boxes = new List<Dictionary<string, string>>();
        public static FlxMidi midi;

        public static FlxTilemap levelAsTilemap;
        public static int movesRemaining = 99;

        public static Vector2 levelSize = new Vector2(50,50);
        public static int levelNumber = 1;

        public static int levelsPerWorld = 4;
        public static int tileSize = 24;


        /// <summary>
        /// Used to shut down play while battle event takes place.
        /// </summary>
        public static bool canMove=true;

        public Registry()
        {
            //midi = new FlxMidi();

        }

        public static Vector2 getLevelSize()
        {
            return new Vector2(50, 50);

        }

        public static Dictionary<int, int[]> createAltTileRemap()
        {
            //295,301,296,304,299,300,302,300,298,305,297,297,303,300,297,291
            //295,303,305,304,304,300,302,300,302,305,297,297,303,300,297,291

            Dictionary<int, int[]> remapGuide = new Dictionary<int, int[]>();

            remapGuide.Add(0, convertTilesForLevel(new int[] { 67 }));
            remapGuide.Add(1, convertTilesForLevel(new int[] { 75 }));
            remapGuide.Add(2, convertTilesForLevel(new int[] { 77 }));
            remapGuide.Add(3, convertTilesForLevel(new int[] { 76 }));
            remapGuide.Add(4, convertTilesForLevel(new int[] { 76 }));
            remapGuide.Add(5, convertTilesForLevel(new int[] { 72,83 }));
            remapGuide.Add(6, convertTilesForLevel(new int[] { 74 }) );
            remapGuide.Add(7, convertTilesForLevel(new int[] { 72, 83 }));
            remapGuide.Add(8, convertTilesForLevel(new int[] { 74 }));
            remapGuide.Add(9, convertTilesForLevel(new int[] { 77 }));
            remapGuide.Add(10, convertTilesForLevel(new int[] { 69, 84 }));
            remapGuide.Add(11, convertTilesForLevel(new int[] { 69, 84 }));
            remapGuide.Add(12, convertTilesForLevel(new int[] { 75 }));
            remapGuide.Add(13, convertTilesForLevel(new int[] { 72, 83}));
            remapGuide.Add(14, convertTilesForLevel(new int[] { 69,84 }));
            remapGuide.Add(15, convertTilesForLevel(new int[] { 63, 61, 62, 63, 64 }));
            remapGuide.Add(-1, convertTilesForLevel(new int[] { 63, 61, 62, 63, 64 })); 

            return remapGuide;
        }
        public static int getTileForLevel(int Tile)
        {
            int offset = (Registry.levelNumber-1) * 57;
            int newTile = Tile + offset;
            return newTile;
        }
        public static int[] convertTilesForLevel(int[] Tiles)
        {
            int[] newTiles = new int[Tiles.Length];

            int offset = (Registry.levelNumber - 1) * 57;

            for (int i = 0; i < Tiles.Length; i++)
			{
			    int newTile = Tiles[i] + offset;
                newTiles[i] = newTile;
			}
            
            return newTiles;
        }
    }
}
