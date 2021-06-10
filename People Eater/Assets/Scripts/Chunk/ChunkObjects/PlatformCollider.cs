using UnityEngine;

public class PlatformCollider : MonoBehaviour
{
    private bool Activate = false;
    // При соприкосновении с этим объектом генерирует следующий чанк через PlatformSpeed.cs
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.name == "SnakeHead" && !Activate)
        {
            GetComponentInParent<PlatformSpeed>().Next();
            Activate = true;
        }
    }
}
