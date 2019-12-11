using System;
using System.Diagnostics;

namespace GraphicalTestApp
{
    //Controls time in the game
    class Timer
    {
        //declares and innitaulizes a new stopwatch
        private Stopwatch _stopwatch = new Stopwatch();
        //declares and innitaulizes the currentTime
        private long _currentTime = 0;
        //declares and innitaulizes the previousTime
        private long _previousTime = 0;
        ////declares and innitaulizes deltaTime
        private float _deltaTime = 0.005f;

        //starts the stopwatch
        public Timer()
        {
            _stopwatch.Start();
        }

        //restarts the stopwatch
        public void Restart()
        {
            _stopwatch.Restart();
        }

        //The time in seconds
        public float Seconds
        {
            get { return _stopwatch.ElapsedMilliseconds / 1000.0f; }
        }

        //calculates delaTime
        public float GetDeltaTime()
        {
            _previousTime = _currentTime;
            _currentTime = _stopwatch.ElapsedMilliseconds;
            _deltaTime = (_currentTime - _previousTime) / 1000.0f;
            return _deltaTime;
        }
    }
}
