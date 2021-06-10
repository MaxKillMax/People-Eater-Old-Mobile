using UnityEngine;

public class PlatformSpeed : MonoBehaviour
{
    private SpawnController spawnController;
    // ��������� ���������� ��������� ��� �������� �����
    public void GetInformation(SpawnController Controller)
    {
        spawnController = Controller;
    }

    // ���������� ��� PlatformCollider.cs (�� ��� ��� ��������, ��� ���� �� ������� � ������� �������� �� ����)
    public void Next()
    {
        spawnController.CreateNewChunk();
    }
}
