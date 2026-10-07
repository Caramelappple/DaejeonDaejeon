using _LSO._Scripts.Laser.Data;
using UnityEngine;

namespace _LSO._Scripts.Wall.Data
{
   [CreateAssetMenu(fileName = "WallSO", menuName = "SO/Wall/WallSO, order = 1")]
   public abstract class WallSO : ScriptableObject
   {
      [Header("Wall")]
      public string wallName;
      [TextArea(3,10)]public string description;
      public Color tintColor;

      [Header("Laser")]
      public LaserResponse laserResponse = LaserResponse.Block;   
      
      //public virtual void OnPlayerStay(PlayerController p, Wall wall) { }
   }
}
