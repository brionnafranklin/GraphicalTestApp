using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    //an icon that, when touch by a player, gives special abilities to that player
    class SansIcon : Entity
    {
        //creates a hitbox for SansIcon
        public AABB _sHitbox;
        //creates a sprite for SansIcon
        public Sprite _sSprite;
        //list of SansIcon
        static public List<SansIcon> SansList = new List<SansIcon>();
        
        //creates SansIcon and gives it all it's probertities
        public SansIcon(float x, float y, string _SansSprite) : base(x, y)
        {
            X = x;
            Y = y;
            
            Sprite sansSprite = new Sprite(_SansSprite);
            AABB sansHitBox = new AABB(sansSprite.Height, sansSprite.Width);

            _sSprite = sansSprite;
            _sHitbox = sansHitBox;

            AddChild(sansSprite);
            AddChild(sansHitBox);

            SansList.Add(this);
        }
    }
}
