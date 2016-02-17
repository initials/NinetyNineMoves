/*
 * Add these to Visual Studio to quickly create new FlxSprites
 */

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
    class KeyGroup : FlxGroup
    {
        public KeyGroup()
            : base()
        {

        }

        public FlxObject getFirstNonDyingSprite()
        {
            int i = 0;
            FlxObject o;
            int ml = members.Count;
            while (i < ml)
            {
                o = members[i++] as FlxObject;
                if ((o != null) && o.exists && !((Key)(o)).dying)
                    return o;
            }
            return null;
        }
    }
}
