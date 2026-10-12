using UnityEngine;

namespace _LSO._Scripts.Laser
{
    [CreateAssetMenu(fileName = "New LaserSO", menuName = "SO/Laser", order = 0)]
    public class LaserSO : ScriptableObject
    {
        [Header("Gauge 0 ~ 1 에 따라 변하는 값")]
        public int minDamage = 5;
        public int maxDamage = 30;
        public float minSpeed = 10f;
        public float maxSpeed = 40f;
        
        [Header("고정 값")]
        public float range;
        public LayerMask layerMask;
    }
}