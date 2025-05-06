using YG;

namespace DroneSlayer.UI.Menu.Buttons
{
    public class LeaderboardButton : Buttons
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