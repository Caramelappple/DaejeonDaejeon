using UnityEngine;

namespace _LSO._Scripts.Laser
{
    [RequireComponent(typeof(LineRenderer))]
    public class LaserVisual : MonoBehaviour
    {
        private LineRenderer _line;

        private void Awake()
        {
            _line = GetComponent<LineRenderer>();
            _line.useWorldSpace = true;   // 월드 좌표로 그려야 투사체가 움직여도 선이 안 끌려감
            _line.positionCount = 0;
        }

        // 발사 시점에 호출: 시작점 기록 + head 점 하나 추가
        public void Begin(Vector3 startPoint)
        {
            _line.positionCount = 2;
            _line.SetPosition(0, startPoint);
            _line.SetPosition(1, startPoint);
        }

        // 충돌/반사 지점 확정 (head 위치를 그 지점에 고정하고 새 head 점 추가)
        public void AddPoint(Vector3 point)
        {
            int last = _line.positionCount - 1;
            _line.SetPosition(last, point);          // 현재 head를 충돌 지점으로 확정
            _line.positionCount++;
            _line.SetPosition(last + 1, point);      // 새 head 점 (이후 UpdateHead로 따라감)
        }

        // 매 프레임 호출: 마지막 점(head)을 투사체 위치로 갱신
        public void UpdateHead(Vector3 headPosition)
        {
            if (_line.positionCount == 0) return;
            _line.SetPosition(_line.positionCount - 1, headPosition);
        }
    }
}