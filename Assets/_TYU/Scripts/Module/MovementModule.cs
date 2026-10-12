using UnityEngine;

namespace _TYU.Scripts.Module
{
    public class MovementModule : MonoBehaviour
    {
        [SerializeField] private float maxSpeed;
        [SerializeField] private float speed;

        private Vector3 _curDir;
        private Rigidbody _rb;

        public void Initialize(Rigidbody rb)
        {
            _rb = rb;
        }

        public void Push(Vector3 dir, float pow, ForceMode forceMode)
        {
            
        }

        public void SetDir(Vector3 dir)
        {
            _curDir = dir;
        }

        public void SetMovement()
        {
            _rb.AddForce(_curDir * speed, ForceMode.Force);
            Vector3 movement = Vector3.zero;
            movement.x = Mathf.Clamp(_rb.linearVelocity.x, -speed, speed);
            movement.z = Mathf.Clamp(_rb.linearVelocity.z, -speed, speed);
            _rb.linearVelocity = movement;
        }
        
    }
}