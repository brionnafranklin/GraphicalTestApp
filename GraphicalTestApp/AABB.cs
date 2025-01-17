﻿using System;

namespace GraphicalTestApp
{
    //class used to display hitboxes
    class AABB : Actor
    {
        //get and sets the width of the hitbox
        public float Width { get; set; } = 1;
        //get and sets the height of the hitbox
        public float Height { get; set; } = 1;
        //used to enable and disable shown hitboxes
        public static bool canDrawHitbox = false;
        //creates a default vector3 for the minimum dimentions of the AABB
        private Vector3 _min = new Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);
        //creates a default vector3 for the maximum dimentions of the AABB
        private Vector3 _max = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);

        //sets the default color of the hitbox to red
        Raylib.Color color = Raylib.Color.RED;

        //Returns the Y coordinate at the top of the box
        public float Top
        {
            get { return YAbsolute - Height / 2; }
        }

        //Returns the Y coordinate at the bottom of the box
        public float Bottom
        {
            get { return YAbsolute + Height / 2; }
        }

        //Returns the X coordinate at the left of the box
        public float Left
        {
            get { return XAbsolute - Height / 2; }
        }

        //Returns the X coordinate at the right of the box
        public float Right
        {
            get { return XAbsolute + Width / 2; }
        }

        //Creates an AABB of the specifed size
        public AABB(float width, float height)
        {
            Width = width;
            Height = height;
            X = 0;
            Y = 0;
        }

        //detects collision using AABB
        public bool DetectCollision(AABB other)
        {
            //return !(_max.x < other._min.x || _max.y < other._min.y || _min.x > other._max.x || _min.y > other._max.y)
            //test for overlapped as it exists faster
            if (Right >= other.Left && Bottom >= other.Top && Left <= other.Right && Top <= other.Bottom)
            {
                color = Raylib.Color.BLUE;
                return true;
            }
            color = Raylib.Color.RED;
            return false;
        }

        //detects collision using a vector3
        public bool DetectCollision(Vector3 point)
        {
            //test for overlapped as it exists faster
            return !(point.x < _min.x || point.y < _min.y || point.x > _max.x || point.y > _max.y);
        }

        //draw the hitbox
        public void DrawHitBoxes()
        {
            if (canDrawHitbox == true)
            { 
            Raylib.Rectangle rec = new Raylib.Rectangle(Left, Top, Width, Height);
            Raylib.Raylib.DrawRectangleLinesEx(rec, 5, color);
            }
            if (canDrawHitbox == false)
            {
                return;
            }
        }

        //Draw the bounding box to the screen
        public override void Draw()
        {
            DrawHitBoxes();
            base.Draw();
        }
    }
}
