using System;
using UnityEngine;
using UnityEngine.UI;

namespace _LSO._Scripts.UI
{
    public class GaugeUI : MonoBehaviour
    {
        private Slider _slider;
        private int MaxValue => gaugeModule.maxValue;
        public GaugeModule gaugeModule;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        private void OnEnable()
        {
            gaugeModule.OnChanged += Apply;
        }

        private void OnDisable()
        {
            gaugeModule.OnChanged -= Apply;
        }

        private void Apply(int value)
        {
            if (MaxValue <= 0)
                return;
            _slider.value = (float)value/MaxValue;
        }
    }
}