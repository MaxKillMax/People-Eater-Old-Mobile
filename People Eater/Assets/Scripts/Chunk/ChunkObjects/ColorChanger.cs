using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    GameObject Snake;
    Material SnakeColor;

    // �������� ���������� ��� ��������
    public void GetInformation(GameObject Snake, Material SnakeColor)
    {
        this.Snake = Snake;
        this.SnakeColor = SnakeColor;
    }

    // ��� ������� � ������� ������� ���� ��������� ���������� � ���, ����� ������ ����
    // � ����� ������ ���� ������
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "SnakeHead")
        {
            other.GetComponent<MeshRenderer>().material = SnakeColor;
            for (int i = 0; i < Snake.transform.childCount; i++)
            {
                if (Snake.transform.GetChild(i).tag != "Closed" && Snake.transform.GetChild(i).name != "SnakeHead")
                {
                    Snake.transform.GetChild(i).gameObject.GetComponent<Tail>().ColorChange(SnakeColor, Snake.transform.GetChild(0).localPosition.y);
                }
            }
        }
    }
}
