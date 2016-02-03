using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using org.flixel;
using System.Linq;
using System.Xml.Linq;
using Midi;

namespace NinetyNineMoves
{
    public class PlayState : FlxState
    {
        private FlxGroup pickups;
        private FlxSprite hero;

        override public void create()
        {
            base.create();
            Registry.levelSize = new Vector2(50, 50);

            FlxG.elapsedTotal = 0;

            add(SpriteFactory.createCave());
            
            //create hero in middle

            hero = SpriteFactory.createSprite(new Dictionary<string, string> { { "Name", "CharacterPlayerControlled" }, { "x", (((int)Registry.levelSize.X * 24) / 2 ).ToString()}, { "y", (((int)Registry.levelSize.X * 24)/2).ToString() } });
            add(hero);

            FlxG.follow(hero, 9);
            FlxG.followBounds(0, 0, (int)Registry.levelSize.X * 24, (int)Registry.levelSize.Y * 24);

            add(SpriteFactory.createSprite(new Dictionary<string, string> { { "Name", "MoveCounter" }, { "x", (((int)Registry.levelSize.X * 24) / 2).ToString() }, { "y", (((int)Registry.levelSize.X * 24) / 2).ToString() } }));

            generateEnemies(55, "CharacterComputerControlled");

            pickups = new FlxGroup();

            generateEnemies(55, "PickUp");

            add(pickups);

            //FlxG.showBounds = true;

        }

        private void generateEnemies(int NumberOfEnemies, string TypeOfSprite)
        {
            for (int i = 0; i < NumberOfEnemies; i++)
            {
                int rx = FlxU.randomInt(1, Registry.levelSize.X);
                int ry = FlxU.randomInt(1, Registry.levelSize.Y);

                int rz = Registry.levelAsTilemap.getTile(rx, ry);

                int[] empties = Registry.levelAsTilemap.remapGuide[15];

                if (empties.Contains(rz))
                {
                    if (TypeOfSprite == "PickUp")
                    {
                        pickups.add(SpriteFactory.createSprite(new Dictionary<string, string> { { "Name",  TypeOfSprite}, 
                                { "x", (rx * 24).ToString() }, 
                                { "y", (ry * 24).ToString() } }));
                    }
                    else
                    {
                        add(SpriteFactory.createSprite(new Dictionary<string, string> { { "Name",  TypeOfSprite}, 
                                { "x", (rx * 24).ToString() }, 
                                { "y", (ry * 24).ToString() } }));
                    }
                }
            }
        }

        override public void update()
        {
            FlxU.overlap(hero, pickups, overlapped);

            base.update();

            if (FlxG.elapsedTotal> 1.0f)
            {
                if (FlxG.keys.justPressed(Keys.Enter))
                {
                    Registry.levelNumber++;

                    FlxG.state = new PlayState();
                    return;
                }
            }
        }

        protected bool overlapped(object Sender, FlxSpriteCollisionEvent e)
        {
            ((FlxObject)(e.Object1)).overlapped(e.Object2);
            ((FlxObject)(e.Object2)).overlapped(e.Object1);
            return true;
        }

    }
}
