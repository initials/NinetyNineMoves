#region File Description
//-----------------------------------------------------------------------------
// Flixel for XNA.
// Original repo : https://github.com/StAidan/X-flixel
// Extended and edited repo : https://github.com/initials/XNAMode
//-----------------------------------------------------------------------------
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using org.flixel;
using Microsoft.Xna.Framework;
using NinetyNineMoves;

namespace Loader_NinetyNineMoves
{
    /// <summary>
    /// Flixel enters here.
    /// <code>FlxFactory</code> refers to it as the "masterclass".
    /// </summary>
    public class FlixelEntryPoint2 : FlxGame
    {
        public FlixelEntryPoint2(Game game)
            : base(game)
        {
            ///Post build zipper
            ///cd ..
            ///C:\_Files\programs\7-Zip\7z a -tzip FourChambers.zip Release\ -r

            int w = FlxG.resolutionWidth / FlxG.zoom;
            int h = FlxG.resolutionHeight / FlxG.zoom;
            string buildType = "FULL";

            Registry reg = new Registry();

            initGame(w, h, new NinetyNineMoves.PlayState(), new Color(15, 15, 15), true, new Color(5, 5, 5));

            FlxG.debug = false;
            FlxG.level = -1;

#if DEBUG
            FlxG.debug = true;
            buildType = "DEBUG";
#endif

            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"version.txt"))
            {
                file.WriteLine(typeof(FlxFactory).Assembly.GetName().Version);
            }

            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"buildType.txt"))
            {
                file.WriteLine(buildType);
            }
        }
    }
}
