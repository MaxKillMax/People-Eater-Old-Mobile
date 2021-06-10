using UnityEngine;
// ����� ������ ������ ���������� ������ �������
// (� �������, ���� ���������� �� ��������, �� ��������� ������ - ������� �� ������ ���������)
public static class StaticOptions
{
    public static bool Immortality = false;

    // ����� ����������
    // (����������: ����� ��������� ������ ������ �����, � ����� ������ �� �������)
    // ��, �� ��� ������ ����� ����������: OnDeath/DestroySnake;
    public static void GetImmortality(bool Act = false)
    {
        Immortality = Act;
    }
}
