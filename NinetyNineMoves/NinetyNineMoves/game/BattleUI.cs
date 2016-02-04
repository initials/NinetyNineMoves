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
    class BattleUI : FlxGroup
    {
        public BattleUI()
            : base()
        {
            UIBox box = new UIBox(0, 0, 320, 180);
            box.setScrollFactors(0, 0);
            add(box);

            FlxText t = new FlxText(0, 0, 320, "BATTLE");
            t.setScrollFactors(0, 0);
            add(t);

            visible = false;

            for (int i = 0; i < 4; i++)
            {
                FlxSprite x;
                add(x = new FlxSprite(i * 75, 10).loadGraphic("flixel/buttons/map360", true, false, 100, 100));
                x.frame = FlxHud.xboxButtonA;
                x.setScrollFactors(0, 0);
            }
        }

        /// <summary>
        /// The Update Cycle. Called once every cycle.
        /// </summary>
        override public void update()
        {
            base.update();
        }

        public void startBattle()
        {
            if (visible == true) return;
            Console.WriteLine("Starting battle");
            visible = true;
            Registry.canMove = false;
        }

        public void endBattle()
        {
            if (visible == false) return;
            Console.WriteLine("Starting battle");
            visible = false;
            Registry.canMove = true;
        }

        
    }
}