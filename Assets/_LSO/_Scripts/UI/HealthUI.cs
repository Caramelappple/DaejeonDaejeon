using System;
using UnityEngine;
using UnityEngine.UI;

namespace _LSO._Scripts.UI
{
    public class HealthUI : MonoBehaviour
    {
        private Slider _slider;
        private int MaxValue => health.MaxValue;
        public Health health;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        private void OnEnable()
        {
            health.OnDamage +=  Apply;
        }

        private void OnDisable()
        {
            health.OnDamage -= Apply;
        }

        private void Apply(DamageResultData data)
        {
            int value = data.currentHealth;
            
            if (MaxValue <= 0)
                return;
            _slider.value = (float)value/MaxValue;
        }
    }
}