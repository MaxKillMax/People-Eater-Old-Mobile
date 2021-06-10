using System.Collections.Generic;
using UnityEngine;

// ’оть и было задание сделать карту длинной в 40 секунд,
// мне показалось более интересным сделать именно процедурную генерацию, потому что:
// 1. Ёто реиграбельно
// 2. Ёто легче(в случае, если надо создавать уровней 100, можно просто каждому накручивать уровни сложностей,
// которых у мен€ пока мало, но можно много испытаний добавить)
public class SpawnController : MonoBehaviour
{
    // ”чЄт всех чанков и количества их за всЄ врем€
    private List<GameObject> Chunks = new List<GameObject>();
    [SerializeField] GameObject ChunkPrefab;
    [SerializeField] GameObject StartChunk;
    int Count;

    // ѕараметры дл€ других чанков
    [SerializeField] List<Material> Colors = new List<Material>();
    [SerializeField] List<Material> SnakeColors = new List<Material>();
    [SerializeField] GameObject SpikePrefab;
    [SerializeField] GameObject MeatBallPrefab;
    [SerializeField] GameObject CrystalPrefab;
    [SerializeField] GameObject Snake;
    [SerializeField] SpawnController Folder;
    int Chance = 90;

    // ѕросто переменна€, которой € не смог придумать название, но она мне помогала)
    int Helper = 0;

    // ƒобавление начального чанка в список и передача ему тонны информации
    void Start() 
    {
        Helper = Random.Range(0, 6);
        Chunks.Add(StartChunk);
        StartChunk.GetComponent<Chunk>().GetInformation
            (SpikePrefab, MeatBallPrefab, CrystalPrefab, Snake, Folder, Chance, Count, Colors[Helper], SnakeColors[Helper], SnakeColors);

        Count++;
    }

    // —оздание нового чанка
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

    // ”даление старого чанка
    public void DeleteOldChunk()
    {
        GameObject Object;
        Object = Chunks[0];
        Chunks.Remove(Object);
        Destroy(Object);
    }
}
