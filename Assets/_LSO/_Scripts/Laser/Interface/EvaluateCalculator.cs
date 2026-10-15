using UnityEngine;

namespace _LSO._Scripts.Laser
{
    public class EvaluateCalculator : IEvaluate
    {
        public float Evaluate(UpgradeStat[] data, float percentage, bool isInt)
        {
            if (data.Length == 0)
                return 0f;
            foreach (var upgradeStat in data)
            {
                if (upgradeStat.percent <= percentage)
                    return isInt ? Mathf.RoundToInt(upgradeStat.value)  : upgradeStat.value;
                return 0f;
            }
            return 0f;
        }
    }
}