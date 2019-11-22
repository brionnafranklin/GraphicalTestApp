using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Barrel : Entity
    {
        //set on tank
        public Barrel(float x, float y) : base(x, y)
        {
            X = x;
            Y = y;
            Rotate((float)Math.PI);
        }

        public void Fire()
        {
            Bullet bullet = new Bullet(XAbsolute, YAbsolute);
            Sprite bulletSprite = new Sprite("bulletSand1_outline.png");
            this.Parent.Parent.AddChild(bullet);
            bullet.AddChild(bulletSprite);
        }

        //p1 barrel controls
        public void p1BarrelConrols(float deltaTime)
        {
            //q
            if (Input.IsKeyDown(81))
            {
                //rotate left
                Rotate((float)-Math.PI / 6 * deltaTime);
            }
            //e
            if (Input.IsKeyDown(69))
            {
                //rotate right
                Rotate((float)Math.PI / 6 * deltaTime);
            }
            //space
            if (Input.IsKeyPressed(32))
            {
                //shoot bullet
                Fire();
            }
        }

        //p2 barrel controls
        public void p2BarrelConrols(float deltaTime)
        {
            //7 keypad
            if (Input.IsKeyDown(327))
            {
                //rotate left
                Rotate((float)-Math.PI / 6 * deltaTime);
            }
            //9 keypad
            if (Input.IsKeyDown(329))
            {
                //rotate right
                Rotate((float)Math.PI / 6 * deltaTime);
            }
            //0 keypad
            if (Input.IsKeyPressed(320))
            {
                //shoot bullet
                Fire();
            }
        }

        //update every second
        public override void Update(float deltaTime)
        {
            
            //check if player 1
            if (this.Parent is Tank)
            {
                Tank player = this.Parent as Tank;
                if (player.getPlayerNum() == 1)
                //bind player one's barrel controls to q and e and space
                p1BarrelConrols(deltaTime);
            }

            //check if player 2
            if (this.Parent is Tank)
            {
                Tank player = this.Parent as Tank;
                if (player.getPlayerNum() == 2)
                    //bind player two's barrel controls to 7 and 9 and 0
                    p2BarrelConrols(deltaTime);
            }
        }
    }
}
