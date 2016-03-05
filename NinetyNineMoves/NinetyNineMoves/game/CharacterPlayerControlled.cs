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
    class CharacterPlayerControlled : Character
    {
        /// <summary>
        /// A temporary bool to determine if the sprite is ready.
        /// </summary>
        private bool _ready;

        /// <summary>
        /// Sprite Constructor
        /// </summary>
        /// <param name="xPos"></param>
        /// <param name="yPos"></param>
        public CharacterPlayerControlled(int xPos, int yPos)
            : base(xPos, yPos)
        {
            loadGraphic("characters/oryx_16bit_fantasy_creatures_trans", true, false, 24, 24);
            
            //int c = FlxU.randomInt(21, 29);
            int c = 32;

            addAnimation("idle", new int[] { c, (c + 20) }, FlxU.randomInt(2, 6), true);

            play("idle");
        }

        public override void move()
        {
            if (!tween.Playing && Registry.movesRemaining>=1)
            {
                if (FlxControl.DOWN)
                {
                    int tileDown = Registry.levelAsTilemap.getTile((int)((x + 12) / 24), (int)((y + 36) / 24));
                    int[] empties = Registry.levelAsTilemap.remapGuide[15];

                    if (empties.Contains(tileDown))
                    {
                        moveDown();
                        Registry.movesRemaining--;

                    }
                }
                if (FlxControl.UP)
                {
                    int tileDown = Registry.levelAsTilemap.getTile((int)((x + 12) / 24), (int)((y - 12) / 24));
                    int[] empties = Registry.levelAsTilemap.remapGuide[15];
                    if (empties.Contains(tileDown))
                    {
                        moveUp();
                        Registry.movesRemaining--;

                    }
                }
                if (FlxControl.LEFT)
                {
                    int tileDown = Registry.levelAsTilemap.getTile((int)((x - 12) / 24), (int)((y + 12) / 24));
                    int[] empties = Registry.levelAsTilemap.remapGuide[15];

                    if (empties.Contains(tileDown))
                    {
                        facing = Flx2DFacing.Right;

                        moveLeft();
                        Registry.movesRemaining--;

                    }
                }
                if (FlxControl.RIGHT)
                {
                    int tileDown = Registry.levelAsTilemap.getTile((int)((x + 36) / 24), (int)((y + 12) / 24));
                    int[] empties = Registry.levelAsTilemap.remapGuide[15];

                    if (empties.Contains(tileDown))
                    {
                        facing = Flx2DFacing.Left;

                        moveRight();
                        Registry.movesRemaining--;

                    }
                }
            }

            base.move();
        }

        /// <summary>
        /// The Update Cycle. Called once every cycle.
        /// </summary>
        override public void update()
        {
            base.update();
        }

        /// <summary>
        /// The render code. Add any additional render code here.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void render(SpriteBatch spriteBatch)
        {
            base.render(spriteBatch);
        }

        /// <summary>
        /// Called when the sprite hit something on its bottom edge.
        /// </summary>
        /// <param name="Contact">The Object that it collided with.</param>
        /// <param name="Velocity">The Velocity that is will now have???</param>
        public override void hitBottom(FlxObject Contact, float Velocity)
        {
            base.hitBottom(Contact, Velocity);
        }

        /// <summary>
        /// Called when the sprite hits something on its left side.
        /// </summary>
        /// <param name="Contact">The Object that it collided with.</param>
        /// <param name="Velocity"></param>
        public override void hitLeft(FlxObject Contact, float Velocity)
        {
            base.hitLeft(Contact, Velocity);
        }

        /// <summary>
        /// Called when the sprite hits something on its right side
        /// </summary>
        /// <param name="Contact"></param>
        /// <param name="Velocity"></param>
        public override void hitRight(FlxObject Contact, float Velocity)
        {
            base.hitRight(Contact, Velocity);
        }

        /// <summary>
        /// Called when the sprite hits something on its side, either left or right.
        /// </summary>
        /// <param name="Contact"></param>
        /// <param name="Velocity"></param>
        public override void hitSide(FlxObject Contact, float Velocity)
        {
            base.hitSide(Contact, Velocity);
        }

        /// <summary>
        /// Called when the sprite hits something on its top
        /// </summary>
        /// <param name="Contact"></param>
        /// <param name="Velocity"></param>
        public override void hitTop(FlxObject Contact, float Velocity)
        {
            base.hitTop(Contact, Velocity);
        }

        /// <summary>
        /// Used when the sprite is damaged or hurt. Takes points off "Health".
        /// </summary>
        /// <param name="Damage">Amount of damage to take away.</param>
        public override void hurt(float Damage)
        {
            base.hurt(Damage);
        }

        /// <summary>
        /// Kill the sprite.
        /// </summary>
        public override void kill()
        {
            base.kill();
        }
    }
}
