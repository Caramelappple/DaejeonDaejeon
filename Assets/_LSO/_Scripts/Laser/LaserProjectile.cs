using System;
using _LSO._Scripts.Laser.Data;
using _LSO._Scripts.Wall.Data;
using _TYU.Scripts.Player;
using UnityEngine;

namespace _LSO._Scripts.Laser
{
    [RequireComponent(typeof(Collider), typeof(Rigidbody))]
    public class LaserProjectile : MonoBehaviour
    {
        private int _damage;
        private float _speed;
        private LayerMask _layerMask;
        private Player _shooter;

        private Vector3 _direction;
        private bool _hasReflected;
        private Collider _lastReflected;

        private Rigidbody _rigid;
        private LaserHitResolver _hitResolver;

        private void Awake()
        {
            _rigid = GetComponent<Rigidbody>();
        }   

        public void Init(int damage, float speed, LayerMask layerMask, Player shooter, LaserHitResolver resolver)
        {
            _damage = damage;
            _speed = speed;
            _layerMask = layerMask;
            _shooter = shooter;
            _hitResolver = resolver;
            Destroy(gameObject, 10f);
        }

        // 움직여주는 메서드
        public void Step(Vector3 direction)
        {
            _direction = direction.normalized;
            _rigid.linearVelocity = _direction * _speed;
        }

        private void OnTriggerEnter(Collider other)
        {
           
            if (!_hasReflected && _shooter != null && other.gameObject == _shooter.gameObject) return; // 발사 직후 겹침 방지
            if (other == _lastReflected) return; // 반사 직후 같은 벽 재충돌 방지
            if (((1 << other.gameObject.layer) & _layerMask) == 0) return; // 마스크 밖 레이어 무시
            
            GetHitInfo(other, out Vector3 point, out Vector3 normal);

            WallSO wallSo = null;
            if (other.TryGetComponent<Wall.Wall>(out var wall))
                wallSo = wall.wallSO;

            var ctx = new LaserHitContext(other, point, normal, _direction, _damage, _shooter, wallSo);
                
            HitResult result = _hitResolver.Resolve(ctx);
            Apply(result, other);
            
            
        }
        
        private void GetHitInfo(Collider other, out Vector3 point, out Vector3 normal)
        {
            float back = _speed * Time.fixedDeltaTime + 0.1f;
            Vector3 origin = transform.position - _direction * back;

            if (other.Raycast(new Ray(origin, _direction), out RaycastHit hit, back * 2f))
            {
                point = hit.point;
                normal = hit.normal;
                return;
            }

            point = transform.position;
            normal = -_direction;
        }

        private void Apply(HitResult r, Collider other)
        {
            if (r.reflect && !_hasReflected)
            {
                _hasReflected = true;
                _lastReflected = other;
                _direction = r.newDirection;
                Step(_direction);
                Debug.Log("1");
            }
            else if (!r.reflect)
                Destroy(gameObject);
            else
                Destroy(gameObject);

            Debug.Log("2");
        }
    }
}