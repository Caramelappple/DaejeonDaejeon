using System;
using UnityEngine;

public class GaugeModule : MonoBehaviour
{
    [SerializeField] private int maxValue = 100;
    private float _value;
    public int Value => Mathf.FloorToInt(_value);
    public event Action<int> OnChanged;

    public void Up(float v)   => Set(_value + v);
    public void Down(float v) => Set(_value - v);
    
    public void Clear() => Set(0f);

    private void Set(float v)
    {
        float clamped = Mathf.Clamp(v, 0f, maxValue);
        if (Mathf.Approximately(clamped, _value)) return;
        int before = Value;
        _value = clamped;
        if (Value != before) OnChanged?.Invoke(Value);   // 표시값이 바뀔 때만 UI 갱신
    }
}