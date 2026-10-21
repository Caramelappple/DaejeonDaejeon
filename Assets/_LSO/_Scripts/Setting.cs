using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _LSO._Scripts
{
    public class Setting   : MonoBehaviour
    {
        [SerializeField] public GameObject setting;
        private void Update()
        {
            if (Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                setting.SetActive(!setting.activeSelf);
            }
        }
    }
}