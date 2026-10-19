using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

namespace _TYU.Scripts
{
    public class SkullEffect : MonoBehaviour
    {
        public static SkullEffect Instance { get; private set; }
        [SerializeField] private float time;
        [SerializeField] private Image skull;
        [SerializeField] private Volume volume;
        [SerializeField] private AudioClip clip;
        [SerializeField] private AudioSource audio;
        private ColorAdjustments colr;

        private bool _isOn;
        
        private void Awake()
        {
            if(Instance != null&& Instance != this)
                Destroy(gameObject);
            if (Instance == null)
                Instance = this;
            audio = GetComponent<AudioSource>();
            skull = GetComponentInChildren<Image>();
            if(volume == null) Debug.LogError("볼륨 넣어 병신아");
            volume.profile.TryGet(out colr);
        }

        public void HitEffect()
        {
            if (_isOn) return;
            StartCoroutine(HitEffectCo());
        }

        private IEnumerator HitEffectCo()
        {
            _isOn = true;
            skull.color = new Color(1,1,1,1);
            audio.PlayOneShot(clip);
            Time.timeScale = 0;
            colr.saturation.value = -100;
            yield return new WaitForSecondsRealtime(time);
            Time.timeScale = 1f;
            colr.saturation.value = 0;
            skull.color = new Color(1,1,1,0);
            _isOn = false;
        }


        private void OnDestroy()
        {
            if (Instance == this)
                Instance = null;
        }
    }
}