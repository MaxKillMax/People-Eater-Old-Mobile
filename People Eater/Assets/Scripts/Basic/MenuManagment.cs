using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagment : MonoBehaviour
{
    [SerializeField] GameObject MenuPanel;
    [SerializeField] GameObject OptionsPanel;

    // Используется в обоих сценах в Basic: связывается с SceneManagment
    public void ConnectToSceneManagment(int id)
    {
        SceneManagment.LoadScene(id);
    }

    // Выйти в меню
    public void QuitToDesktop()
    {
        Application.Quit();
    }
}
