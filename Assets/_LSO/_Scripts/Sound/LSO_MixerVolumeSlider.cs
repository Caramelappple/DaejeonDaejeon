using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace _Scripts.LSO.UI.Option
{
    [RequireComponent(typeof(Slider))]
    [DisallowMultipleComponent]
    public sealed class LSO_MixerVolumeSlider : MonoBehaviour
    {
        [Header("연결")]
        [Tooltip("볼륨을 바꿀 믹서. Assets/GameModules/System/MainMixer.")]
        [SerializeField] private AudioMixer mixer;

        [Tooltip("믹서에서 노출해둔 파라미터 이름")]
        [SerializeField] private string exposedParameter = "MasterVolume";

        [Header("범위")]
        [Tooltip("슬라이더를 맨 왼쪽까지 내렸을 때의 데시벨. -80이 유니티의 무음이다.")]
        [SerializeField] private float minDecibel = -80f;

        [Tooltip("슬라이더를 맨 오른쪽까지 올렸을 때의 데시벨. 0이 원래크기")]
        [SerializeField] private float maxDecibel = 0f;

        [Tooltip("배선이 없거나 이름이 틀렸을 때 켤 기본값")]
        [SerializeField, Range(0f, 1f)] private float fallbackValue = 0.8f;

        private Slider _slider;
        
        private bool _warnedMissingParameter;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        private void OnEnable()
        {
            _slider.onValueChanged.RemoveListener(HandleValueChanged);
            _slider.onValueChanged.AddListener(HandleValueChanged);

            PullFromMixer();
        }

        private void OnDisable()
        {
            _slider.onValueChanged.RemoveListener(HandleValueChanged);
        }
        
        private void PullFromMixer()
        {
            if (!TryGetDecibel(out float decibel))
            {
                SetSliderWithoutNotify(fallbackValue);
                return;
            }

            SetSliderWithoutNotify(ToLinear(decibel));
        }

        private void HandleValueChanged(float value)
        {
            if (mixer == null)
            {
                WarnOnce("Mixer 가 비어 있어 볼륨을 바꾸지 못합니다.");
                return;
            }

            if (!mixer.SetFloat(exposedParameter, ToDecibel(value)))
            {
                WarnOnce(
                    $"믹서에 '{exposedParameter}' 라는 파라미터가 없음");
            }
        }

        private bool TryGetDecibel(out float decibel)
        {
            decibel = maxDecibel;

            if (mixer == null)
            {
                WarnOnce("Mixer 가 비어있음");
                return false;
            }

            if (mixer.GetFloat(exposedParameter, out decibel)) return true;

            WarnOnce(
                $"믹서에 '{exposedParameter}' 없음.");

            return false;
        }
        
        private float ToDecibel(float linear)
        {
            if (linear <= 0.0001f) return minDecibel;

            float decibel = Mathf.Log10(linear) * 20f;

            return Mathf.Clamp(decibel, minDecibel, maxDecibel);
        }
        
        private float ToLinear(float decibel)
        {
            if (decibel <= minDecibel) return 0f;

            return Mathf.Clamp01(Mathf.Pow(10f, decibel / 20f));
        }
        
        private void SetSliderWithoutNotify(float value)
        {
            if (_slider == null) return;

            _slider.SetValueWithoutNotify(Mathf.Clamp01(value));
        }

        private void WarnOnce(string message)
        {
            if (_warnedMissingParameter) return;

            _warnedMissingParameter = true;

            Debug.LogWarning($"{name}: {message} (이 경고는 한 번만 나옵니다)", this);
        }
    }
}
