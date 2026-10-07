using UnityEngine;

namespace _LSO._Scripts.Wall.Data
{
    [CreateAssetMenu(fileName = "GroundWall SO", menuName = "SO/Wall/GroundWall", order = 1)]
    public class GroundWallData : WallSO
    {
        public int dischargePerSecond;
    }
}