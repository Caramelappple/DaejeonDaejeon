using _LSO._Scripts.Laser.Data;
using _LSO._Scripts.Wall.Data;
using UnityEngine;

namespace _LSO._Scripts.Laser.Reaction
{
    public class AbsorbReaction : ILaserReaction
    {
        public HitResult React(in LaserHitContext ctx)
        {
            GroundWallData wall = ctx.wallSo as GroundWallData;
            
            if (wall == null)
            {
                Debug.LogError("흡수가 이상함");
                return new HitResult();
            }
            
            return HitResult.Destroy(ctx.hitPoint);
        }
    }
}