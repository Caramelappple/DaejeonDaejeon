using _LSO._Scripts.Laser.Data;
using _LSO._Scripts.Wall.Data;
using UnityEngine;

namespace _LSO._Scripts.Laser.Reaction
{
    public class AbsorbReaction : ILaserReaction
    {
        public HitResult React(in LaserHitContext ctx) => HitResult.Destroy(ctx.hitPoint);
    }
}