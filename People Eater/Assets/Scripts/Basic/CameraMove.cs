using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] GameObject Player;
    void Update()
    {
        // ������������ �� �������(� ������, ���� �� ��������, ������ ����� ��������� ������ ��� ������������)
        if (Player != null)
            transform.position = new Vector3(Player.transform.position.x - 3, 15, Player.transform.position.z * 0.45f);
        else transform.position = new Vector3(transform.position.x + Time.deltaTime * 2, 15, transform.position.z * 0.5f);
    }
}
