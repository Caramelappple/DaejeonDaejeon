using _LSO._Scripts.Laser.Data;
using UnityEngine;

namespace _LSO._Scripts.Laser.Reaction
{
    public class ReflectReaction : ILaserReaction
    {
        public HitResult React(in LaserHitContext ctx)
        {
            Vector3 dir = Vector3.Reflect(ctx.direction, ctx.normal);
            dir.y = 0f;
            return HitResult.Reflect(ctx.hitPoint, dir.normalized, ctx.normal);
        }
    }
}
