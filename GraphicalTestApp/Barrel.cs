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
        }
    }
}
