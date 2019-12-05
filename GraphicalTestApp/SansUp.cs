using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class SansUp : Barrel
    {
        //replace barrel
        public SansUp(float x, float y) : base(x, y)
        {
            X = x;
            Y = y;
            Rotate((float)Math.PI);
        }

        //creates bullet and sends it in the direction the barrel is facing
        public override void Fire()
        {
            if (Parent is Tank)
            {
                Tank player = Parent as Tank;
                Bullet bullet = new Bullet(XAbsolute, YAbsolute, player.getPlayerNum(), "Bone44x12.png");

                Parent.Parent.AddChild(bullet);
                bullet.SetRotate(GetRotation() + (float)Math.PI);
                bullet.XVelocity = (float)Math.Cos(bullet.GetRotation() - (float)Math.PI * 0.5f) * 100;
                bullet.YVelocity = (float)Math.Sin(bullet.GetRotation() - (float)Math.PI * 0.5f) * 100;
            }
        }

        
    }
}
