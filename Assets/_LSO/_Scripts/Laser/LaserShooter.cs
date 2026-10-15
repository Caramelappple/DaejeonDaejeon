using _TYU.Scripts.Player;
using UnityEngine;

namespace _LSO._Scripts.Laser
{
    public class LaserShooter : MonoBehaviour
    {
        public Transform firePoint;
        [SerializeField] private LaserProjectile laserPrefab;
        [SerializeField] private LaserSO laserData;
        [SerializeField] private EvaluateData data;

        private float _percentage;//이거 게이지 퍼센트에 연결하면 됨

        public int CurrentDamage{get; private set;}
        public float CurrentSpeed{get; private set;}

        //private IEvaluate _evaluate = new EvaluateCalculator();
        
        private Player _player;

        private void Awake()
        {
             _player = GetComponent<Player>();   
        }

        public void Shoot()
        {
            var laser =  Instantiate(laserPrefab, firePoint.position, firePoint.rotation);

            //CurrentDamage = (int)_evaluate.Evaluate(data.damage, _percentage, true);
            //CurrentSpeed = _evaluate.Evaluate(data.speed, _percentage, false);
            //
            laser.Init(CurrentDamage, CurrentSpeed,laserData.layerMask, _player);
            laser.Step(transform.right);
        }
    }
}