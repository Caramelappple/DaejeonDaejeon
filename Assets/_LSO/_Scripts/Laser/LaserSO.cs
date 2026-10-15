using UnityEngine;

namespace _LSO._Scripts.Laser
{
    [CreateAssetMenu(fileName = "New LaserSO", menuName = "SO/Laser", order = 0)]
    public class LaserSO : ScriptableObject
    {
        [Header("고정 값")]
        public LayerMask layerMask;
    }
}