using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject bullet;
    
    private Vector2 lastPosition;
    private bool isMoving;

    private float secLeft;
    [SerializeField] private float secBetweenShots = 0.3f;

    [SerializeField] private float damage = 20f;
    [SerializeField] private float speed = 8f;

    private bool canContinue;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bullet = Resources.Load<GameObject>("Prefabs/Bullets/Bullet");
    }

    private void FixedUpdate()
    {
        Vector2 currentPosition = rb.position;
        isMoving = currentPosition != lastPosition;
        lastPosition = currentPosition;
    }

    private void Update()
    {
        if (!canContinue) return;
        if (secLeft <= 0)
        {
            if (!isMoving)
            {
                SpawnBullet();
                secLeft = secBetweenShots;
            }
        }
        else secLeft -= Time.deltaTime;
    }
    
    private void SpawnBullet()
    {
        GameObject bulletGo = Instantiate(bullet, transform.position, Quaternion.identity);
        bulletGo.GetComponent<Bullet>().Init(rb.gameObject, damage, speed, transform.up);
    }
    
    private void OnEnable()
    {
        Timer.onTimerEnded += () => canContinue = true;
        PlayerHealth.onDeath += () => canContinue = false;
    }

    private void OnDisable()
    {
        Timer.onTimerEnded -= () => canContinue = true;
        PlayerHealth.onDeath += () => canContinue = false;
    }
}
