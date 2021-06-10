using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagment : MonoBehaviour
{
    [SerializeField] GameObject MenuPanel;
    [SerializeField] GameObject OptionsPanel;

    // ������������ � ����� ������ � Basic: ����������� � SceneManagment
    public void ConnectToSceneManagment(int id)
    {
        SceneManagment.LoadScene(id);
    }

    // ����� � ����
    public void QuitToDesktop()
    {
        Application.Quit();
    }
}
