using UnityEngine;

namespace _TYU.Scripts.Module
{
    public class MovementModule : MonoBehaviour
    {
        [SerializeField] private float maxSpeed;
        [SerializeField] private float speed;
        private Rigidbody _rb;

        public void Initialize(Rigidbody rb)
        {
            _rb = rb;
        }

        public void Push(Vector2 dir, float pow, ForceMode forceMode)
        {
            
        }

        public void Move(Vector2 dir)
        {
            
        }
        
    }
}