using _LSO._Scripts.Laser.Data;

namespace _LSO._Scripts.Laser.Reaction
{
    public class BlockReaction : ILaserReaction
    {
        public HitResult React(in LaserHitContext ctx) => HitResult.Destroy(ctx.hitPoint);
    }
}