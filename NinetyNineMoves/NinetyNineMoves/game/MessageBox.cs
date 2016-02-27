using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using org.flixel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using XNATweener;

namespace NinetyNineMoves
{
    class MessageBox : FlxGroup
    {
        private KeyGroup keys;
        private FlxText textBox;
        private UIBox box;

        public MessageBox()
            : base()
        {

            int midX = (FlxG.width / 2) - (320 / 2);
            int midY = 10;

            box = new UIBox(midX, midY, 320, 180);
            box.setScrollFactors(0, 0);
            add(box);

            textBox = new FlxText(midX+10, 20, 320, "");
            textBox.setFormat(null, 2, Color.White, FlxJustification.Left, Color.Black);
            textBox.setScrollFactors(0, 0);
            add(textBox);

            visible = false;

        }

        public void setText(string Text)
        {
            textBox.text = Text;
        }

        /// <summary>
        /// The Update Cycle. Called once every cycle.
        /// </summary>
        override public void update()
        {
            base.update();
        }

  
    }
}