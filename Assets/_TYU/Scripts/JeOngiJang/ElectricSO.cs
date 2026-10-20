using UnityEngine;

namespace _TYU.Scripts.JeOngiJang
{
    [CreateAssetMenu(fileName = "ElectricData", menuName = "Jeongi/data", order = 0)]
    public class ElectricSO : ScriptableObject
    {
        [field:SerializeField]public float ElectronicDistance { get; private set; }
        [field:SerializeField]public int Gauge{ get; private set; }
        [field:SerializeField]public float PushPower{ get; private set; }
    }
}