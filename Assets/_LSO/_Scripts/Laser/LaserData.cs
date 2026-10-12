using UnityEngine;

namespace _LSO._Scripts.Laser
{
    [CreateAssetMenu(fileName = "FILENAME", menuName = "MENUNAME", order = 0)]
    public class LaserData : ScriptableObject
    {
        public int damage;
        public float speed;
        public LayerMask layerMask;
    }
}