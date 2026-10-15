using _LSO._Scripts.Laser.Data;
using _TYU.Scripts.Player;

namespace _LSO._Scripts.Laser.Reaction
{
    public class PlayerHitReaction : ILaserReaction
    {
        public HitResult React(in LaserHitContext ctx)
        {
            if (ctx.shooter.gameObject == ctx.other.gameObject)
                return new HitResult();
            
            if (ctx.other.TryGetComponent<Health>(out var player))
            {
                DamageData data = new DamageData(ctx.shooter.Health, ctx.damage);
                player.GetDamage(data);
            }
            return HitResult.Destroy(ctx.hitPoint);
        }
    }
}