using UnityEngine;

public class BullMovement : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    private Vector2 moveDirection;

    [SerializeField] private float moveSpeed = 3f;

    private bool canContinue;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Look();
        if(!canContinue) return;
        Move();
    }

    private void Look()
    {
        Vector2 lookDirection = player.transform.position - transform.position;
        float rotate = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotate - 90);
    }

    private void Move()
    {
        moveDirection = player.transform.position - transform.position;
        moveDirection.Normalize();
        rb.velocity = moveDirection * moveSpeed *20 * Time.deltaTime;
    }

    private void OnEnable()
    {
        Timer.onTimerEnded += () => canContinue = true;
    }

    private void OnDisable()
    {
        Timer.onTimerEnded -= () => canContinue = true;
    }
}
