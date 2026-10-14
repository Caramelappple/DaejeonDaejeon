

using UnityEngine;

namespace _LSO._Scripts.Laser.Data
{
    public readonly struct HitResult
    {
        public readonly bool reflect;
        public readonly Vector3 hitPoint;
        public readonly Vector3 newDirection;
        public readonly Vector3 normal;

        private HitResult(bool reflect, Vector3 hitPoint, Vector3 newDirection, Vector3 normal)
        {
            this.reflect = reflect;
            this.hitPoint = hitPoint;
            this.newDirection = newDirection;
            this.normal = normal;
        }

        public static HitResult Destroy(Vector3 hitPoint)
            => new(false, hitPoint, Vector3.zero, Vector3.zero);

        public static HitResult Reflect(Vector3 hitPoint, Vector3 newDirection, Vector3 normal)
            => new(true, hitPoint, newDirection, normal);
    }
}