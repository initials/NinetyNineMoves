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
        private FlxGroup keys;
        private FlxSprite battleTarget;
        private FlxSprite battlePlayer;
        private UIBox box;

        public BattleUI()
            : base()
        {

            int midX = (FlxG.width / 2) - (320 / 2);
            int midY = 10;


            box = new UIBox(midX, midY, 320, 180);
            box.setScrollFactors(0, 0);
            add(box);

            FlxText t = new FlxText(midX, midY, 320, "BATTLE");
            t.setScrollFactors(0, 0);
            add(t);

            visible = false;
            
            keys = new FlxGroup();
            add(keys);
        }

        /// <summary>
        /// The Update Cycle. Called once every cycle.
        /// </summary>
        override public void update()
        {
            if (FlxG.keys.justPressed(Keys.Down))
            {
                keys.getFirstExtant().kill();
            }
            if (keys.getFirstExtant() == null)
            {
                this.endBattle();
            }
            base.update();
        }

        public override void render(SpriteBatch spriteBatch)
        {

            base.render(spriteBatch);

            renderWithOffset(spriteBatch, battleTarget, box.x + box.width, box.y, 6);
            renderWithOffset(spriteBatch, battlePlayer, box.x,             box.y + battlePlayer.height / 2, 6);
        
        }

        private void renderWithOffset(SpriteBatch spriteBatch, FlxSprite obj, float localX, float localY, float localScale)
        {
            float oldX = obj.x;
            float oldY = obj.y;
            float oldScale = obj.scale;
            float oldScrollX = obj.scrollFactor.X;
            float oldScrollY = obj.scrollFactor.Y;

            obj.setScrollFactors(0, 0);
            obj.x = localX;
            obj.y = localY;
            obj.scale = localScale;
            obj.render(spriteBatch);

            obj.setScrollFactors(oldScrollX, oldScrollY);
            obj.x = oldX;
            obj.y = oldY;
            obj.scale = oldScale;
        }

        public void startBattle(FlxSprite BattleTarget, FlxSprite BattlePlayer)
        {
            if (visible == true) return;

            battleTarget = BattleTarget;
            battlePlayer = BattlePlayer;

            battlePlayer.facing = Flx2DFacing.Left;
            BattleTarget.facing = Flx2DFacing.Right;

            
            for (int i = 0; i < 4; i++)
            {
                FlxSprite x;
                keys.add(x = new FlxSprite(box.x + (i * 75), box.y).loadGraphic("flixel/buttons/map360", true, false, 100, 100));
                x.frame = FlxHud.xboxButtonA;
                x.setScrollFactors(0, 0);
            }

            Console.WriteLine("Starting battle");
            visible = true;
            Registry.canMove = false;
        }

        public void endBattle()
        {
            if (visible == false) return;
            Console.WriteLine("Ending battle");
            battleTarget.kill();
            visible = false;
            Registry.canMove = true;
        }

        
    }
}