using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _TYU.Scripts.HitEffects
{
    public class HitCaller : MonoBehaviour
    {
        public static HitCaller Instance { get; private set; }
        private bool _isOn;
        [SerializeField] private List<AbstractHitEffect> hitEffects;
        private void Awake()
        {
            if(Instance != null&& Instance != this)
                Destroy(gameObject);
            if (Instance == null)
                Instance = this;
        }

        public void Hit()
        {
            if (_isOn) return;
            _isOn = true;
            hitEffects[Random.Range(0, hitEffects.Count)].StartHitEffect();
        }

        public void EndEffect()
        {
            Time.timeScale = 1;
            _isOn = false;
        }
        
        
        private void OnDestroy()
        {
            if (Instance == this)
                Instance = null;
        }
    }
}