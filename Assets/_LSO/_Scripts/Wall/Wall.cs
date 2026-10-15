using _LSO._Scripts.Wall.Data;
using _TYU.Scripts.Player;
using UnityEngine;

namespace _LSO._Scripts.Wall
{
    public class Wall : MonoBehaviour
    {
        public WallSO wallSO;
        
        private Collider _col;
        private void Awake() => _col = GetComponent<Collider>();

        // 접촉하면 접지 벽 방전
        private void OnCollisionStay(Collision c)
        {
            if (wallSO is not GroundWallData g) return;
            var player = c.collider.GetComponentInParent<Player>();
            if (player == null) return;
            player.Gauge.Down(g.absorbValuePerSecond * Time.fixedDeltaTime);
        }

        // 구역에 들면 극성 벽 밀고 당기기
        public void ApplyZone(Player player)
        {
            if (wallSO is not PolarityWallData p) return;
            Vector3 dir = player.transform.position - _col.ClosestPoint(player.transform.position);
            dir.y = 0f;
            if (dir.sqrMagnitude < 0.0001f) return;
            float sign = (player.ElectronicType == p.type) ? 1f : -1f;   // 같은 극 밀어냄, 다른 극 당김
            player.Push(dir.normalized * sign, p.force, p.forceMode);
        }
    }
}