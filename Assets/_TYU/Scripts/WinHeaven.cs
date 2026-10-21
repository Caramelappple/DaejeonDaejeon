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
        public WinHeaven Instance { get; private set; }
        
        private void Awake()
        {
            if(Instance != null&& Instance != this)
                Destroy(gameObject);
            if (Instance == null)
                Instance = this;
            _player = GetComponent<VideoPlayer>();
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
            if(Keyboard.current.gKey.wasPressedThisFrame) Win();
            
            if (_isOn && !_player.isPlaying)
                SceneManager.LoadScene(0);
        }
    }
}