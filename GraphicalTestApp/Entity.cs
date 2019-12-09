using System;

namespace GraphicalTestApp
{
    //an Actor with movement capablities
    class Entity : Actor
    {
        //declares and innitializes velocity
        private Vector3 _velocity = new Vector3();
        //declares and innitializes acceleration
        private Vector3 _acceleration = new Vector3();
        //sets max speed
        private float _maxSpeed = 5f;

        //gets and sets velocity on the X axis
        public float XVelocity
        {
            get { return _velocity.x; }
            set { _velocity.x = value; }
        }

        //get and set acceleration on the X axis
        public float XAcceleration
        {
            get { return _acceleration.x; }
            set { _acceleration.x = value; }
        }

        //gets and sets velocity on the Y axis
        public float YVelocity
        {
            get { return _velocity.y; }
            set { _velocity.y = value; }
        }

        //get and set acceleration on the Y axis
        public float YAcceleration
        {
            get { return _acceleration.y; }
            set { _acceleration.y = value; }
        }

        //Creates an Entity at the specified coordinates
        public Entity(float x, float y)
        {
            X = x;
            Y = y;
        }
        
        //returns the value of max speed
        public float getMaxSpeed
        {
            get { return _maxSpeed; }
        }

        //get acceleration and velocity
        public override void Update(float deltaTime)
        {
            //get velocity using acceleration
            _velocity = _velocity + _acceleration * deltaTime;
            //get x and y position using velocity
            X = X + XVelocity * deltaTime;
            Y = Y + YVelocity * deltaTime;
            base.Update(deltaTime);
        }
    }
}
