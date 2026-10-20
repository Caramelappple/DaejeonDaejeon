using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _LSO._Scripts
{
    [RequireComponent(typeof(Button))]
    public class SceneMover : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private string sceneName;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            MoveScene();
        }

        private void MoveScene()
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}