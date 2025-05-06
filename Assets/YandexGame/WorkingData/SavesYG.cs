using DroneSlayer.WeaponEntity;

namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Тестовые сохранения для демо сцены
        // Можно удалить этот код, но тогда удалите и демо (папка Example)
        public int money = 1;                       // Можно задать полям значения по умолчанию
        public string newPlayerName = "Hello!";
        public bool[] openLevels = new bool[3];

        // Ваши сохранения

        public float cash = 0;
        public float health = 1000;
        public int playerLevel = 1;
        public float playerExpirience = 0f;
        public long score = 0;
        public int skillPoints = 1;
        public bool[] isSold = new bool[6];
        public WeaponTypes weaponTypes = WeaponTypes.M1911;
        public int[] skills = new int[6];

        // Поля (сохранения) можно удалять и создавать новые. При обновлении игры сохранения ломаться не должны


        // Вы можете выполнить какие то действия при загрузке сохранений
        public SavesYG()
        {
            isSold[0] = true;
            // Допустим, задать значения по умолчанию для отдельных элементов массива
            openLevels[1] = true;
        }
    }
}
