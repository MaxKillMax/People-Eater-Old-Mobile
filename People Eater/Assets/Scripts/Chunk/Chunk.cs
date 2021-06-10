using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    // Связанное с спайками
    List<GameObject> Dangers = new List<GameObject>();
    [SerializeField] GameObject DangersParent;
    GameObject SpikePrefab;

    // Связанное с мясными шариками
    List<GameObject> Food = new List<GameObject>();
    [SerializeField] GameObject FoodParent;
    GameObject MeatBallPrefab;

    // Связанное с кристаллами
    List<GameObject> Crystals = new List<GameObject>();
    [SerializeField] GameObject CrystalsParent;
    GameObject CrystalPrefab;

    // Связанное с материалами(цветами)
    Material[] Colors = new Material[3];
    [SerializeField] MeshRenderer ColorChanger;

    // Вспомогательные вещи
    GameObject Snake;
    SpawnController Folder;
    [SerializeField] PlatformSpeed Platform;

    // Ещё вспомогательные вещи
    int Index;
    float Chance;
    float CurChance;
    int SkipSpike;
    int Count;
    int ObjectCount;

    // Передача параметров этому чанку при создании
    public void GetInformation(GameObject SpikeP, GameObject MeatBallP, GameObject CrystalP, GameObject Snake, SpawnController Folder, int Chance, int Count, Material Color, Material SnakeColor, List<Material> SnakeColors)
    {
        SpikePrefab = SpikeP;
        MeatBallPrefab = MeatBallP;
        CrystalPrefab = CrystalP;

        this.Snake = Snake;
        this.Folder = Folder;
        this.Chance = Chance;
        this.Count = Count;

        ColorChanger.material = Color;
        Colors[0] = SnakeColors[Random.Range(0, 5)];
        Colors[1] = SnakeColors[Random.Range(0, 5)];
        Colors[2] = SnakeColor;
        Create();
    }

    // Создание объектов на чанке
    void Create()
    {
        // Раздача информации тому, кто красит перед началом чанка
        ColorChanger.GetComponent<ColorChanger>().GetInformation(Snake, Colors[2]);

        Platform.GetInformation(Folder);

        // Настройка рандома перед проходом всего чанка
        CurChance = Chance + 5 + Count;
        SkipSpike = -72;

        if (Count > 0)
        {
            // Проход всего чанка
            for (int i = -72; i < 72; i += 2)
            {
                SkipSpike += 1;

                // Шанс выбора данной линии для спайков
                if (Random.Range(0, 100) > CurChance && SkipSpike < i)
                {
                    CreateSpike(i);
                }
                // Шанс выбора данной линии для еды или кристаллов, если спайки не выбраны.
                else if (Random.Range(0, 100) > CurChance - 5 && SkipSpike < i)
                {
                    CreateOther(i);
                }
                // Послабление псевдорандома в случае, если ничего из предыдущего не прокатило
                else
                {
                    CurChance -= 3;
                }
            }
        }
    }

    void CreateSpike(int i)
    {
        // Разбор данной линии спайков
        for (int a = -6; a <= 6; a++)
        {
            // Увеличение шанса создания по краям и на точках 4, 0, -4
            if (a == -6 || a == 6 || a == 4 || a == 0 || a == -4)
            {
                CurChance -= 10;
            }

            // Шанс создания спайка на данной линии
            if (Random.Range(0, 100) > CurChance && ObjectCount < 2)
            {
                Dangers.Add(Instantiate(SpikePrefab));
                Dangers[Dangers.Count - 1].transform.localPosition = new Vector3(Count * 150 + i, 1, a);
                Dangers[Dangers.Count - 1].transform.parent = DangersParent.transform;
                a++;
                ObjectCount += 1;
            }

            CurChance = Chance;
        }
        SkipSpike = i + 2;
        ObjectCount = 0;
        CurChance = Chance;
    }

    void CreateOther(int i)
    {
        // Разбор данной линии
        for (int a = -5; a <= 5; a++)
        {
            // Увеличение шанса создания в 4, 0, -4
            if (a == 4 || a == 0 || a == -4)
            {
                CurChance -= 30;
            }

            // Шанс создания мясного шарика на данной линии
            if (Random.Range(0, 100) > CurChance && ObjectCount < 3)
            {
                Food.Add(Instantiate(MeatBallPrefab));
                Food[Food.Count - 1].transform.localPosition = new Vector3(Count * 150 + i, 1.55f, a);
                Food[Food.Count - 1].transform.parent = FoodParent.transform;
                Food[Food.Count - 1].GetComponent<MeatBallColor>().GetInformation(Colors[Index]);
                a++;
                ObjectCount += 1;
            }
            // Шанс создания кристалла, если мясные шарики не выбраны
            if (Random.Range(0, 100) > CurChance + 5 && ObjectCount < 3)
            {
                Crystals.Add(Instantiate(CrystalPrefab));
                Crystals[Crystals.Count - 1].transform.localPosition = new Vector3(Count * 150 + i, 1.55f, a);
                Crystals[Crystals.Count - 1].transform.parent = CrystalsParent.transform;
                a++;
                ObjectCount += 1;
            }

            CurChance = Chance;
            Index = a % 3;
            if (Index < 0) Index *= -1;
        }
        SkipSpike = i + 2;
        ObjectCount = 0;
    }
}