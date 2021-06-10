using UnityEngine;

public class MeatBallColor : MonoBehaviour
{
    [SerializeField] MeshRenderer MeatBallRenderer;
    Material Color;

    // �������� ���������� ������� ������ ��� ��������
    public void GetInformation(Material Color)
    {
        this.Color = Color;
        MeatBallRenderer.material = Color;
    }

    // ������ ���������� ������, ���� ��������� ������� � �����(Zone.cs) ������� ������ �������
    public Material ReadInformation()
    {
        return Color;
    }
}
