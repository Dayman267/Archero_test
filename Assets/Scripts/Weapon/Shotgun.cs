using UnityEngine;

public class Shotgun : MonoBehaviour
{
    private Rigidbody2D playerRB;
    private GameObject bullet;
    private Joystick joystick;

    private float secLeft;
    [SerializeField] private float secBetweenShots = 0.6f;

    [SerializeField] private float damage = 5f;
    [SerializeField] private float speed = 8f;
    [SerializeField] private int bulletsCount = 7;
    [SerializeField] private float maxDeflection = 0.3f;

    private bool canContinue;

    private void Start()
    {
        playerRB = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        bullet = Resources.Load<GameObject>("Prefabs/Bullets/Bullet");
        joystick = FindObjectOfType<Joystick>();
    }

    private void Update()
    {
        if (!canContinue) return;
        if (secLeft <= 0)
        {
            if (joystick.Direction.magnitude == 0)
            {
                for (int i = 0; i <= bulletsCount; i++) SpawnBullet();
                secLeft = secBetweenShots;
            }
        }
        else secLeft -= Time.deltaTime;
    }
    
    private void SpawnBullet()
    {
        GameObject bulletGo = Instantiate(bullet, transform.position, Quaternion.identity);
        Vector2 randomDirection = new Vector2(
            transform.up.x + Random.Range(-maxDeflection, maxDeflection), 
            transform.up.y + Random.Range(-maxDeflection, maxDeflection));
        bulletGo.GetComponent<Bullet>().Init(playerRB.gameObject, damage, speed, randomDirection);
    }
    
    private void CheckEnemies(int _)
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length > 1) return;
        canContinue = false;
    }

    private void OnEnable()
    {
        Timer.onTimerEnded += () => canContinue = true;
        EnemyHealth.onEnemyDeath += CheckEnemies;
    }

    private void OnDisable()
    {
        Timer.onTimerEnded -= () => canContinue = true;
        EnemyHealth.onEnemyDeath -= CheckEnemies;
    }
}
