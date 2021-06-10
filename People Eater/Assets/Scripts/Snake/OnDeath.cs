using UnityEngine;

public class OnDeath : MonoBehaviour
{
    [SerializeField] GameObject PreMenu;
    [SerializeField] GameObject InfoMenu;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Crystal" || collision.transform.tag == "Eat")
        {
            DestroySnake();
        }
    }

    public void DestroySnake()
    {
        // Через этот метод происходит умерщвление змейки
        if (!StaticOptions.Immortality)
        {
            InfoMenu.SetActive(false);
            PreMenu.SetActive(true);
            Score.AddLastMatch(GetComponentInParent<SnakeLength>().GetToScore(), Mathf.RoundToInt(this.transform.position.x) - 4);
            Destroy(transform.parent.gameObject);
        }
    }
}
