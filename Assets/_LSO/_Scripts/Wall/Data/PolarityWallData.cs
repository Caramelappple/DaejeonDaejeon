using UnityEngine;

namespace _LSO._Scripts.Wall.Data
{
    [CreateAssetMenu(fileName = "PolarityWall SO", menuName = "SO/Wall/PolarityWall", order = 1)]
    public class PolarityWallData : WallSO
    {
        public float polarity;
        public float force;
    }
}