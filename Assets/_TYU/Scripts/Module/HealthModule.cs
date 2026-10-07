using System;
using UnityEngine;

namespace _TYU.Scripts.Module
{
    public class HealthModule : MonoBehaviour
    {
        [SerializeField] private int maxHp;
        private int _curHp;

        public event Action OnDead;
        
        public void GetDamage(int damage)
        {
            _curHp -= damage;
            Mathf.Clamp(_curHp, 0, maxHp+1);
            if(_curHp <= 0)
                OnDead?.Invoke();
        }

        public void GetHeal(int heal)
        {
            _curHp += heal;
        }
    }
}