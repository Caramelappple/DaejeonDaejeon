using System;
using TMPro;
using UnityEngine;

namespace _TYU.Scripts.Module
{
    public class MovementModule : MonoBehaviour
    {
        [SerializeField] private float maxSpeed;
        [SerializeField] private float speed;
        [SerializeField] private float dashPow;
        [SerializeField] private float stopSpeed;
        [SerializeField] private float dashCool;

        private float _dashCool;
        private Vector3 _curDir;
        private Rigidbody _rb;

        public void Initialize(Rigidbody rb)
        {
            _rb = rb;
        }

        public void Push(Vector3 dir, float pow, ForceMode forceMode)
        {
            _rb.AddForce(dir * pow, forceMode);
            ReverseForce();
        }

        public void SetDir(Vector3 dir)
        {
            _curDir = dir;
        }

        private void SetMovement()
        {
            _rb.AddForce(_curDir * speed, ForceMode.Force);
            Vector3 movement = Vector3.zero;
            ReverseForce();
            movement.x = Mathf.Clamp(_rb.linearVelocity.x, -speed, speed);
            movement.z = Mathf.Clamp(_rb.linearVelocity.z, -speed, speed);
            _rb.linearVelocity = movement;
        }

        public void Dash()
        {
            if (_dashCool + dashCool < Time.time)
            {
                _rb.AddForce(_curDir * dashPow, ForceMode.Impulse);
                _dashCool = Time.time;
            }
        }

        private void ReverseForce()
        {
            Vector3 dir = _curDir;
            if (dir.x == 0)
            {
                _rb.AddForce(Vector3.left * (stopSpeed * _rb.linearVelocity.x));
            }
            if (dir.y == 0)
            {
                _rb.AddForce(Vector3.back * (stopSpeed * _rb.linearVelocity.z));
            }
        }

        private void FixedUpdate()
        {
            SetMovement();
        }
    }
}