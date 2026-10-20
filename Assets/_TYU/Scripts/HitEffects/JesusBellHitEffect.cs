using System.Collections;
using System.Collections.Generic;
using _TYU.Scripts.HitEffects;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class JesusBellHitEffect : AbstractHitEffect
{
    [SerializeField] private Image _image;
    [SerializeField] private List<Sprite> imgs;
    [SerializeField] private float time;
    [SerializeField] private Color _color;
    [SerializeField] private AudioSource src;
    [SerializeField] private AudioClip clp;


    public override void StartHitEffect()
    {
        StartCoroutine(Hitco());
    }

    private IEnumerator Hitco()
    {
        src.clip = clp;
        src.time = 0.4f;
        src.Play();
        _image.sprite = imgs[Random.Range(0, imgs.Count)];
        _image.color = _color;
        _image.DOFade(0 ,time).SetEase(Ease.InExpo);
        yield return new WaitForSeconds(time);
        HitCaller.Instance.EndEffect();
    }
}
