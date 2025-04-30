using YG;

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
