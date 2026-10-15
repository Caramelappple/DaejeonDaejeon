using System;
using System.Collections.Generic;
using UnityEngine;

namespace _LSO._Scripts.Laser
{
    [Serializable]
    public struct UpgradeStat
    {
        public float percent;
        public float value;
    }
    
    [CreateAssetMenu(fileName = "Evaluate SO", menuName = "SO/Evaluate", order = 0)]
    public class EvaluateData : ScriptableObject
    {
        public UpgradeStat[] speed;
        public UpgradeStat[] damage;
    }
}