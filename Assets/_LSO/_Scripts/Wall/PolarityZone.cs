using _TYU.Scripts.Player;
using UnityEngine;

namespace _LSO._Scripts.Wall
{
    public class PolarityZone : MonoBehaviour
    {
        private Wall _wall;
        private void Awake() => _wall = GetComponentInParent<Wall>();

        private void OnTriggerStay(Collider other)
        {
            var player = other.GetComponentInParent<Player>();
            if (player != null) _wall.ApplyZone(player);
        }
    }
}