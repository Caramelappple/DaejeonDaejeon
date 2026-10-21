using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _LSO._Scripts
{
    [RequireComponent(typeof(Button))]
    public class ExitGame : MonoBehaviour, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            Quit();
        }

        private void Quit()
        {
            Application.Quit();
        }
    }
}