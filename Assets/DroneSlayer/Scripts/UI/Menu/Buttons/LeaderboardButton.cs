using UnityEngine;
using YG;

namespace DroneSlayer.UI.Menu.Buttons
{
    public class LeaderboardButton : MonoBehaviour
    {
        private void Awake()
        {
            if (YandexGame.auth == false)
            {
                gameObject.SetActive(false);
            }
        }
    }
}