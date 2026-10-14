using _LSO._Scripts.Laser.Data;
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
        private LaserVisual _visual;
        public LaserHitResolver hitResolver = new LaserHitResolver();

        private void Awake()
        {
            _rigid = GetComponent<Rigidbody>();
            _visual = GetComponent<LaserVisual>();
        }

        public void Init(int damage, float speed, LayerMask layerMask, Player shooter)
        {
            _damage = damage;
            _speed = speed;
            _layerMask = layerMask;
            _shooter = shooter;
        }

        // 움직여주는 메서드
        public void Step(Vector3 direction)
        {
            _direction = direction.normalized;
            _rigid.linearVelocity = _direction * _speed;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other == _lastReflected) return; // 반사 직후 같은 벽 재충돌 방지
            if (((1 << other.gameObject.layer) & _layerMask) == 0) return; // 마스크 밖 레이어 무시

            Vector3 point = other.ClosestPoint(transform.position);
            Vector3 normal = (transform.position - point).normalized;

            var ctx = new LaserHitContext(other, point, normal, _direction, _damage, _shooter);
            HitResult result = hitResolver.Resolve(ctx);
            Apply(result, other);
        }

        private void Apply(HitResult r, Collider other)
        {
            _visual.AddPoint(r.hitPoint);

            if (r.reflect && !_hasReflected)
            {
                _hasReflected = true;
                _lastReflected = other;
                _direction = r.newDirection;
            }
        }
    }
}