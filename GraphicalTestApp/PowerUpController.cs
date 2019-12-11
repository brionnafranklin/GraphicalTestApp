using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    //controlls the spawning of power ups
    class PowerUpController : Actor
    {
        //create the timer used for power ups
        private Timer _powerUpTimer = new Timer();
        //creates bool used to determine if SansIcon has spawned
        static public bool SpawnedSansIcon;

        //adds Sans power up
        public void SpawnSans(float deltaTime)
        {
            if (SpawnedSansIcon == false)
            {
                if (_powerUpTimer.Seconds == 60 || Input.IsKeyDown(54) && Input.IsKeyDown(57))
                {
                    SansIcon Sans = new SansIcon(640, 380, "Sans30x31.png");
                    AddChild(Sans);

                    SpawnedSansIcon = true;
                }
            }
        }

        //update every second
        public override void Update(float deltaTime)
        {
            SpawnSans(deltaTime);
            base.Update(deltaTime);
        }
    }
}
