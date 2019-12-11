using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    //the basic program that calls the necessities for the game
    class Program
    {
        //calls and sets up all the basics that are needed for the game to run correctly
        static void Main(string[] args)
        {
            Game game = new Game(1280, 760, "Graphical Test Application");

            Actor root = new Actor();
            game.Root = root;

            PowerUpController powerUpController = new PowerUpController();
            root.AddChild(powerUpController);

            //set up player 1 tank
            Tank player1 = new Tank(100, 100, 1, "tankBody_blue.png", "tankBlue_barrel1_outline.png");
            Tank.PlayerList.Add(player1);
            root.AddChild(player1);

            //set up player 2 tank
            Tank player2 = new Tank(1180, 660, 2,"tankBody_red.png", "tankRed_barrel1_outline.png");
            Tank.PlayerList.Add(player2);
            root.AddChild(player2);

            game.Run();
        }
    }
}
