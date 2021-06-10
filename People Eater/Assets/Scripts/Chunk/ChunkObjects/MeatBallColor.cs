using UnityEngine;

public class MeatBallColor : MonoBehaviour
{
    [SerializeField] MeshRenderer MeatBallRenderer;
    Material Color;

    // Передача информации мясному шарику при создании
    public void GetInformation(Material Color)
    {
        this.Color = Color;
        MeatBallRenderer.material = Color;
    }

    // Чтение информации отсюда, если произошло касание с зоной(Zone.cs) впереди головы змеёныша
    public Material ReadInformation()
    {
        return Color;
    }
}
