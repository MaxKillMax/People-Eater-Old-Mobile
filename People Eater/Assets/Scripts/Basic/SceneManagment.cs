using UnityEngine.SceneManagement;

// �������� ���� (��� � ������� �� MenuManagment ���� ����� �������� ������)
public static class SceneManagment
{
    private static int prevScene = 0;
    public static void LoadScene(int id)
    {
        SceneManager.LoadSceneAsync(id);
        SceneManager.UnloadSceneAsync(prevScene);

        prevScene = id;
    }
}
