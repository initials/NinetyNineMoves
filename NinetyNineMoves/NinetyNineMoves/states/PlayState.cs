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
        private FlxGroup enemies;
        private FlxSprite hero;
        private BattleUI battleUI;

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

            enemies = new FlxGroup();
            addRandomObjects(55, "CharacterComputerControlled", enemies);
            add(enemies);

            pickups = new FlxGroup();
            addRandomObjects(55, "PickUp", pickups);
            add(pickups);

            //FlxG.showBounds = true;
            add(SpriteFactory.createTileblock(new Dictionary<string, string> { { "Name", "UIBox" }, { "x", "10" }, { "y", "10" }, { "width", "64" }, { "height", "32" } }));
            add(SpriteFactory.createSprite(new Dictionary<string, string> { { "Name", "MoveCounter" }, { "x", "-1" }, { "y", "-1" } }));

            add(battleUI = new BattleUI());
        }

        private void addRandomObjects(int NumberToAdd, string typeOfObject, FlxGroup group)
        {
            for (int i = 0; i < NumberToAdd; i++)
            {
                Vector2 randomSpot = Registry.levelAsTilemap.getRandomTilePositionWithType(Registry.levelAsTilemap.remapGuide[15]);
                if (group == null) add(SpriteFactory.createObject(typeOfObject, (int)randomSpot.X, (int)randomSpot.Y));
                else group.add(SpriteFactory.createObject(typeOfObject, (int)randomSpot.X, (int)randomSpot.Y));
            }
        }

        override public void update()
        {
            FlxU.overlap(hero, pickups, overlapped);
            FlxU.overlap(hero, enemies, overlapEnemy);

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
        protected bool overlapEnemy(object Sender, FlxSpriteCollisionEvent e)
        {
            battleUI.startBattle(((FlxSprite)(e.Object2)), ((FlxSprite)(e.Object1)));
            return true;
        }
    }
}
