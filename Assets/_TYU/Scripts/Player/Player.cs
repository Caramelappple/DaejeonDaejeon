using System;
using _LSO._Scripts;
using _LSO._Scripts.Laser;
using _TYU.Scripts.HitEffects;
using _TYU.Scripts.Interface;
using _TYU.Scripts.JeOngiJang;
using _TYU.Scripts.Module;
using UnityEngine;

namespace _TYU.Scripts.Player
{
    public class Player : MonoBehaviour, IMovable
    {
        
        private Rigidbody _rb;
        [field: SerializeField] public LaserShooter Shooter { get; private set; }
        [field:SerializeField] public PlayerType MyType { get; private set; }
        [field:SerializeField] public ElectronicType ElectronicType { get; private set; }
        [field: SerializeField] public Health Health { get; private set; }
        [field: SerializeField] public GaugeModule Gauge { get; private set; }
        [SerializeField] private AbstractInput inputReader;
        [SerializeField] private MovementModule moveMd;
        private Transform _laserShooterTrm;

        private void Awake()
        {
            GetCompos();
            InitialIze();
            EventSub();
        }

        private void OnDestroy()
        {
            EventDisSub();
        }
        
        
        public void Push(Vector3 dir, float pow, ForceMode forceMode) => moveMd.Push(dir, pow, forceMode);
        #region EventSetting

        private void EventSub()
        {
            inputReader.OnMovePressed += SetMovementHandler;
            inputReader.OnDashPressed += DashHandler;
            inputReader.OnAttackPressed += AttackHandler;
            Health.OnDamage += HitEffect;
        }

        private void HitEffect(DamageResultData data)
        {
            if(HitCaller.Instance != null)
                HitCaller.Instance.Hit();
        }


        private void EventDisSub()
        {
            inputReader.OnMovePressed -= SetMovementHandler;
            inputReader.OnDashPressed -= DashHandler;
            inputReader.OnAttackPressed -= AttackHandler;
        }

        #endregion
        #region MethodHandler

        private void SetMovementHandler(Vector3 dir)
        {
            moveMd.SetDir(dir);
            if (dir == Vector3.zero) return;
            float rotation = Mathf.Atan2(-dir.z, dir.x) * Mathf.Rad2Deg;
            _laserShooterTrm.rotation = Quaternion.Euler(0f, rotation, 0f);
        }

        private void DashHandler() => moveMd.Dash();
        private void AttackHandler()
        {
            Shooter.Shoot();
            Debug.Log("공격");
        }

        #endregion
        #region Init

        private void GetCompos()
        {
            _rb = GetComponent<Rigidbody>();
            inputReader = GetComponentInChildren<AbstractInput>();
            Health = GetComponentInChildren<Health>();
            moveMd = GetComponentInChildren<MovementModule>();
            Gauge = GetComponentInChildren<GaugeModule>();
            Shooter = GetComponentInChildren<LaserShooter>();
            _laserShooterTrm = Shooter.transform;
        }

        private void InitialIze()
        {
            moveMd.Initialize(_rb);
        }

        #endregion
    }
}