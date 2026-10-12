using System;
using _LSO._Scripts.Laser.Data;
using _TYU.Scripts.Player;
using UnityEngine;

namespace _LSO._Scripts.Laser
{
    [RequireComponent(typeof(Collider),  typeof(Rigidbody))]
    public class LaserProjectile : MonoBehaviour
    {
        private int _damage;
        private float _speed;
        private float _range;
        private LayerMask _layerMask;

        private Rigidbody _rigid;

        private void Awake()
        {
            _rigid = GetComponent<Rigidbody>();
        }

        public void Init(int damage, float speed, float range,  LayerMask layerMask, Player shooter)
        {
            _damage = damage;
            _speed = speed;
            _range = range;
            _layerMask = layerMask;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<Wall.Wall>(out var wall))
            {
                switch (wall.wallSO.laserResponse)
                {
                    case LaserResponse.Block:
                        Destroy(gameObject);
                        break;
                    case LaserResponse.Absorb:
                        
                        break;
                    case LaserResponse.Reflect:
                        break;
                }
            }
        }

        public void Move(Vector3 direction)
        {
            _rigid.linearVelocity = direction.normalized * _speed;
        }
    }
}