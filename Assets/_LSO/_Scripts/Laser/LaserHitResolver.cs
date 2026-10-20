using System.Collections.Generic;
using _LSO._Scripts.Laser.Data;
using _TYU.Scripts.Player;
using UnityEngine;

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
            Debug.Log("맞음2" + ctx.other.gameObject.name);
            if (ctx.other.gameObject.TryGetComponent(out Player _))
                return _laserReaction.React(ctx);
            
            if (ctx.other.gameObject.TryGetComponent(out Wall.Wall wall))
            {
                if (wall.wallSO == null)
                    return new HitResult();
                return _wallReactions[wall.wallSO.laserResponse].React(ctx);
            }
               

            return HitResult.Destroy(ctx.hitPoint);
        }
    }
}