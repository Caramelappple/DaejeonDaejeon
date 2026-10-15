using _LSO._Scripts.Laser.Data;
using _TYU.Scripts.Player;

namespace _LSO._Scripts.Laser.Reaction
{
    public class PlayerHitReaction : ILaserReaction
    {
        public HitResult React(in LaserHitContext ctx)
        {
            if (ctx.other.TryGetComponent<Player>(out var player))
                Get
            return HitResult.Destroy(ctx.hitPoint);
        }
    }
}