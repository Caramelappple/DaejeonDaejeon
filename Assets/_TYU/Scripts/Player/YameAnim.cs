using System;
using UnityEngine;
using UnityEngine.UI;

namespace _TYU.Scripts.Player
{
    public class YameAnim : MonoBehaviour
    {
        private static readonly int VeloY = Animator.StringToHash("velY");
        private static readonly int VelX = Animator.StringToHash("velX");
        private Transform _trm;
        private Image _img;
        private SpriteRenderer _sr;
        private Animator _anim;
        private Camera _mainCamera;
        private Canvas _canvas;

        private void Awake()
        {
            _canvas = GetComponentInParent<Canvas>();
            _img = GetComponent<Image>();
            _sr = GetComponent<SpriteRenderer>();
            _anim = GetComponent<Animator>();
            _mainCamera = Camera.main;
        }

        public void Init(Transform trm)
        {
            _trm = trm;
        }
        
        private void LateUpdate()
        {
            if (_trm == null) return;
            Vector3 pos = _mainCamera.WorldToScreenPoint(_trm.position);
            RectTransform canvasRTrm = _canvas.transform as RectTransform;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvasRTrm,
                pos,
                null,
                out Vector2 canvasPos
            );
            
            transform.position = canvasPos + canvasRTrm.sizeDelta/2;
            _img.sprite = _sr.sprite;
        }

        public void SetDir(Vector3 dir)
        {
            _anim.SetFloat(VeloY, dir.z);
            _anim.SetFloat(VelX, dir.x);
        }
        
        
    }
}