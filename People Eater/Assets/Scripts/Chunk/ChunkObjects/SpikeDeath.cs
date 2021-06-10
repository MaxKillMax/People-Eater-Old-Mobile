using UnityEngine;

public class SpikeDeath : MonoBehaviour
{
    // Смертельное касание
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "SnakeHead")
        {
            other.GetComponent<OnDeath>().DestroySnake();
        }
    }
}
