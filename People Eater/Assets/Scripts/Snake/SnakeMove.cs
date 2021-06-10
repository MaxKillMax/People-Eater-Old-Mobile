using UnityEngine;
using System.Globalization;
using UnityEngine.UI;

public class SnakeMove : MonoBehaviour
{
    [SerializeField] private Rigidbody RB;
    [SerializeField] private Text TXT1;
    [SerializeField] private SnakeLength snakeLength;
    [SerializeField] private ModeFever modeFever;
    [SerializeField] private OnDeath onDeath;

    private float FeverTimer = 0;
    private float PostFeverTimer = 0;

    private bool ActivateMove = false;
    private Vector3 vector = Vector3.zero;
    private float speed = 500;
    Vector3 ObjectHit = Vector3.zero;
    [HideInInspector] public float Speed { get { return speed; } set { speed = value; } }

    void Update()
    {
        // ≈сли ModeFever активен, всЄ остальное блокируетс€(даже ускорение со временем)
        if (FeverTimer <= 0)
        {
            // Ќажатие пальцами дл€ управлени€
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Ray touchRay = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit touchCastHit;

                if (touch.phase == TouchPhase.Began && Physics.Raycast(touchRay, out touchCastHit))
                {
                    if (touchCastHit.transform.parent.gameObject == transform.parent.gameObject) ActivateMove = true;
                }

                if (touch.phase == TouchPhase.Ended) ActivateMove = false;

                if ((touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary) && ActivateMove)
                {
                    if (Physics.Raycast(touchRay, out touchCastHit))
                    {
                        ObjectHit = touchCastHit.point;
                    }
                }
            }

            // ƒвижение и его обновление в статистике
            RB.velocity = new Vector3(speed * Time.deltaTime, 0, -(transform.position.z - ObjectHit.z) * speed / 4 * Time.deltaTime);
            TXT1.text = (this.transform.position.x - 4).ToString("N0", CultureInfo.CurrentCulture);

            // Ќебольшие повороты головой при движении в сторону
            transform.eulerAngles = new Vector3(0, -RB.velocity.z, -90);
        }
        // ModeFever действие режима
        else
        {
            transform.position = Vector3.SmoothDamp(this.transform.position, new Vector3(this.transform.position.x, this.transform.position.y, 0), ref vector, 0.5f);
            RB.velocity = new Vector3(speed * 3 * Time.deltaTime, 0, 0);

            FeverTimer -= Time.deltaTime;
            if (FeverTimer <= 0)
            {
                FeverTimer = 0;
                modeFever.FeverMode = false;
            }
        }

        if (PostFeverTimer > 0)
        {
            PostFeverTimer -= Time.deltaTime;
            if (PostFeverTimer <= 0)
            {
                PostFeverTimer = 0;
                StaticOptions.Immortality = false;
            }
        }
    }

    // ModeFever активаци€
    public void ActivateFever()
    {
        transform.eulerAngles = new Vector3(0, 0, -90);
        ObjectHit = Vector3.zero;
        FeverTimer = 5;

        if (!StaticOptions.Immortality)
        {
            StaticOptions.Immortality = true;
            PostFeverTimer = 5.5f;
        }
    }
}
