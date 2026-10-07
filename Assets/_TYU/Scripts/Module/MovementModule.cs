using UnityEngine;

namespace _TYU.Scripts.Module
{
    public class MovementModule : MonoBehaviour
    {
        [SerializeField] private float speed;
        private Rigidbody _rb;

        public void Initialize(Rigidbody rb)
        {
            _rb = rb;
        }
    }
}