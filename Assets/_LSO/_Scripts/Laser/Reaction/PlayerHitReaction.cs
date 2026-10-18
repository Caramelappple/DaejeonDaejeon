using _LSO._Scripts.Laser.Data;
using _TYU.Scripts.Player;

namespace _LSO._Scripts.Laser.Reaction
{
    public class PlayerHitReaction : ILaserReaction
    {
        public HitResult React(in LaserHitContext ctx)
        {
            if (ctx.other.TryGetComponent<Player>(out var player))
            {
                var health = player.Health;
                
                DamageData data = new DamageData(ctx.shooter.Health, ctx.damage);
                health.GetDamage(data);
            }
            return HitResult.Destroy(ctx.hitPoint);
        }
    }
}