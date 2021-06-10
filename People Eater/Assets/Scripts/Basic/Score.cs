using UnityEngine;

public static class Score
{
    // Последний счёт
    static int LastSnakeLength;
    static int LastDistance;

    // Лучший счёт
    static int BestSnakeLength;
    static int BestDistance;

    // В случае смерти добавляет в PlayerPrefs счёт и сравнивает с старым лучшим счётом(если он есть)
    public static void AddLastMatch(int _LastSnakeLength, int _LastDistance)
    {
        LastSnakeLength = _LastSnakeLength;
        LastDistance = _LastDistance;
        PlayerPrefs.SetInt("LastSnakeLength", LastSnakeLength);
        PlayerPrefs.SetInt("LastDistance", LastDistance);

        if (LastSnakeLength > BestSnakeLength)
        {
            BestSnakeLength = LastSnakeLength;
            PlayerPrefs.SetInt("BestSnakeLength", BestSnakeLength);
        }

        if (LastDistance > BestDistance)
        {
            BestDistance = LastDistance;
            PlayerPrefs.SetInt("BestDistance", BestDistance);
        }
    }

    // С скрипта Starter идёт набор начальных значений в случае, если ранее был прогресс
    public static void Starter(int A, int B, int C, int D)
    {
        LastSnakeLength = A;
        LastDistance = B;
        BestSnakeLength = C;
        BestDistance = D;
    }
}
