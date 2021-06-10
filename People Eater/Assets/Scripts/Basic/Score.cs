using UnityEngine;

public static class Score
{
    // ��������� ����
    static int LastSnakeLength;
    static int LastDistance;

    // ������ ����
    static int BestSnakeLength;
    static int BestDistance;

    // � ������ ������ ��������� � PlayerPrefs ���� � ���������� � ������ ������ ������(���� �� ����)
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

    // � ������� Starter ��� ����� ��������� �������� � ������, ���� ����� ��� ��������
    public static void Starter(int A, int B, int C, int D)
    {
        LastSnakeLength = A;
        LastDistance = B;
        BestSnakeLength = C;
        BestDistance = D;
    }
}
