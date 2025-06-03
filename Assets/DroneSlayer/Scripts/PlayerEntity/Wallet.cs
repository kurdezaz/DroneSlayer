using System;
using UnityEngine;
using YG;

namespace DroneSlayer.PlayerEntity
{
    public class Wallet : MonoBehaviour
    {
        public event Action MoneyChanged;

        public float Money { get; private set; }

        public void GetMoney(float money)
        {
            Money += money;
            YandexGame.savesData.cash = Money;
            MoneyChanged?.Invoke();
            YandexGame.SaveLocal();
        }

        public void SpendMoney(float money)
        {
            if (money <= Money)
            {
                Money -= money;
                YandexGame.savesData.cash = Money;
                MoneyChanged?.Invoke();
            }
        }

        public void LoadCash()
        {
            Money = YandexGame.savesData.cash;
        }
    }
}