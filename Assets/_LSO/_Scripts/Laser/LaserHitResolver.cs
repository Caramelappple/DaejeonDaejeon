using System.Collections.Generic;
using _LSO._Scripts.Laser.Data;
using _TYU.Scripts.Interface;

namespace _LSO._Scripts.Laser
{
    /// <summary>
    /// 판정을 분기해주는 클래스
    /// </summary>
    public class LaserHitResolver
    {
        private readonly Dictionary<LaserResponse, ILaserReaction> _wallReactions;
        private readonly ILaserReaction _laserReaction;

        public LaserHitResolver(
            Dictionary<LaserResponse, ILaserReaction> wallReactions,
            ILaserReaction playerReaction)
        {
            _wallReactions = wallReactions;
            _laserReaction = playerReaction;
        }

        public HitResult Resolve(in LaserHitContext ctx)
        {
            if (ctx.other.gameObject.TryGetComponent(out IDamageable target))
                return _laserReaction.React(ctx);

            if (ctx.other.gameObject.TryGetComponent(out Wall.Wall wall))
                return _wallReactions[wall.wallSO.laserResponse].React(ctx);

            return HitResult.Destroy(ctx.hitPoint);
        }
    }
}