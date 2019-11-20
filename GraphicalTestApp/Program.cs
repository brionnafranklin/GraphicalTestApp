﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(1280, 760, "Graphical Test Application");

            Actor root = new Actor();
            game.Root = root;

            //## Set up game here ##//
            //set up player 1 tank
            Tank player1 = new Tank(100, 100, 1);
            Sprite p1Sprite = new Sprite("tankBody_blue.png");
            AABB p1Hitbox = new AABB(p1Sprite.Height, p1Sprite.Width);
            Barrel p1Barrel = new Barrel();
            root.AddChild(player1);
            player1.AddChild(p1Sprite);
            player1.AddChild(p1Hitbox);
            player1.AddChild(p1Barrel);

            //set up player 2 tank
            Tank player2 = new Tank(1120, 660, 2);
            Sprite p2Sprite = new Sprite("tankBody_red.png");
            AABB p2Hitbox = new AABB(p2Sprite.Height, p2Sprite.Width);
            Barrel p2Barrel = new Barrel();
            root.AddChild(player2);
            player2.AddChild(p2Sprite);
            player2.AddChild(p2Hitbox);
            player2.AddChild(p2Barrel);

            game.Run();
        }
    }
}
