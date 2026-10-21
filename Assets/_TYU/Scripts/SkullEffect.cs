using System;
using System.Collections;
using System.Collections.Generic;
using _LSO._Scripts;
using _TYU.Scripts.HitEffects;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace _TYU.Scripts
{
    public class SkullEffect : AbstractHitEffect
    {
        public static SkullEffect Instance { get; private set; }
        [SerializeField] private List<Sprite> sprites;
        [SerializeField] private float time;
        [SerializeField] private Image skull;
        [SerializeField] private Volume volume;
        [SerializeField] private List<AudioClip> clip;
        [SerializeField] private AudioSource audio;
        [SerializeField] private Vector2 shake;
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

        public override void StartHitEffect()
        {
            _isOn = true;
            skull.sprite = sprites[Random.Range(0, sprites.Count)];
            skull.rectTransform.localScale = new Vector3(0.5f, 0.5f, 1f);
            skull.color = new Color(1,1,1,1);
            audio.PlayOneShot(clip[Random.Range(0,clip.Count)]);
            YameMusicPlayer.Instance.Stop();
            Time.timeScale = 0;
            colr.saturation.value = -100;
            DOTween.Sequence().
                Append(skull.rectTransform.DOShakeAnchorPos(time-0.8f,shake,1250 ,0).SetEase(Ease.OutQuad))
                .Join(skull.rectTransform.DOScale(Vector3.one, time-0.8f).SetEase(Ease.OutQuad)).SetUpdate(true).OnComplete( () => YameMusicPlayer.Instance.Play() );
                
        }
        private void Update()
        {
            if (_isOn && !audio.isPlaying)
            {
                _isOn = false;
                Time.timeScale = 1f;
                colr.saturation.value = 0;
                skull.color = new Color(1,1,1,0);
                HitCaller.Instance.EndEffect();
            }
        }
    }
}