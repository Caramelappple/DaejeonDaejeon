using _TYU.Scripts.JeOngiJang;
using UnityEngine;

namespace _LSO._Scripts.Wall.Data
{
    [CreateAssetMenu(fileName = "PolarityWall SO", menuName = "SO/Wall/PolarityWall", order = 1)]
    public class PolarityWallData : WallSO
    {
        public ElectronicType type;
        public float force;
        public ForceMode forceMode;
    }
}