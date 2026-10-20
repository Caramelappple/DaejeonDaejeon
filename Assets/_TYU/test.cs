using System;
using _TYU.Scripts;
using _TYU.Scripts.HitEffects;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _TYU
{
    public class test : MonoBehaviour
    {
        private void Update()
        {
            if (Keyboard.current.cKey.wasPressedThisFrame)
                HitCaller.Instance.Hit();
        }
    }
}