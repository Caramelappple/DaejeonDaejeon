using System;
using _LSO._Scripts;
using _TYU.Scripts.Interface;
using _TYU.Scripts.Module;
using UnityEngine;

namespace _TYU.Scripts.Player
{
    public class Player : MonoBehaviour, IMovable, IDamageable, IGaugeHavable
    {
        
        private Rigidbody _rb;
        [field:SerializeField] public PlayerType MyType { get; private set; }
        [SerializeField] private AbstractInput inputReader;
        [SerializeField] private HealthModule hpMd;
        [SerializeField] private MovementModule moveMd;

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

        public void Push(Vector3 dir, float pow, ForceMode forceMode)
        {
            
        }

        public void GetDamage(int damage) => hpMd.GetDamage(damage);
        
        #region EventSetting

        private void EventSub()
        {
            inputReader.OnMovePressed += SetMovementHandler;
        }

        private void EventDisSub()
        {
            inputReader.OnMovePressed -= SetMovementHandler;
        }

        #endregion

        #region MethodHandler

        private void SetMovementHandler(Vector3 dir)
        {
            moveMd.SetDir(dir);
        }

        #endregion
        #region Init

        private void GetCompos()
        {
            _rb = GetComponent<Rigidbody>();
            inputReader = GetComponentInChildren<AbstractInput>();
            hpMd = GetComponentInChildren<HealthModule>();
            moveMd = GetComponentInChildren<MovementModule>();
        }

        private void InitialIze()
        {
            moveMd.Initialize(_rb);
        }

        #endregion

        public void DownGauge(int value)
        {
        }

        public void UpGauge(int value)
        {
        }
    }
}