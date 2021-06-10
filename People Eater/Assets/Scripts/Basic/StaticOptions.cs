using UnityEngine;
// Метод просто раздаёт инструкции разным классам
// (к примеру, игра ускоряется со временем, но насколько быстро - зависит от уровня сложности)
public static class StaticOptions
{
    public static bool Immortality = false;

    // Режим бессмертия
    // (Примечание: можно подбирать шарики чужого цвета, а также ходить по спайкам)
    // Всё, на что влияет режим бессмертия: OnDeath/DestroySnake;
    public static void GetImmortality(bool Act = false)
    {
        Immortality = Act;
    }
}
