using UnityEngine;

public class Zone : MonoBehaviour
{
    [SerializeField] GameObject SnakeHead;
    [SerializeField] GameObject Snake;
    [SerializeField] ModeFever modeFever;
    [SerializeField] SnakeLength snakeLength;
    [SerializeField] OnDeath Death;

    [SerializeField] MeshRenderer Mesh;
    Material EatColor;

    // ��� ���� �������� �������
    private void OnTriggerEnter(Collider other)
    {
        // ��� ���?
        if (other.transform.tag == "Eat")
        {
            EatColor = other.GetComponent<MeatBallColor>().ReadInformation();

            // �������� �� ���������� ���������� (� � ������ ���� - ����������� �������)
            if (Mesh.material.name != EatColor.name + " (Instance)")
            {
                Death.DestroySnake();
            }

            // ���������� ������
            snakeLength.AddTail(EatColor);
            Destroy(other.gameObject);
        }

        // � ����� �������?
        else if (other.transform.tag == "Crystal")
        {
            // ���������� � ������ ������
            modeFever.AddCrystal();
            Destroy(other.transform.gameObject);
        }
    }
}
