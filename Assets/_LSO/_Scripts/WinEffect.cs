using _TYU.Scripts.Player;
using TMPro;
using UnityEngine;

namespace _LSO._Scripts
{
    public class WinEffect : MonoBehaviour
    {
        [SerializeField] private Player[] players;
        [SerializeField] private ParticleSystem particles;
        [SerializeField] private TextMeshProUGUI text;

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
            Instantiate(particles, player.transform);
            text.text = $"{player.GetComponentInParent<Player>().MyType.ToString()} 가 이김!";
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