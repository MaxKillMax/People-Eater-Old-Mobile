using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Globalization;

public class SnakeLength : MonoBehaviour
{
    List<GameObject> Tails = new List<GameObject>();
    [SerializeField] GameObject TailPrefab;
    [SerializeField] GameObject Head;
    [SerializeField] MeshRenderer HeadColor;
    [SerializeField] Text TXT;

    public void AddTail(Material Color)
    {
        // �������� ������
        Tails.Add(Instantiate(TailPrefab));
        Tails[Tails.Count - 1].transform.position = new Vector3(Head.transform.position.x - 0.4f - 0.9f * Tails.Count, 0, Head.transform.position.z);
        Tails[Tails.Count - 1].transform.parent = this.transform;
        Tails[Tails.Count - 1].GetComponent<MeshRenderer>().material = Color;

        // ���� ����� ����� ������, � ���� �������������� ���������� �� ���������� ��������� �� �����������
        if (Tails.Count > 1)
        {
            Tails[Tails.Count - 1].GetComponent<Tail>().GetInformation(Tails[Tails.Count - 2]);
        }
        else
        {
            Tails[0].GetComponent<Tail>().GetInformation(Head, 1.2f);
        }

        // ����� ������ � ����������
        TXT.text = (Tails.Count + 1).ToString("N0", CultureInfo.CurrentCulture);
    }

    // ��� ������ ���� ������ ������(����� �����, ����� ��������� ������ � SnakeMove.cs)
    public int GetToScore()
    {
        return Tails.Count + 1;
    }
}
