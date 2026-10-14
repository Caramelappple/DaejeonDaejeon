using _LSO._Scripts.Laser.Data;

namespace _LSO._Scripts.Laser
{
    public interface ILaserReaction
    {
        public HitResult React(in LaserHitContext ctx)
        {
            return new HitResult();
        }
    }
}