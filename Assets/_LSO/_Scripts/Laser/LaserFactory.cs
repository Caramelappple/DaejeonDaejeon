using System.Collections.Generic;
using _LSO._Scripts.Laser.Data;
using _LSO._Scripts.Laser.Reaction;

namespace _LSO._Scripts.Laser
{
    public class LaserFactory
    {
        var resolver = new LaserHitResolver(
            new Dictionary<LaserResponse, ILaserReaction>
            {
                { LaserResponse.Block,   new BlockReaction()   },
                { LaserResponse.Absorb,  new AbsorbReaction()  },
                { LaserResponse.Reflect, new ReflectReaction() },
            },
            new PlayerHitReaction());
    }
}