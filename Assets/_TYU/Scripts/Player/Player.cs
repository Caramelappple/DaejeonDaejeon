using _TYU.Scripts.Interface;
using _TYU.Scripts.Module;
using UnityEngine;

namespace _TYU.Scripts.Player
{
    public class Player : MonoBehaviour, IMovable, IDamageable
    {
        
        private Rigidbody _rb;
        [field:SerializeField] public PlayerType MyType { get; private set; }
        [SerializeField] private AbstractInput inputReader;
        [SerializeField] private HealthModule hpMd;
        [SerializeField] private MovementModule moveMd;
        
        

        public void Push(Vector2 dir, float pow, ForceMode forceMode)
        {
            
        }

        public void GetDamage(int damage) => hpMd.GetDamage(damage);
        
        #region EventSetting

        private void EventSub()
        {
            
        }

        private void EventDisSub()
        {
            
        }

        #endregion
        #region Init

        private void GetComponents()
        {
            _rb = GetComponent<Rigidbody>();
            inputReader = GetComponentInChildren<AbstractInput>();
            hpMd = GetComponentInChildren<HealthModule>();
            moveMd = GetComponentInChildren<MovementModule>();
        }

        private void InitialIze()
        {
            moveMd.Initialize(_rb);
        }

        #endregion
    }
}