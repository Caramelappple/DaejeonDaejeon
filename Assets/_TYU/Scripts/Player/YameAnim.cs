using System;
using UnityEngine;
using UnityEngine.UI;

namespace _TYU.Scripts.Player
{
    public class YameAnim : MonoBehaviour
    {
        private static readonly int Dir = Animator.StringToHash("Dir");
        private Transform _trm;
        private Image _img;
        private SpriteRenderer _sr;
        private Animator _anim;
        private Camera _worldCamera;
        private Canvas _canvas;

        private void Awake()
        {
            _canvas = GetComponentInParent<Canvas>();
            _img = GetComponent<Image>();
            _sr = GetComponent<SpriteRenderer>();
            _anim = GetComponent<Animator>();
            _worldCamera = Camera.main;
        }

        public void Init(Transform trm)
        {
            _trm = trm;
        }
        
        private void LateUpdate()
        {
            if (_trm == null) return;
            transform.position = new Vector3(_trm.position.x, transform.position.y, _trm.position.z);
            _img.sprite = _sr.sprite;
        }

        public void SetDir(Vector3 dir)
        {
            var input = new Vector2(dir.x, dir.y);
            _anim.SetFloat(Dir, input.magnitude);
        }
        
        
    }
}