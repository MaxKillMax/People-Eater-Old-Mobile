using UnityEngine.SceneManagement;

// Загрузка сцен (тут в отличие от MenuManagment есть некая гибкость метода)
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
