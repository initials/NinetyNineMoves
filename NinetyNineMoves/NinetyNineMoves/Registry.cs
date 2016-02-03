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

        public static Vector2 levelSize;
        public static int levelNumber = 1;

        public Registry()
        {
            //midi = new FlxMidi();

        }

        public static Dictionary<int, int> createAltTileRemap()
        {
            //0,  1,  2,  3,  
            //58 ,
            //115
            //295,301,296,304,299,300,302,300,298,305,297,297,303,300,297,291
            //295,303,305,304,304,300,302,300,302,305,297,297,303,300,297,291

            int offset = Registry.levelNumber * 57;

            Dictionary<int, int> remapGuide = new Dictionary<int, int>();

            remapGuide.Add(0, 295 + offset);
            remapGuide.Add(1, 303+ offset);
            remapGuide.Add(2, 305+ offset);
            remapGuide.Add(3, 304+ offset);
            remapGuide.Add(4, 304+ offset);
            remapGuide.Add(5, 300+ offset);
            remapGuide.Add(6, 302+ offset);
            remapGuide.Add(7, 300+ offset);
            remapGuide.Add(8, 302+ offset);
            remapGuide.Add(9, 305+ offset);
            remapGuide.Add(10, 297+ offset);
            remapGuide.Add(11, 297+ offset);
            remapGuide.Add(12, 303+ offset);
            remapGuide.Add(13, 300+ offset);
            remapGuide.Add(14, 297+ offset);
            remapGuide.Add(15, 291+ offset);
            remapGuide.Add(-1, 291+ offset);

            //remapGuide.Add(0, 295);
            //remapGuide.Add(1, 301);
            //remapGuide.Add(2, 296);
            //remapGuide.Add(3, 304);
            //remapGuide.Add(4, 299);
            //remapGuide.Add(5, 300);
            //remapGuide.Add(6, 302);
            //remapGuide.Add(7, 300);
            //remapGuide.Add(8, 298);
            //remapGuide.Add(9, 305);
            //remapGuide.Add(10, 297);
            //remapGuide.Add(11, 297);
            //remapGuide.Add(12, 303);
            //remapGuide.Add(13, 300);
            //remapGuide.Add(14, 297);
            //remapGuide.Add(15, 291);

            return remapGuide;
        }

    }
}
