using _TYU.Scripts.Player;
using UnityEngine;

namespace _LSO._Scripts
{
    public class WinEffect : MonoBehaviour
    {
        [SerializeField] private Player[] players;

        private void OnEnable()
        {
            Sub();
        }

        private void OnDisable()
        {
            Desc();
        }

    
        private void PlayWin(GameObject player)
        {
            Debug.Log(player.GetComponentInParent<Player>().MyType.ToString());
        }


        #region 구독

        private void Sub()
        {
            foreach (var player in players)
            {
                player.GetComponentInChildren<Health>().OnDead += PlayWin;
            }
        }

        private void Desc()
        {
            foreach (var player in players)
            {
                player.GetComponentInChildren<Health>().OnDead -= PlayWin;
            }
        }

        #endregion
    }
}