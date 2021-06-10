using System.Collections.Generic;
using UnityEngine;

// ���� � ���� ������� ������� ����� ������� � 40 ������,
// ��� ���������� ����� ���������� ������� ������ ����������� ���������, ������ ���:
// 1. ��� ������������
// 2. ��� �����(� ������, ���� ���� ��������� ������� 100, ����� ������ ������� ����������� ������ ����������,
// ������� � ���� ���� ����, �� ����� ����� ��������� ��������)
public class SpawnController : MonoBehaviour
{
    // ���� ���� ������ � ���������� �� �� �� �����
    private List<GameObject> Chunks = new List<GameObject>();
    [SerializeField] GameObject ChunkPrefab;
    [SerializeField] GameObject StartChunk;
    int Count;

    // ��������� ��� ������ ������
    [SerializeField] List<Material> Colors = new List<Material>();
    [SerializeField] List<Material> SnakeColors = new List<Material>();
    [SerializeField] GameObject SpikePrefab;
    [SerializeField] GameObject MeatBallPrefab;
    [SerializeField] GameObject CrystalPrefab;
    [SerializeField] GameObject Snake;
    [SerializeField] SpawnController Folder;
    int Chance = 90;

    // ������ ����������, ������� � �� ���� ��������� ��������, �� ��� ��� ��������)
    int Helper = 0;

    // ���������� ���������� ����� � ������ � �������� ��� ����� ����������
    void Start() 
    {
        Helper = Random.Range(0, 6);
        Chunks.Add(StartChunk);
        StartChunk.GetComponent<Chunk>().GetInformation
            (SpikePrefab, MeatBallPrefab, CrystalPrefab, Snake, Folder, Chance, Count, Colors[Helper], SnakeColors[Helper], SnakeColors);

        Count++;
    }

    // �������� ������ �����
    public void CreateNewChunk()
    {
        Chance--;
        Helper = Random.Range(0, 6);

        Chunks.Add(Instantiate(ChunkPrefab));
        Chunks[Chunks.Count - 1].transform.position = new Vector3(150 * Count, 0, 0);
        Chunks[Chunks.Count - 1].transform.parent = this.transform;
        Chunks[Chunks.Count - 1].GetComponent<Chunk>().GetInformation
            (SpikePrefab, MeatBallPrefab, CrystalPrefab, Snake, Folder, Chance, Count, Colors[Helper], SnakeColors[Helper], SnakeColors);

        Count++;
        if (Count > 3) DeleteOldChunk();
    }

    // �������� ������� �����
    public void DeleteOldChunk()
    {
        GameObject Object;
        Object = Chunks[0];
        Chunks.Remove(Object);
        Destroy(Object);
    }
}
