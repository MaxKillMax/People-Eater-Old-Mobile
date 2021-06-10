using UnityEngine;

// ������ ������ ����� � ������ ������
public class Tail : MonoBehaviour
{
    // ���������� ���������
    GameObject Leading;
    float Distance;
    Vector3 Zero = Vector3.zero;

    // �����
    [SerializeField] MeshRenderer Mesh;
    float Position;
    Material Color;
    bool Activated = true;

    // ��������� ���������� ������ ��� ��������
    public void GetInformation(GameObject Leading, float Distance = 0.85f)
    {
        this.Leading = Leading;
        this.Distance = Distance;
    }

    // �������� ���������� �� ColorChanger.cs, ���� SnakeHead ������ ColorChanger
    public void ColorChange(Material Color, float Position)
    {
        Activated = false;
        this.Position = Position;
        this.Color = Color;
    }

    // ���������� ��������
    void Update()
    {
        // ����� ������, ���� ������� ��� ����� ���������
        if (transform.localPosition.y > Position && !Activated)
        {
            Mesh.material = Color;
            Activated = true;
        }

        // �������� ������
        this.transform.position = new Vector3(Leading.transform.position.x - Distance, this.transform.position.y, this.transform.position.z);
        this.transform.position = Vector3.SmoothDamp(this.transform.position, new Vector3(this.transform.position.x, Leading.transform.position.y, Leading.transform.position.z), ref Zero, 0.055f);
    }
}
