using DevLib.ServiceLocator;
using DevLib.SoundSystem.Runtime;
using UnityEngine;

namespace _LSO._Scripts
{
    public class YameMusicPlayer : MonoBehaviour
    {
        public static YameMusicPlayer Instance{get; private set;}

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }

        [SerializeField] private SoundClipSO soundClip;

        private void Start()
        {
            ServiceLocator.Get<IAudioService>()?.PlayBgm(soundClip);
        }

        public void Stop()
        {
            ServiceLocator.Get<IAudioService>()?.StopBgm();
        }
        
        public void Play()
        {
            ServiceLocator.Get<IAudioService>()?.PlayBgm(soundClip);
        }
    }
}