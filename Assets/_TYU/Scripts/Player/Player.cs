using UnityEngine;

namespace _TYU.Scripts.Player
{
    public class Player : MonoBehaviour
    {
        private Rigidbody _rb;
        [SerializeField] private AbstractInput inputReader;
        
        
        
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
        }

        #endregion
    }
}