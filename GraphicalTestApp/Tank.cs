using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Tank : Entity
    {
        //assigns a number value to a player
        private uint playerNum;

        //places tank
        public Tank( float x, float y, uint p) : base(x,y)
        {
            playerNum = p;
            X = x;
            Y = y;
        }

        public uint GetplayerNum()
        {
            return playerNum;
        }

        //checks to see if a givin value is with a givin min and max
        public bool inRange(float val, float min, float max)
        {
            if (val > min && val < max)
            {
                return true;
            }
            return false;
        }

        //make sure the player is on screen
        public void checkTankPosition()
        {
            if (inRange(X, 0, 1280) == false)
            {
                XVelocity = -XVelocity;
                
            }
            if(inRange(Y, 0, 760) == false)
            {
                YVelocity = -YVelocity;
            }
        }

        //move player up
        public void MoveUp()
        {
            if (YAcceleration >= -10)
            {
                YAcceleration += -10;
            }
            //turn upward
            SetRotate((float)Math.PI * 2);
        }

        //move player down
        public void MoveDown()
        {
            //move down
            if (YAcceleration <= 10)
            { 
                YAcceleration += 10;
            }
            //turn downward
            SetRotate((float)Math.PI);
        }

        //move player right
        public void MoveRight()
        {
            //move right
            if (XAcceleration <= 10)
            {
                XAcceleration += 10;
            }
            //turn right
            SetRotate((float)Math.PI/2);
        }
        //move player left
        public void MoveLeft()
        {
            if (XAcceleration >= -10)
            {
                XAcceleration += -10;
            }
            //turn left
            SetRotate((float)Math.PI *3/2);
        }

        //player 1 controls
        public void p1controls()
        {
            //w
            if (Input.IsKeyDown(87))
            {
                MoveUp();
                return;
            }
            //s
            if (Input.IsKeyDown(83))
            {
                MoveDown();
                return;
            }
            //d
            if (Input.IsKeyDown(68))
            {
                MoveRight();
                return;
            }
            //a
            if (Input.IsKeyDown(65))
            {
                MoveLeft();
                return;
            }
            SlowDown();
        }

        //player 2 controls
        public void p2controls()
        {
            //up arrow
            if (Input.IsKeyDown(265))
            {
                MoveUp();
                return;
            }
            //down arrow
            if (Input.IsKeyDown(264))
            {
                MoveDown();
                return;
            }
            //right arrow
            if (Input.IsKeyDown(262))
            {
                MoveRight();
                return;
            }
            //left arrow
            if (Input.IsKeyDown(263))
            {
                MoveLeft();
                return;
            }
            //if the player is not moving in a direction slowly stop
            SlowDown();
        }

        //makes stops gradual
        public void SlowDown()
        {
            if(XVelocity > 0)
            {
                XVelocity -= 0.01f;
                XAcceleration = 0;
            }
            else if ( XVelocity < 0)
            {
                XVelocity += 0.01f;
                XAcceleration = 0;
            }
            if (YVelocity > 0)
            {
                YVelocity -= 0.01f;
                YAcceleration = 0;
            }
            else if (YVelocity < 0)
            {
                YVelocity += 0.01f;
                YAcceleration = 0;
            }
        }

        //update every second
        public override void Update(float deltaTime)
        {
            //check if player 1
            if (playerNum == 1)
            {
                //bind player one's controls to wasd
                p1controls();
                //make sure the player is on screen
                checkTankPosition();
            }
            //check if player 2
            if (playerNum == 2)
            {
                //bind player two's controls to arrow keys
                p2controls();
                //make sure the player is on screen
                checkTankPosition();
            }

            base.Update(deltaTime);
        }
    }
}
