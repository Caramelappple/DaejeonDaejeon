using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

namespace _TYU.Scripts
{
    public class WinHeaven : MonoBehaviour
    {
        private VideoPlayer _player;
        private bool _isOn;
        public static WinHeaven Instance { get; private set; }
        
        private void Awake()
        {
            if(Instance != null&& Instance != this)
                Destroy(gameObject);
            if (Instance == null)
                Instance = this;
            _player = GetComponent<VideoPlayer>();
            _player.renderMode = VideoRenderMode.CameraNearPlane;
            _player.targetCamera = Camera.main;
        }
        private void OnDestroy()
        {
            if (Instance == this)
                Instance = null;
        }

        public void Win() => StartCoroutine(WinCo());

        private IEnumerator WinCo()
        {
            _player.Play();
            yield return new WaitForSecondsRealtime(3);
            _isOn = true;
        }

       

        private void Update()
        {
            
            if (_isOn && !_player.isPlaying)
                SceneManager.LoadScene(0);
        }
    }
}