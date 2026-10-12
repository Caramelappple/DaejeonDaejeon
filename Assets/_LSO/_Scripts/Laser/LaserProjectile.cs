using UnityEngine;

namespace _LSO._Scripts.Laser
{
    public class LaserProjectile : MonoBehaviour
    {
        private int _damage;
        private float _speed;
        private float _range;
        private LayerMask _layerMask;
        
        public void Init(int damage, float speed, float range,  LayerMask layerMask)
        {
            _damage = damage;
            _speed = speed;
            _range = range;
            _layerMask = layerMask;
        }
    }
}