using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    private float moveTime;
    private float waitTime;
    private Vector2 moveDirection;
    private bool isMoving = false;

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float maxMoveTime = 2f;
    [SerializeField] private float standingSeconds = 2f;

    private bool canContinue;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        ChooseNewDirection();
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
        if (isMoving)
        {
            rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);

            if (Time.time >= moveTime)
            {
                isMoving = false;
                rb.velocity = Vector2.zero;
                waitTime = Time.time + standingSeconds;
            }
        }
        else
        {
            if (Time.time >= waitTime)
            {
                ChooseNewDirection();
            }
        }
    }

    private void ChooseNewDirection()
    {
        moveDirection = new Vector2(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)).normalized;

        moveTime = Time.time + Random.Range(0.5f, maxMoveTime);
        isMoving = true;
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