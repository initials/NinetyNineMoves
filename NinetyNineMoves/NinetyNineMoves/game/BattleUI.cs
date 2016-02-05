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
    class BattleUI : FlxGroup
    {
        private FlxGroup keys;
        private FlxSprite battleTarget;
        private FlxSprite battlePlayer;
        private UIBox box;
        private Tweener targetTweener;
        private Tweener playerTweener;
        private int[] directions;

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

            playerTweener = new Tweener(0, box.x, 1.0f, Circular.EaseOut);
            playerTweener.Start();

            targetTweener = new Tweener(FlxG.width, box.x + box.width, 0.9f, Circular.EaseOut);
            targetTweener.Start();

            directions = new int[] { FlxHud.Keyboard_Arrow_Down, FlxHud.Keyboard_Arrow_Up, FlxHud.Keyboard_Arrow_Left, FlxHud.Keyboard_Arrow_Right};

        }

        /// <summary>
        /// The Update Cycle. Called once every cycle.
        /// </summary>
        override public void update()
        {
            if (visible)
            {
                if (FlxG.keys.justPressed(Keys.Down) && ((FlxSprite)(keys.getFirstExtant())).frame==directions[0])
                {
                    keys.getFirstExtant().kill();
                }
                else if (FlxG.keys.justPressed(Keys.Up) && ((FlxSprite)(keys.getFirstExtant())).frame == directions[1])
                {
                    keys.getFirstExtant().kill();
                }
                else if (FlxG.keys.justPressed(Keys.Left) && ((FlxSprite)(keys.getFirstExtant())).frame == directions[2])
                {
                    keys.getFirstExtant().kill();
                }
                else if (FlxG.keys.justPressed(Keys.Right) && ((FlxSprite)(keys.getFirstExtant())).frame == directions[3])
                {
                    keys.getFirstExtant().kill();
                }


                if (keys.getFirstExtant() == null)
                {
                    this.endBattle();
                }
            }
            playerTweener.Update(FlxG.elapsedAsGameTime);
            targetTweener.Update(FlxG.elapsedAsGameTime);

            base.update();
        }

        public override void render(SpriteBatch spriteBatch)
        {

            base.render(spriteBatch);

            renderWithOffset(spriteBatch, battleTarget, targetTweener.Position, box.y + (box.height / 2), 6);
            renderWithOffset(spriteBatch, battlePlayer, playerTweener.Position, box.y + (box.height / 2), 6);
        
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
            battleTarget.facing = Flx2DFacing.Right;
            
            for (int i = 0; i < 4; i++)
            {
                FlxSprite x;
                keys.add(x = new FlxSprite(box.x + (i * 75), box.y).loadGraphic("flixel/buttons/MapWhite", true, false, 100, 100));
                x.frame = directions[FlxU.randomInt(0,3)];

                x.setScrollFactors(0, 0);
            }

            Console.WriteLine("Starting battle");
            visible = true;
            Registry.canMove = false;

            playerTweener.Reset();
            targetTweener.Reset();
            playerTweener.Start();
            targetTweener.Start();

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