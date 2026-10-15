using System;
using UnityEngine;

public class GaugeModule : MonoBehaviour
{
    [SerializeField] private int maxValue = 100;
    private const int StartValue = 0;
    private int _value;

    public int Value => _value;
    public event Action<int> OnChanged;

    public void Up(int v)   => Set(_value + v);
    public void Down(int v) => Set(_value - v);

    private void Set(int v)
    {
        int clamped = Mathf.Clamp(v, StartValue, maxValue);
        if (clamped == _value) return;
        _value = clamped;
        OnChanged?.Invoke(_value);
    }
}