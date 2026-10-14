using _LSO._Scripts.Laser.Data;

namespace _LSO._Scripts.Laser.Reaction
{
    public class AbsorbReaction : ILaserReaction
    {
        public HitResult React(in LaserHitContext ctx)
        {
            
            return HitResult.Destroy(ctx.hitPoint);
        }
    }
}