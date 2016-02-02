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

        public static FlxTilemap level;
        public static int movesRemaining = 99;

        public static Vector2 levelSize;


        public Registry()
        {
            //midi = new FlxMidi();

        }

    }
}
