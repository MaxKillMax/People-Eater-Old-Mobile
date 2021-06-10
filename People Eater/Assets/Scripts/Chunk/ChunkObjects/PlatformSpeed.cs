using UnityEngine;

public class PlatformSpeed : MonoBehaviour
{
    private SpawnController spawnController;
    // Получение информации платформе при создании этого
    public void GetInformation(SpawnController Controller)
    {
        spawnController = Controller;
    }

    // Переходник для PlatformCollider.cs (он уже как рудимент, его надо бы удалить и сделать напрямую из него)
    public void Next()
    {
        spawnController.CreateNewChunk();
    }
}
