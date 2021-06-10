using UnityEngine;

// Данный скрипт лежит в каждом хвосте
public class Tail : MonoBehaviour
{
    // Сохранение дистанции
    GameObject Leading;
    float Distance;
    Vector3 Zero = Vector3.zero;

    // Окрас
    [SerializeField] MeshRenderer Mesh;
    float Position;
    Material Color;
    bool Activated = true;

    // Получение информации хвосту при создании
    public void GetInformation(GameObject Leading, float Distance = 0.85f)
    {
        this.Leading = Leading;
        this.Distance = Distance;
    }

    // Принятие информации от ColorChanger.cs, если SnakeHead достиг ColorChanger
    public void ColorChange(Material Color, float Position)
    {
        Activated = false;
        this.Position = Position;
        this.Color = Color;
    }

    // Постоянное движение
    void Update()
    {
        // Смена окраса, если условия для этого соблюдены
        if (transform.localPosition.y > Position && !Activated)
        {
            Mesh.material = Color;
            Activated = true;
        }

        // Движение хвоста
        this.transform.position = new Vector3(Leading.transform.position.x - Distance, this.transform.position.y, this.transform.position.z);
        this.transform.position = Vector3.SmoothDamp(this.transform.position, new Vector3(this.transform.position.x, Leading.transform.position.y, Leading.transform.position.z), ref Zero, 0.055f);
    }
}
