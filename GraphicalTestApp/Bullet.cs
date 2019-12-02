using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Bullet : Entity
    {
        public float playerNum;
        public Bullet (float x, float y, float p) : base (x, y)
        {
            playerNum = p;
            X = x;
            Y = y;
        }
    }
}
