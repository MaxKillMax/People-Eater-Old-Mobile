using UnityEngine;

public class SpikeDeath : MonoBehaviour
{
    // ����������� �������
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "SnakeHead")
        {
            other.GetComponent<OnDeath>().DestroySnake();
        }
    }
}
