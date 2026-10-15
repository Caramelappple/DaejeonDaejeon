using System.Collections.Generic;
using _LSO._Scripts.Laser.Data;
using _LSO._Scripts.Laser.Interface;
using _LSO._Scripts.Laser.Reaction;
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
        
        private LaserHitResolver _hitResolver;
        private readonly PlayerHitReaction _playerReaction = new();
        private readonly Dictionary<LaserResponse, ILaserReaction> _wallReactions = 
            new()
            {
                { LaserResponse.Absorb, new AbsorbReaction() },
                { LaserResponse.Reflect, new ReflectReaction() },
                { LaserResponse.Block , new BlockReaction() }
            };

        
        
        private float _percentage;//이거 게이지 퍼센트에 연결하면 됨
        
        [field:SerializeField]
        private int CurrentDamage{get; set;}
        [field:SerializeField]
        private float CurrentSpeed{get; set;}

        private readonly IEvaluate _evaluate = new EvaluateCalculator();
        
        private Player _player;

        private void Awake()
        {
             _player = GetComponentInParent<Player>();
             _hitResolver = new LaserHitResolver(_wallReactions, _playerReaction);
             Debug.Assert(_hitResolver != null,"_hitResolver == null");
        }

        public void Shoot()
        {
            _percentage = _player.Gauge.Value;
            var laser =  Instantiate(laserPrefab, firePoint.position, firePoint.rotation);

            CurrentDamage = (int)_evaluate.Evaluate(data.damage, _percentage);
            CurrentSpeed = _evaluate.Evaluate(data.speed, _percentage);
            
            laser.Init(CurrentDamage, CurrentSpeed,laserData.layerMask, _player, _hitResolver);
            laser.Step(transform.right);
            
            _player.Gauge.Clear();
        }
    }
}