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
        public FlxSprite hero;
        private BattleUI battleUI;
        private MessageBox messageBox;


        override public void create()
        {
            base.create();
            Registry.levelSize = Registry.getLevelSize();

            FlxG.elapsedTotal = 0;

            add(SpriteFactory.createCave());

            hero = SpriteFactory.createSprite(new Dictionary<string, string> { { "Name", "CharacterPlayerControlled" }, 
            { "x", (((int)Registry.levelSize.X * Registry.tileSize) / 2).ToString() }, { "y", (((int)Registry.levelSize.X * Registry.tileSize) / 2).ToString() } });

            createStaircase();

            
            enemies = new FlxGroup();
            addRandomObjects(5 * Registry.levelNumber, "CharacterComputerControlled", enemies);
            add(enemies);

            pickups = new FlxGroup();
            addRandomObjects(55, "PickUp", pickups);
            add(pickups);


            add(hero);

            FlxG.follow(hero, 9);
            FlxG.followBounds(0, 0, (int)Registry.levelSize.X * Registry.tileSize, (int)Registry.levelSize.Y * Registry.tileSize);

            //FlxG.showBounds = true;
            //add(SpriteFactory.createTileblock(new Dictionary<string, string> { { "Name", "UIBox" }, { "x", "10" }, { "y", "10" }, { "width", "64" }, { "height", "32" } }));

            add(SpriteFactory.createSprite(new Dictionary<string, string> { { "Name", "MoveCounter" }, { "x", "-1" }, { "y", "-1" } }));

            add(battleUI = new BattleUI());


            add(messageBox = new MessageBox());

        }

        public void createStaircase()
        {
            Vector2 randomSpot = Registry.levelAsTilemap.getRandomTilePositionWithType(Registry.levelAsTilemap.remapGuide[15]);
            Registry.levelAsTilemap.setTile((int)randomSpot.X / Registry.tileSize, (int)randomSpot.Y / Registry.tileSize, 66);
            
            Vector2 directions = new Vector2((int)randomSpot.X / Registry.tileSize, (int)randomSpot.Y / Registry.tileSize);
            Vector2 playerPos = new Vector2((int)hero.x / Registry.tileSize, (int)hero.y / Registry.tileSize);
            Vector2 toGetTo = playerPos - directions;
            string dirX = "left";
            string dirY = "up";
            if (toGetTo.X < 0) dirX = "right";
            if (toGetTo.X < 0) dirY = "down";
            Console.WriteLine("Created stair case at: {0} {1} to get there go {2} {4} {3} {5}", directions.X, directions.Y, toGetTo.X, toGetTo.Y, dirX,dirY);

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
            if (Registry.movesRemaining <= 0)
            {
                messageBox.visible = true;
                messageBox.setText("No Moves Remaining\nBuy more moves\n25 for $0.99\n99 more only $1.99");
            }

            //FlxU.overlap(hero, pickups, overlapped);
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
