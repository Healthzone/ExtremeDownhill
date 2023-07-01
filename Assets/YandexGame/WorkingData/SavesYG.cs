
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


        public float volumePc = -15f;
        public float renderScalePc = 1.0f;

        public float volumePhone = -15f;
        public float renderScalePhone = 0.70f;

        public bool antiAliasingPC = true;
        public bool antiAliasingPhone = false;

        public int unlockedLastLevel = 1;
        public int maxLevel = 14;
        // Ваши сохранения

        // ...

        // Поля (сохранения) можно удалять и создавать новые. При обновлении игры сохранения ломаться не должны
        // Пока выявленное ограничение - это расширение массива


        // Вы можете выполнить какие то действия при загрузке сохранений
        public SavesYG()
        {
            maxLevel = 14;
            // Допустим, задать значения по умолчанию для отдельных элементов массива

           

            // Длина массива в проекте должна быть задана один раз!
            // Если после публикации игры изменить длину массива, то после обновления игры у пользователей сохранения могут поломаться
            // Если всё же необходимо увеличить длину массива, сдвиньте данное поле массива в самую нижнюю строку кода
        }
    }
}
