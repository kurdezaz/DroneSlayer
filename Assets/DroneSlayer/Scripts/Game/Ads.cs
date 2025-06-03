using UnityEngine;
using YG;

namespace DroneSlayer.Game
{
    public class Ads : MonoBehaviour
    {
        private void OnEnable()
        {
            YandexGame.CloseFullAdEvent += CloseAd;
        }

        private void OnDisable()
        {
            YandexGame.CloseFullAdEvent -= CloseAd;
        }

        private void CloseAd()
        {
            Time.timeScale = 0;
        }
    }
}