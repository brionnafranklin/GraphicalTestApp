using System;

namespace GraphicalTestApp
{
    class AABB : Actor
    {
        public float Width { get; set; } = 1;
        public float Height { get; set; } = 1;

        private Vector3 _min = new Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);
        private Vector3 _max = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);

        //Returns the Y coordinate at the top of the box
        public float Top
        {
            get { return YAbsolute; }
        }

        //Returns the Y coordinate at the top of the box
        public float Bottom
        {
            get { return YAbsolute + Height; }
        }

        //Returns the X coordinate at the top of the box
        public float Left
        {
            get { return XAbsolute; }
        }

        //Returns the X coordinate at the top of the box
        public float Right
        {
            get { return XAbsolute + Width; }
        }

        //Creates an AABB of the specifed size
        public AABB(float width, float height)
        {
            Width = width;
            Height = height;
            X = -width / 2;
            Y = -Height / 2;
        }

        //detects collision using AABB
        public bool DetectCollision(AABB other)
        {
            //test for overlapped as it exists faster
            return !(_max.x < other._min.x || _max.y < other._min.y || _min.x > other._max.x || _min.y > other._max.y);
        }

        //detects collision using a vector3
        public bool DetectCollision(Vector3 point)
        {
            //test for overlapped as it exists faster
            return !(point.x < _min.x || point.y < _min.y || point.x > _max.x || point.y > _max.y);
        }

        //Draw the bounding box to the screen
        public override void Draw()
        {
            Raylib.Rectangle rec = new Raylib.Rectangle(XAbsolute, YAbsolute, Width, Height);
            Raylib.Raylib.DrawRectangleLinesEx(rec, 1, Raylib.Color.RED);
        }
    }
}
