using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    //a special type of bullet that can't shoot bullets belonging to the player who shot it
    class SansBullet : Bullet
    {
        //declares the SansBullet's sprite
        Sprite _bSprite;
        //declares the SansBullet's hit box
        AABB _bHitbox;
        ////declares the SansBullet's player number
        public float playerNum;

        //constructer for SansBullet; sets up everything for the SansBullet uncluding x, y, playernumber, and sprite
        public SansBullet(float x, float y, float p, string _bulletSprite) : base(x, y, p, _bulletSprite)
        {
            playerNum = p;
            X = x;
            Y = y;

            Sprite bulletSprite = new Sprite(_bulletSprite);
            AABB bulletHitBox = new AABB(bulletSprite.Height, bulletSprite.Width);

            _bSprite = bulletSprite;
            _bHitbox = bulletHitBox;

            AddChild(bulletSprite);
            AddChild(bulletHitBox);
        }

        //destroys opponents bullets if they hit sansbullet
        public override void bulletOnBulletCollision(float deltaTime)
        {
            Actor Root = Parent as Actor;
            foreach (Actor b in Root.GetChildren())
            {
                
                if (b is Bullet)
                {
                    Bullet bullet = b as Bullet;
                    if (bullet.playerNum == playerNum)
                    {
                        return;
                    }
                    else if (_bHitbox.DetectCollision(bullet._bHitbox) == true)
                    {
                        Parent.RemoveChild(b);
                        Parent.RemoveChild(this);
                    }
                }
            }
        }
    }
}
